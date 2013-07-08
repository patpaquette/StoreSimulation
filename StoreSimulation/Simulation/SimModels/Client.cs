using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StoreSimulation.SimModels;
using StoreSimulation.SimModels.Strategies;

enum STATES { WAIT_TO_QUEUE, IN_WQ, FRONT_WQ, IN_CASH, FRONT_CASH }

namespace StoreSimulation.SimModels
{
    public class Client
    {
        public static int CUSTOMERID = 0;
        private int id;
        private bool inQueue;
        private STATES state;
        private List<ServiceItem> serviceItems;
        private long timeEnteredStore;
        private long timeEnteredQueue;
        private long startPurchaseTime;
        private long startWQTime;
        private long startSQTime;
        private ClientStrategy strategy;
        private List<ClientStrategy> strategies;
        private int currentStrategy;
        private int patience;
        public StoreQueue currentQueue;
        private Store store;

        public void GenerateServiceItems(int x)
        {
            int y;
            for (y = 0; y < x; y++)
            {
                serviceItems.Add(new ServiceItem());
            }

        }

        public Client(int numServiceItems, Store s)
        {
            this.id = CUSTOMERID;
            CUSTOMERID++;
            this.inQueue = false;
            this.timeEnteredStore = Timer.getTick();
            this.timeEnteredQueue = -1;
            this.state = STATES.WAIT_TO_QUEUE;
            this.serviceItems = new List<ServiceItem>();
            this.GenerateServiceItems(numServiceItems);
            
            this.strategies = new List<ClientStrategy>();
            this.strategies.Add(new SmallestQueueStrategy(s, this));
            this.strategies.Add(new FewestItemsStrategy(s, this));
            this.currentStrategy = 0;

            patience = Configs.CLIENT_CHANGE_QUEUE_INTERVAL + (new Random()).Next(180);
            this.store = s;


        }
        public void Update(Store store)
        {
            bool finished = false;

            do
            {
                switch (state)
                {
                    // If it's waited the amount of time needed to enter  the queue, then enter the queue.
                    case STATES.WAIT_TO_QUEUE:
                        if (this.isReadyForQueue())
                        {
                            this.timeEnteredQueue = Timer.getTick();
                            store.AddClientToWaitQueue(this, this.chooseStoreWaitingQueue());
                            this.state = STATES.IN_WQ;
                            this.startWQTime = Timer.getTick();
                        }
                        else
                        {
                            finished = true;
                        }
                        break;

                    case STATES.IN_WQ:
                        if (store.getQueuePosition(this) == 0)
                        {
                            this.state = STATES.FRONT_WQ;
                        }
                        else
                        {
                            finished = true;
                        }
                        break;

                    case STATES.FRONT_WQ:
                        if (this.goToOptimalServicePoint(store))
                        {
                            this.startSQTime = Timer.getTick();
                            this.state = STATES.IN_CASH;
                        }
                        else
                        {
                            finished = true;
                        }
                        break;

                    case STATES.IN_CASH:
                        if (this.startSQTime + this.patience < Timer.getTick())
                        {
                            int index = determineBetterServicePoint(store);
                            if (index != -1)
                            {

                            }
                        }
                        finished = true;
                        break;

                    case STATES.FRONT_CASH:
                        finished = true;
                        break;

                }
            }
            while (!finished);

        }

        public List<ClientStrategy> getStrategies()
        {
            return this.strategies;
        }

        public void startPurchase()
        {
            this.startPurchaseTime = Timer.getTick();
        }

        public StoreQueue chooseStoreWaitingQueue()
        {
            List<StoreQueue> queues = this.store.getWaitQueues();
            StoreQueue choice = null;
            int minItems = Configs.MAX_ITEMS_PER_CLIENT;

            foreach (StoreQueue q in queues)
            {
                if (q.AcceptClient(this))
                {
                    if (minItems >= q.getMinItems())
                    {
                        choice = q;
                        minItems = q.getMinItems();
                    }
                }
            }

            return choice;
        }
            
        public void MoveToQueue(StoreQueue queue)
        {
            this.RemoveFromCurrentQueue();
            queue.AddClient(this);
        }

        public bool InQueue()
        {
            return (this.currentQueue != null);
        }

        public void RemoveFromCurrentQueue()
        {
            this.currentQueue.Remove(this);
            this.currentQueue = null;
        }

        public bool isFinishedPurchase(int timePerItem)
        {
            if ((Timer.getTick() - this.startPurchaseTime) == timePerItem * this.getNumItems() + Configs.PAY_TIME)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // When the customer strategy is implemented, put it in this part
        public bool goToOptimalServicePoint(Store store)
        {
            List<ServicePoint> spList = store.CheckForAvailableCashes(this);
            
            if (spList.Count > 0)
            {
                ServicePoint s = strategies.ElementAt(this.currentStrategy).selectServicePoint(spList);
                store.MoveClientToCash(this, s);
                return true;
            }
            else
            {
                return false;
            }
        }

        private int determineBetterServicePoint(Store store)
        {
            List<ServicePoint> sps = store.getServicePoints();
            int index = -1;
            ServicePoint curSP = store.getWhichServicePointAt(this);
            int curConstraint = curSP.getClients().IndexOf(this);
            int size = 10000000;

            if (strategies.ElementAt(this.currentStrategy).getStrategyType() == 1)
            {
                int t = 0;
                List<Client> clients = curSP.getClients();
                for (int i = 0; i < curConstraint; i++)
                {
                    t += clients.ElementAt(i).getNumItems();
                }
                curConstraint = t;
            }

            foreach (ServicePoint s in sps)
            {
                switch (strategies.ElementAt(this.currentStrategy).getStrategyType())
                {
                    case 0:
                        if (s.getClients().Count < size && s.CanService(this))
                        {
                            index = s.getId();
                            size = s.getClients().Count;
                        }
                        break;
                    case 1:
                        if (s.getTotalItems() < size && s.CanService(this))
                        {
                            index = s.getId();
                            size = s.getTotalItems();
                        }
                        break;
                }
            }

            if (curSP.getId() == index)
            {
                return -1;
            }
            return index;
        }

        public void setWaitQueueStatus()
        {
            this.state = STATES.IN_WQ;
        }

        public void setFrontOfWaitQueueStatus()
        {
            this.state = STATES.FRONT_WQ;
        }

        public bool isReadyForQueue()
        {
            return ((Timer.getTick() - this.getTimeEnteredStore()) >= this.getNumItems() * Configs.TICKS_PER_ITEM);
        }

        public override string ToString()
        {
            return "Client" + this.id;
        }

        public int getId() { return id; }
        public long getTimeEnteredQueue() { return timeEnteredQueue; }
        public long getTimeEnteredStore() { return timeEnteredStore; }
        public bool getInQueue() { return inQueue; }
        public int getNumItems() { return serviceItems.Count; }

    }
}
