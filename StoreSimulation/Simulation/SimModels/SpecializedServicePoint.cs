using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StoreSimulation.SimModels;

namespace StoreSimulation.SimModels
{
    class SpecializedServicePoint: ServicePoint
    {
        private int maxQueueSize;
        private int itemProcessingTime;

        public SpecializedServicePoint(int i, Store store, string type, int maxQueueSize, int maxItems, int itemProcessingTime) : base(i, store)
        {
            this.maxQueueSize = maxQueueSize;
            this.maxItems = maxItems;
            this.type = type;
            this.itemProcessingTime = itemProcessingTime;
            this.queue.setMaxClients(maxQueueSize);
        }

        public override bool CanService(Client c)
        {
            if (c.getNumItems() > maxItems)
            {
                return false;
            }

            if (this.queue.GetSize() >= maxQueueSize)
            {
                return false;
            }

            return true;
        }

        public override bool isFull()
        {
            return this.queue.IsFull();
        }

        public override int getItemProcessingTime()
        {
            return this.itemProcessingTime;
        }
    }
}
