    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StoreSimulation.SimModels;

namespace StoreSimulation.SimModels.Strategies
{
    class QueueSizeStrategy : SupervisorStrategy
    {

        public QueueSizeStrategy(Store s) : base(s, "QueueSizeStrategy")
        {
        }

        public override bool checkForOpenPointNeeded()
        {
            List<StoreQueue> list = store.getWaitQueues();

            foreach (StoreQueue s in list)
            {
                if (s.getClients().Count > Configs.MAX_QUEUE_SIZE)
                    return true;
            }
            return false;

        }

        // Will return true (need to close a service point) when the total number of clients in the wait queue and the cashes are fewer than the 
        // number of cashes * the max number of clients in each cash
        public override bool checkForClosePointNeeded()
        {
            int totalNumberOfClients = 0;
            List<StoreQueue> list1 = store.getWaitQueues();
            List<ServicePoint> list2 = store.getServicePoints();

            foreach (StoreQueue sq in list1)
            {
                totalNumberOfClients = 0;
                foreach (ServicePoint s in list2)
                    totalNumberOfClients += s.getClients().Count;
                totalNumberOfClients += sq.getClients().Count;

                if (totalNumberOfClients <= list2.Count * Configs.MAX_CLIENTS_PER_CASH)
                    return true;
            }
            return false;
        }

        public override string  ToString()
        {
 	         return this.name;
        }

    }
}
