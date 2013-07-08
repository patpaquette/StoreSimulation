using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StoreSimulation.SimModels;

namespace StoreSimulation.SimModels.Strategies
{
    class ArrivalRateStrategy: SupervisorStrategy
    {

        public ArrivalRateStrategy(Store s) : base(s, "ArrivalRateStrategy")
        {
        }

        private double computeAverageArrivalRate()
        {
            List<ServicePoint> sps = store.getServicePoints();
            double averageArrivalRate = 0.0f;

            foreach (ServicePoint sp in sps)
            {
                averageArrivalRate += sp.computeArrivalRate();
            }

            averageArrivalRate /= sps.Count;

            return averageArrivalRate;
        }

        public override bool checkForOpenPointNeeded()
        {
            
            if (this.computeAverageArrivalRate() > Configs.SERVICE_ARRIVAL_RATE_THRESHOLD_OPEN)
                return true;
            return false;
        }
        public override bool checkForClosePointNeeded() 
        {
            if (this.computeAverageArrivalRate() < Configs.SERVICE_ARRIVAL_RATE_THRESHOLD_CLOSE)
                return true;
            return false; 
        }

        public override string  ToString()
        {
 	         return this.name;
        }
    }
}
