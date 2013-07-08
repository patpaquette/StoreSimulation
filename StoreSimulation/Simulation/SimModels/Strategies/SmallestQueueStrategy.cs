using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StoreSimulation.SimModels;

namespace StoreSimulation.SimModels.Strategies
{
    class SmallestQueueStrategy : ClientStrategy
    {
        private Store store;
        private Client client;

        public SmallestQueueStrategy() { }
        public SmallestQueueStrategy(Store s, Client c)
        {
            store = s;
            client = c;
            type = 0;
        }

        public override ServicePoint selectServicePoint(List<ServicePoint> spList)
        {
            List<ServicePoint> sps = spList;
            int fewest = 1000000;
            ServicePoint ret = null;

            foreach (ServicePoint s in sps)
            {
                if (s.getClients().Count < fewest && s.CanService(client))
                {
                    fewest = s.getClients().Count;
                    ret = s;
                }
            }

            return ret;
        }

    }
}
