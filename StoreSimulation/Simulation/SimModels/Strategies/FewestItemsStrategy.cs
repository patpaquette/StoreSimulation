using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StoreSimulation.SimModels;

namespace StoreSimulation.SimModels.Strategies
{
    class FewestItemsStrategy : ClientStrategy
    {
        private Store store;
        private Client client;

        public FewestItemsStrategy() { }
        public FewestItemsStrategy(Store s, Client c)
        {
            store = s;
            client = c;
            type = 1;
        }

        private int totalItems(ServicePoint s)
        {
            int ti = 0;

            foreach (Client c in s.getClients())
            {
                ti += c.getNumItems();
            }

            return ti;
        }

        public override ServicePoint selectServicePoint(List<ServicePoint> spList)
        {
            List<ServicePoint> sps = spList;
            int smallest = 1000000;
            int index = -1;
            ServicePoint ret = null;

            foreach (ServicePoint s in sps)
            {
                if (totalItems(s) < smallest && s.CanService(client))
                {
                    smallest = totalItems(s);
                    ret = s;
                }
            }

            return ret;
        }

    }
}
