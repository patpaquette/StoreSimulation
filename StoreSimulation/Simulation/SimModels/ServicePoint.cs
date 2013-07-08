using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoreSimulation.SimModels
{
    public class ServicePoint
    {
        //List<Client> clients;
        public StoreQueue queue;
        long timeServed;
        int id;
        Store store;
        ClientExitCashierEventHandler clientExitCashListener;
        double arrivalRate;
        long timeOpened;
        protected String type;
        protected int maxItems;

        public ServicePoint(int i, Store store)
        {
            //clients = new List<Client>();

            queue = new StoreQueueListImpl(this.ToString(), Configs.MAX_CLIENTS_PER_CASH);
            queue.AddServicePoint(this);

            id = i;
            this.store = store;
            arrivalRate = 0.0f;
            timeOpened = Timer.getTick();
            this.type = "default";
            this.maxItems = Configs.MAX_ITEMS_PER_CLIENT;
        }

        public void Update()
        {
            if (this.queue.GetSize() > 0)
                if (this.queue.PeekNext().isFinishedPurchase(this.getItemProcessingTime()))     // the time it takes
                    AdvanceQueue();                                                                      // one customer to pay, is 10 seconds
        }                                                                                                // per item, plus 1 minute for the payment

        public virtual bool CanService(Client c)
        {
            if (c.getNumItems() > Configs.MAX_SP_ITEMS)
            {
                return false;
            }

            if (this.queue.GetSize() >= Configs.MAX_CLIENTS_PER_CASH)
            {
                return false;
            }

            return true;
        }

        public void AdvanceQueue()
        {

            // Failsafe for filling up the empty service point
            if (this.queue.GetSize() == 0)
                return;

            Client c = this.queue.GetNext();
            

            OnClientExitCashier(new ClientServicePointEventArgs(c, Timer.getTick(), this));
            this.store.RemoveClient(c);

            if (this.queue.GetSize() > 0)
            {
                Client firstClient = this.queue.PeekNext();
                firstClient.startPurchase();
                OnClientInFrontOfQueueCashier(new ClientServicePointEventArgs(firstClient, Timer.getTick(), this));
                //       if( store.getWaitingQueueSize() > 0)
                //         store.RemoveClientFromWaitQueue(store.getWaitQueue().ElementAt(0));
            }
        }

        public void AddClient(Client c)
        {
            this.queue.AddClient(c);
            OnClientEnteredCashier(new ClientServicePointEventArgs(c, Timer.getTick(), this));
            if (this.queue.PeekNext() == c)
            {
                this.queue.PeekNext().startPurchase();
                OnClientInFrontOfQueueCashier(new ClientServicePointEventArgs(c, Timer.getTick(), this));
            }
        }

        public void Close()
        {
            
        }

        public double computeArrivalRate()
        {
            int size = this.queue.GetSize();
            long now = Timer.getTick();
            double denominator = (double)((now - timeOpened) / 60.0);

            if (now != timeOpened)
                this.arrivalRate = size / denominator;
            else
                this.arrivalRate = 0.0f;
            return arrivalRate;
        }

        public double getArrivalRate()
        {
            return this.arrivalRate;
        }

        public virtual int getItemProcessingTime()
        {
            return Configs.ITEM_PROCESS_TIME;
        }

        public virtual bool isFull()
        {
            return this.queue.IsFull();
        }

        public override string ToString()
        {
            return this.type + "_SP" + this.id;
        }

        public int getTotalItems()
        {
            int t = 0;
            foreach (Client c in this.queue.getClients())
            {
                t += c.getNumItems();
            }
            return t;
        }

        public int getMaxItems()
        {
            return this.maxItems;
        }

        public List<Client> getClients() { return this.queue.getClients(); }
        public int getId() { return id; }
        public StoreQueue getQueue() { return this.queue; }

        //event when a client enters a cashier
        public delegate void ClientEnteredCashierEventHandler(object sender, ClientServicePointEventArgs e);
        public static event ClientEnteredCashierEventHandler ClientEnteredCashier;
        protected void OnClientEnteredCashier(ClientServicePointEventArgs e)
        {
            if (ClientEnteredCashier != null)
            {
                ClientEnteredCashier(this, e);
            }

        }

        //event when a client exits a cashier
        public delegate void ClientExitCashierEventHandler(object sender, ClientServicePointEventArgs e);
        public static event ClientExitCashierEventHandler ClientExitCashier;
        protected void OnClientExitCashier(ClientServicePointEventArgs e)
        {
            if (ClientExitCashier != null)
            {
                ClientExitCashier(this, e);
            }

        }

        //event when a client is at the front of the of the queue
        public delegate void ClientInFrontOfQueueCashierEventHandler(object sender, ClientServicePointEventArgs e);
        public static event ClientInFrontOfQueueCashierEventHandler ClientInFrontOfQueueCashier;
        protected void OnClientInFrontOfQueueCashier(ClientServicePointEventArgs e)
        {
            if (ClientInFrontOfQueueCashier != null)
            {
                ClientInFrontOfQueueCashier(this, e);
            }

        }
    }
}
