using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StoreSimulation.SimModels;

namespace StoreSimulation.SimModels
{
    public abstract class StoreQueue
    {
        abstract public Client GetNext();
        abstract public Client PeekNext();
        abstract public void AddClient(Client c);
        abstract public void AddClientInFront(Client c);
        abstract public void RemoveAt(int index);
        abstract public void Remove(Client c);
        abstract public bool AcceptClient(Client c);
        abstract public List<Client> getClients();
        abstract public List<ServicePoint> getAvailableServicePoints();
        abstract public void AddServicePoint(ServicePoint s);
        abstract public void RemoveServicePoint(ServicePoint s);
        abstract public bool IsFull();
        abstract public int GetSize();
        abstract public void setMaxClients(int maxClients);
        abstract public int getMaxClients();
        abstract public void setMaxItems(int maxItems);
        abstract public int getMaxItems();
        abstract public int getMinItems();
        abstract public int IndexOf(Client c);
        abstract public bool ContainsServicePoint(ServicePoint sp);
        abstract public void SetParent(StoreQueue parent);
        abstract public void RemoveParent();
        abstract public StoreQueue GetParent();
    }
}
