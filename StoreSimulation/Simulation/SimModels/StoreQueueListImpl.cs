using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace StoreSimulation.SimModels
{
    public class StoreQueueListImpl : StoreQueue
    {
        List<ServicePoint> service_points;
        List<Client> clients;
        int maxClients;
        int maxItems;
        StoreQueue parent;
        String type;

        public StoreQueueListImpl(string type, int maxClients)
        {
            service_points = new List<ServicePoint>();
            clients = new List<Client>();
            this.maxClients = maxClients;
            this.maxItems = Configs.MAX_ITEMS_PER_CLIENT;
            this.type = type;
        }

        public override Client GetNext()
        {
            if (this.GetSize() > 0)
            {
                Client c = this.clients.ElementAt(0);
                this.clients.Remove(c);
                return c;
            }

            return null;
        }

        public override Client PeekNext()
        {
            if (this.GetSize() > 0)
            {
                return this.clients.ElementAt(0);
            }

            return null;
        }

        public override void SetParent(StoreQueue parent)
        {
            this.parent = parent;
        }

        public override void RemoveParent()
        {
            this.parent = null;
        }

        public override StoreQueue GetParent()
        {
            return this.parent;
        }

        public override void AddClient(Client c)
        {
            this.clients.Add(c);
            c.currentQueue = this;
        }

        public override void AddClientInFront(Client c)
        {
            this.clients.Insert(0, c);
        }

        public override void RemoveAt(int index)
        {
            this.clients.RemoveAt(index);
        }

        public override void Remove(Client c)
        {
            this.clients.Remove(c);
        }

        public override bool AcceptClient(Client c)
        {
            foreach (ServicePoint s in this.service_points)
            {
                if (c.getNumItems() > s.getMaxItems())
                {
                    return false;
                }
            }

            if (this.IsFull() && this.maxClients != -1)
            {
                return false;
            }

            return true;
        }

        public override List<Client> getClients()
        {
            return this.clients;
        }

        public override List<ServicePoint> getAvailableServicePoints()
        {
            return this.service_points;
        }

        public override void AddServicePoint(ServicePoint s)
        {
            this.service_points.Add(s);
            s.getQueue().SetParent(this);
            if (s.getMaxItems() > this.maxItems)
            {
                this.maxItems = s.getMaxItems();
            }
        }

        public override void RemoveServicePoint(ServicePoint s)
        {
            s.getQueue().RemoveParent();
            this.service_points.Remove(s);
        }

        public override bool IsFull()
        {
            if (this.clients.Count < this.maxClients)
            {
                return false;
            }

            return true;
        }

        public override int GetSize()
        {
            return this.clients.Count;
        }

        public override void setMaxClients(int maxClients)
        {
            this.maxClients = maxClients;
        }

        public override int getMaxClients()
        {
            return this.maxClients;
        }

        public override void setMaxItems(int maxItems)
        {
            this.maxItems = maxItems;
        }

        public override int getMaxItems()
        {
            return this.maxItems;
        }

        public override int getMinItems()
        {
            int min = this.maxItems;
            foreach (ServicePoint s in this.service_points)
            {
                if (min > s.getMaxItems())
                {
                    min = s.getMaxItems();
                }
            }

            return min;
        }

        public override int IndexOf(Client c)
        {
            return this.clients.IndexOf(c);
        }

        public override bool ContainsServicePoint(ServicePoint sp)
        {
            foreach (ServicePoint s in this.service_points)
            {
                if (s == sp)
                {
                    return true;
                }
            }

            return false;
        }

        public override string ToString()
        {
            return this.type + "_Queue";
        }
    }
}
