using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StoreSimulation.SimModels;


namespace StoreSimulation.SimModels.Strategies
{
    public class SupervisorStrategy
    {
        protected Store store;
        public String name;

        public SupervisorStrategy(Store s, string name)
        {
            store = s;
            this.name = name;
        }

        virtual public bool checkForOpenPointNeeded() { return false; }
        virtual public bool checkForClosePointNeeded() { return false; }

        public override string ToString()
        {
            return this.name;
        }
    }

}
