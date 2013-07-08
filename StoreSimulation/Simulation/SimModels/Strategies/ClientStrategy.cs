using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StoreSimulation.SimModels;


namespace StoreSimulation.SimModels.Strategies
{
    public abstract class ClientStrategy
    {
        Store store;
        Client client;
        protected int type;

        public ClientStrategy() { }
        public ClientStrategy(Store s, Client c)
        {
            store = s;
            client = c;
            type = -1;
        }
        public int getStrategyType() { return type; }

        abstract public ServicePoint selectServicePoint(List<ServicePoint> spList);
    }
}