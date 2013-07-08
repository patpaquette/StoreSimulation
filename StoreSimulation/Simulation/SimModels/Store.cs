using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StoreSimulation.SimModels;

namespace StoreSimulation.SimModels
{
    public class Store
    {
        List<Client> clients;
        List<StoreQueue> queues;
        StoreQueue mainQueue;
        Supervisor supervisor;
        List<ServicePoint> service_points;
        //List<Client> waitQueue;
        int numOpenQueues;
        int previousChoice = -1;


        public Store()
        {
            clients = new List<Client>();

            this.queues = new List<StoreQueue>();
            this.mainQueue = new StoreQueueListImpl("MainQueue", Configs.MAX_ITEMS_PER_CLIENT);
            this.queues.Add(this.mainQueue);
            supervisor = new Supervisor(this);
            service_points = new List<ServicePoint>();
            //waitQueue = new List<Client>();
            supervisor = new Supervisor(this);
            
            /*for (int i = 0; i < this.getServicePoints().Count; i++)
            {
                this.getServicePoints().ElementAt(i).ClientExitCashier += new ServicePoint.ClientExitCashierEventHandler(ClientExitServicePoint);
            }*/
        }

        public void init()
        {
            clients = new List<Client>();

            this.queues = new List<StoreQueue>();
            this.mainQueue = new StoreQueueListImpl("MainQueue", Configs.MAX_ITEMS_PER_CLIENT);
            this.queues.Add(this.mainQueue);
            supervisor = new Supervisor(this);
            service_points = new List<ServicePoint>();
            //waitQueue = new List<Client>();
            supervisor = new Supervisor(this);
        }

        public void Update()
        {
            supervisor.Update();

            foreach (ServicePoint s in service_points)
                s.Update();
            foreach (Client c in clients)
                c.Update(this);


            //System.Diagnostics.Debug.WriteLine("Size of client array : " + this.clients.Count);
        }
        public List<ServicePoint> CheckForAvailableCashes(Client c)
        {
            //int toReturn = -1;
            //int minimumQueueSize = 1000;
            //int count = 0;
            //List<int> possibilities = new List<int>();
            List<ServicePoint> spList = new List<ServicePoint>();

            foreach (ServicePoint s in c.currentQueue.getAvailableServicePoints())
            {
                /*// if the cash is empty then just return that immediately
                if (s.getClients().Count == 0)
                    return count;
                // if the size of the queue is smaller than the available spots and 
                if (!s.isFull())       // Will probably want to take into account average wait times or something
                {                                                                             // but for now this is fine. (Goes to the one with the smallest line)
                    possibilities.Add(count);
                    toReturn = count;
                    minimumQueueSize = s.getClients().Count;
                }
                count++;
            }

            if (possibilities.Count > 1)
            {
                if (previousChoice == 0)
                {
                    previousChoice = 1;
                    return 1;
                }
                else
                {
                    previousChoice = 0;
                    return 0;
                }*/

                if (s.CanService(c))
                {
                    spList.Add(s);
                }
            }
            return spList;

        }

        // takes client from the wait queue and moves it to the cash at "index"
        public void MoveClientToCash(Client c, ServicePoint sp)
        {
            int index = this.service_points.IndexOf(sp);
            this.RemoveClientFromWaitQueue(c);
            service_points.ElementAt(index).AddClient(c);
            //Logger.Info("Added customer " + c.getId().ToString() + " to the " + index.ToString() + " cash at " + DateTime.Now.ToString());
        }

        public void OpenStore()
        {
            Logger.Output("Store is opened");
            int x;
            for (x = 0; x < Configs.INITIAL_SERVICE_POINTS; x++)
            {
                supervisor.OpenServicePoint(this.mainQueue);
            }

        }

        public void CloseStore()
        {
            Logger.Output("Store is closed");
        }

        public int AddClientToWaitQueue(Client c, StoreQueue queue)
        {

            if (queue != null)
            {
                //waitQueue.Add(c);
                queue.AddClient(c);

                OnClientAddedToQueue(new ClientEventArgs(c, Timer.getTick(), c.currentQueue));

                //index = waitQueue.IndexOf(c);

                if (queue.PeekNext() == c)
                {
                    this.OnClientInFrontOfQueue(new ClientEventArgs(c, Timer.getTick(), c.currentQueue));
                }
                return queue.IndexOf(c);
                //Logger.Info("Added client " + c.getId().ToString() + " to the wait queue at " + DateTime.Now.ToString());
            }
            return -1;
        }


        public void RemoveClientFromWaitQueue(Client c)
        {
            //Logger.Info("Removed client " + waitQueue.ElementAt(0).getId().ToString() + " from the wait queue at " + DateTime.Now.ToString());
            //waitQueue.Remove(c);

            //queue.Remove(c);
            if (c.InQueue())
            {
                StoreQueue queue = c.currentQueue;
                c.RemoveFromCurrentQueue();

                OnClientRemovedFromQueue(new ClientEventArgs(c, Timer.getTick(), queue));

                if (queue.GetSize() > 0)
                {
                    this.OnClientInFrontOfQueue(new ClientEventArgs(queue.PeekNext(), Timer.getTick(), queue));
                }
            }
        }

        public void AddQueue(StoreQueue queue)
        {
            this.queues.Add(queue);
        }

        public StoreQueue getMainQueue()
        {
            return this.mainQueue;
        }

        public void AddClient(int numItems)
        {
            Client c = new Client(numItems, this);
            clients.Add(c);
            OnClientEnteredStore(new ClientEventArgs(c, Timer.getTick(), null));
            //Logger.Info("A new client has entered the store at: " + DateTime.Now.ToString());
        }

        public void RemoveClient(Client c)
        {
            //Logger.Info("A client has left the store at: " + DateTime.Now.ToString() + ", whos ID was " + clients.ElementAt(index).getId().ToString());
            clients.Remove(c);
            OnClientLeftStore(new ClientEventArgs(c, Timer.getTick(), null));
        }

        public void AddServicePoint(ServicePoint sp)
        {
            if(this.service_points.Count < Configs.MAX_SERVICE_POINTS){
                this.service_points.Add(sp);
            }
        }

        public void RemoveServicePoint(ServicePoint sp)
        {
            this.service_points.Remove(sp);
            foreach (StoreQueue q in this.queues)
            {
                foreach (ServicePoint s in q.getAvailableServicePoints())
                {
                    if (s == sp)
                    {
                        q.getAvailableServicePoints().Remove(s);
                        break;
                    }
                }
            }
        }

        public bool AllCashesFull()
        {
            foreach (ServicePoint sp in service_points)
            {
                if (!sp.isFull())
                    return false;
            }

            return true;
        }

        public int getQueuePosition(Client c)
        {
            if (c.currentQueue != null)
            {
                return c.currentQueue.IndexOf(c);
            }
         
            return -1;

        }

        public ServicePoint getWhichServicePointAt(Client client)
        {
            foreach (ServicePoint s in service_points)
            {
                foreach (Client c in s.getClients())
                {
                    if (client.getId() == c.getId())
                    {
                        return s;
                    }
                }
            }
            return null;
        }

        public bool isEmpty()
        {
            if (this.clients.Count == 0) return true;
            return false;
        }

        public List<ServicePoint> getServicePoints() { return service_points; }
        public List<StoreQueue> getWaitQueues() { return this.queues; }
        public Supervisor getSupervisor() { return this.supervisor; }
        public List<Client> getClients() { return this.clients; }



        //event listeners
        private void ClientExitServicePoint(Object sender, ClientServicePointEventArgs args)
        {
            this.RemoveClient(args.client);
        }


        //events definitions
        //event that fires when a client is added to a waiting queue
        public delegate void ClientAddedToQueueEventHandler(object sender, ClientEventArgs e);
        public event ClientAddedToQueueEventHandler ClientAddedToQueue;
        protected void OnClientAddedToQueue(ClientEventArgs e)
        {
            if (ClientAddedToQueue != null)
            {
                ClientAddedToQueue(this, e);
            }
        }

        //event that fires when a client is removed from a waiting queue
        public delegate void ClientRemovedFromQueueEventHandler(object sender, ClientEventArgs e);
        public event ClientRemovedFromQueueEventHandler ClientRemovedFromQueue;
        protected void OnClientRemovedFromQueue(ClientEventArgs e)
        {
            if (ClientRemovedFromQueue != null)
            {
                ClientRemovedFromQueue(this, e);
            }
        }

        //event that fires when a client is removed from a waiting queue
        public delegate void ClientInFrontOfQueueEventHandler(object sender, ClientEventArgs e);
        public event ClientInFrontOfQueueEventHandler ClientInFrontOfQueue;
        protected void OnClientInFrontOfQueue(ClientEventArgs e)
        {
            if (ClientInFrontOfQueue != null)
            {
                ClientInFrontOfQueue(this, e);
            }
        }

        //event when a client enters the store
        public delegate void ClientEnteredStoreEventHandler(object sender, ClientEventArgs e);
        public event ClientEnteredStoreEventHandler ClientEnteredStore;
        protected void OnClientEnteredStore(ClientEventArgs e)
        {
            if (ClientEnteredStore != null)
            {
                ClientEnteredStore(this, e);
            }

        }

        //event when a client leaves the store
        public delegate void ClientLeftStoreEventHandler(object sender, ClientEventArgs e);
        public event ClientLeftStoreEventHandler ClientLeftStore;
        protected void OnClientLeftStore(ClientEventArgs e)
        {
            if (ClientLeftStore != null)
            {
                ClientLeftStore(this, e);
            }

        }

        // Used for when the calling object is not in the store class
        public void fireServicePointOpenedEvent(ServicePoint sp)
        {
            OnServicePointOpened(new ServicePointArgs(sp, Timer.getTick()));
        }


        //event when a service port is opened
        public delegate void ServicePointOpenedEventHandler(object sender, ServicePointArgs e);
        public static event ServicePointOpenedEventHandler ServicePointOpened;
        protected void OnServicePointOpened(ServicePointArgs e)
        {
            if (ServicePointOpened != null)
            {
                ServicePointOpened(this, e);
            }

        }

        // Used for when the calling object is not in the store class
        public void fireServicePointClosedEvent(ServicePoint sp)
        {
            OnServicePointClosed(new ServicePointArgs(sp, Timer.getTick()));
        }


        //event when a service port is opened
        public delegate void ServicePointClosedEventHandler(object sender, ServicePointArgs e);
        public static event ServicePointClosedEventHandler ServicePointClosed;
        protected void OnServicePointClosed(ServicePointArgs e)
        {
            if (ServicePointClosed != null)
            {
                ServicePointClosed(this, e);
            }

        }



    }
}
