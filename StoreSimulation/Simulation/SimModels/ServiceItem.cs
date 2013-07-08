using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoreSimulation.SimModels
{
    class ServiceItem
    {
        static int SERVICE_ITEM_ID = 0;
        int id;

        public ServiceItem()
        {
            id = SERVICE_ITEM_ID++;
        }
    }
}
