using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StoreSimulation.SimModels;

namespace StoreSimulation.SimModels
{
    //misc event arguments formats
    public class ClientEventArgs : EventArgs
    {
        public Client client;
        public long tick;
        public StoreQueue queue;

        public ClientEventArgs(Client c, long tick, StoreQueue queue)
        {
            this.client = c;
            this.queue = queue;
            this.tick = tick;
        }
    }

    public class ClientServicePointEventArgs : ClientEventArgs
    {
        public ServicePoint servicePoint;

        public ClientServicePointEventArgs(Client c, long tick, ServicePoint sp) : base(c, tick, sp.getQueue())
        {
            this.servicePoint = sp;
        }
    }

    public class ServicePointArgs
    {
        public ServicePoint servicePoint;
        public long tick;

        public ServicePointArgs(ServicePoint sp, long t)
        {
            servicePoint = sp;
            tick = t;
        }

    }

    public struct SPStoreArg{
        public SPStoreArg(int entranceHours, int entranceMins, int entranceSecs, string type, int maxQueueSize, int maxItems, int itemProcessingTime, string queue_type)
        {
            this.entranceHours = entranceHours;
            this.entranceMins = entranceMins;
            this.entranceSecs = entranceSecs;
            this.type = type;
            this.maxQueueSize = maxQueueSize;
            this.maxItems = maxItems;
            this.itemProcessingTime = itemProcessingTime;
            this.queue_type = queue_type;
        }

        public string queue_type;
        public int entranceHours;
        public int entranceMins;
        public int entranceSecs;
        public string type;
        public int maxQueueSize;
        public int maxItems;
        public int itemProcessingTime;
    }

    public struct ClientStoreArg
    {
        public ClientStoreArg(int numClients, int entranceHours, int entranceMins, int entranceSecs, int numItems)
        {
            this.numClients = numClients;
            this.entranceHours = entranceHours;
            this.entranceMins = entranceMins;
            this.entranceSecs = entranceSecs;
            this.numItems = numItems;
        }

        public int entranceHours;
        public int numClients;
        public int entranceMins;
        public int entranceSecs;
        public int numItems;
    }

    public struct QueueStoreArg
    {
        public QueueStoreArg(string type, int queueSize)
        {
            this.type = type;
            this.queueSize = queueSize;
        }

        public int queueSize;
        public string type;
    }

}
