using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StoreSimulation;
using StoreSimulation.SimModels.Strategies;

namespace StoreSimulation.SimModels
{
    public class Supervisor
    {
        int maxServicePoints;
        Dictionary<ServicePoint, long> timeLastClientEntered;
        Store store;
        List<SupervisorStrategy> strategies;
        int currentStrategy;

        public Supervisor(Store s)
        {
            store = s;
            timeLastClientEntered = new Dictionary<ServicePoint, long>();
            timeLastClientEntered.Remove(new ServicePoint(10, s));

            strategies = new List<SupervisorStrategy>();
            strategies.Add(new ArrivalRateStrategy(store));
            strategies.Add(new QueueSizeStrategy(store));
            //Store.ServicePointOpened += new Store.ServicePointOpenedEventHandler(OpenedCash);
            this.currentStrategy = 0;
            this.store = s;
        }

        public void Update()
        {
            if (Timer.getTick() % Configs.SUPERVISOR_CHECK_INTERVAL == 0)
            {
                if (store.getServicePoints().Count > Configs.MIN_SERVICE_POINTS && strategies[this.currentStrategy].checkForClosePointNeeded())
                    CloseServicePoint();
                else if (store.getServicePoints().Count < Configs.MAX_SERVICE_POINTS && strategies[this.currentStrategy].checkForOpenPointNeeded())
                    OpenServicePoint(this.store.getMainQueue());
            }
        }

        public List<SupervisorStrategy> getStrategies()
        {
            return this.strategies;
        }

        public void changeStrategy(int index)
        {
            if (index < this.strategies.Count)
            {
                this.currentStrategy = index;
            }
        }
        public int DetermineServPointNumber()
        {
            int toReturn = -1;
            List<ServicePoint> list = store.getServicePoints();


            // Loop to loop through each of the service points in the list, and check for the lowest cash that is not in the service point list (ie that is open)
            for (int i = 0; i < Configs.MAX_SERVICE_POINTS; i++)
            {
                toReturn = i;
                for (int j = 0; j < list.Count; j++)
                {
                    if (i == list.ElementAt(j).getId())
                    {
                        toReturn = -1;
                        break;
                    }
                }

                if (toReturn != -1)
                    break;
            }
            return toReturn;
        }

        public ServicePoint DetermineServicePointToClose()
        {
            int lowest = 100000000;
            int index = -1;
            int x = 0;

            foreach (ServicePoint sp in store.getServicePoints())
            {
                if (sp.getClients().Count == 0)
                {
                    return sp;
                }

                else if (sp.getClients().Count < lowest)
                {
                    lowest = sp.getClients().Count;
                    index = x;
                }
                x++;
            }

            return store.getServicePoints().ElementAt(index);
        }

        public ServicePoint OpenServicePoint(StoreQueue queue)
        {
            int toOpen = DetermineServPointNumber();
            ServicePoint s = new ServicePoint(toOpen, store);
            queue.AddServicePoint(s);
            if (!this.store.getWaitQueues().Contains(queue))
            {
                this.store.AddQueue(queue);
            }
            store.AddServicePoint(s);
            store.fireServicePointOpenedEvent(s);

            return s;
        }

        public ServicePoint OpenSpecializedServicePoint(string type, int maxQueueSize, int maxItems, int itemProcessingTime, StoreQueue queue)
        {
            int toOpen = DetermineServPointNumber();
            ServicePoint s = new SpecializedServicePoint(toOpen, this.store, type, maxQueueSize, maxItems, itemProcessingTime);
            store.AddServicePoint(s);
            store.fireServicePointOpenedEvent(s);
            return s;
        }

        public void CloseServicePoint()
        {
            ServicePoint sp = DetermineServicePointToClose();
            store.RemoveServicePoint(sp);
            MoveClients(sp.getClients(), sp.getQueue());
            store.fireServicePointClosedEvent(sp);
        }

        public long DetermineAverageQueueTime()         // To be used to determine the average time in ticks, which can be compared to some
        {                                               // metric to determine whether or not a cash will close/open
            return 0;
        }

        public void MoveClients(List<Client> clients, StoreQueue backup)                        // Transfer clients from one cash to another (not sure what parameters are needed yet)
        {
            List<ServicePoint> sp = store.getServicePoints();


            // Since there could possibly be more clients int he queue removed than total number of service points
            while (clients.Count != 0)
            {

                // If the cashes are all full, then insert the remaining clients into the front of the wait queue
                if (store.AllCashesFull())
                {
                    clients.ElementAt(0).setWaitQueueStatus();
                    List<Client> toMove = new List<Client>();
                    foreach (Client c in clients)
                    {
                        toMove.Add(c);
                    }

                    foreach (Client c in toMove)
                    {
                        c.setWaitQueueStatus();
                        backup.AddClientInFront(c);
                    }
                    backup.PeekNext().setFrontOfWaitQueueStatus();
                    break;
                }

                foreach (ServicePoint s in sp)
                {
                    if (clients.Count == 0)
                        break;

                    if (!s.isFull())
                    {
                        Client c = clients.ElementAt(0);
                        if (s.CanService(c))
                        {
                            clients.RemoveAt(0);
                            s.AddClient(c);
                        }
                    }
                }


            }
        }

        public void MoveClientsToCash(ServicePoint sp)
        {
           /* if (c.currentQueue.GetSize() > 0)
            {
                while (sp.getClients().Count < Configs.MAX_CLIENTS_PER_CASH)
                {
                    if (store.getWaitingQueueSize() > 0)
                    {
                        Client c = store.getWaitQueue().ElementAt(0);
                        store.getWaitQueue().RemoveAt(0);
                        sp.AddClient(c);
                    }

                    else                             // Fail safe in case the wait queue ends up not having anyone in there when trying to fill up a new cash
                    {
                        break;
                    }
                }
            }*/

            List<Client> toMove = new List<Client>();

            foreach (StoreQueue queue in this.store.getWaitQueues())
            {
                if (queue.ContainsServicePoint(sp))
                {
                    foreach (Client c in queue.getClients())
                    {
                        if (sp.CanService(c))
                        {
                            toMove.Add(c);
                        }
                    }
                }
            }

            foreach (Client c in toMove)
            {
                c.MoveToQueue(sp.getQueue());
            }

        }

        public void OpenedCash(Object sender, ServicePointArgs args)
        {
            // args.servicePoint.ClientEnteredCashier += new ServicePoint.ClientEnteredCashierEventHandler(ClientAddedToServicePoint);
            MoveClientsToCash(args.servicePoint);
        }

    }
}
