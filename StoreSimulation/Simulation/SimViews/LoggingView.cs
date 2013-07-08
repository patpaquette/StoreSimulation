using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StoreSimulation.SimModels;
using System.IO;

namespace StoreSimulation.Simulation.SimViews
{
    class LoggingView
    {
        private StoreSimulation.SimModels.Simulation sim;
        private TextWriter output;
        public LoggingView(StoreSimulation.SimModels.Simulation sim, TextWriter output)
        {
            this.sim = sim;
            this.output = output;
            Logger.changeOutput(this.output);

            //adding event listeners
            this.sim.getStore().ClientAddedToQueue += new Store.ClientAddedToQueueEventHandler(ClientAddedToQueue);
            this.sim.getStore().ClientRemovedFromQueue += new Store.ClientRemovedFromQueueEventHandler(ClientRemovedFromQueue);
            this.sim.getStore().ClientInFrontOfQueue += new Store.ClientInFrontOfQueueEventHandler(ClientInFrontOfQueue);
            this.sim.getStore().ClientEnteredStore += new Store.ClientEnteredStoreEventHandler(ClientEnteredStore);
            this.sim.getStore().ClientLeftStore += new Store.ClientLeftStoreEventHandler(ClientLeftStore);
            Store.ServicePointOpened += new Store.ServicePointOpenedEventHandler(ServicePointOpened);
            Store.ServicePointClosed += new Store.ServicePointClosedEventHandler(ServicePointClosed);
            ServicePoint.ClientEnteredCashier += new ServicePoint.ClientEnteredCashierEventHandler(ClientEnteredServicePoint);
            ServicePoint.ClientExitCashier += new ServicePoint.ClientExitCashierEventHandler(ClientExitServicePoint);
            ServicePoint.ClientInFrontOfQueueCashier += new ServicePoint.ClientInFrontOfQueueCashierEventHandler(ClientInFrontOfQueueCashier);
        }

        public void SetSim(StoreSimulation.SimModels.Simulation sim)
        {
            this.sim = sim;
            this.sim.getStore().ClientAddedToQueue += new Store.ClientAddedToQueueEventHandler(ClientAddedToQueue);
            this.sim.getStore().ClientRemovedFromQueue += new Store.ClientRemovedFromQueueEventHandler(ClientRemovedFromQueue);
            this.sim.getStore().ClientInFrontOfQueue += new Store.ClientInFrontOfQueueEventHandler(ClientInFrontOfQueue);
            this.sim.getStore().ClientEnteredStore += new Store.ClientEnteredStoreEventHandler(ClientEnteredStore);
            this.sim.getStore().ClientLeftStore += new Store.ClientLeftStoreEventHandler(ClientLeftStore);
        }
        private void ClientAddedToQueue(Object sender, ClientEventArgs args)
        {
            Logger.Output(this.sim.timeFromTicks(Timer.getTick()) + " - Added " + args.client.ToString() + " to the wait queue " + args.queue.ToString());
        }

        private void ClientRemovedFromQueue(Object sender, ClientEventArgs args)
        {
            Logger.Output(this.sim.timeFromTicks(Timer.getTick()) + " - Removed " + args.client.ToString() + " from the wait queue");
        }

        private void ClientInFrontOfQueue(Object sender, ClientEventArgs args)
        {
            Logger.Output(this.sim.timeFromTicks(Timer.getTick()) + " - " + args.client.ToString() + " is in front of the wait queue " + args.client.currentQueue.ToString());
        }

        private void ClientEnteredStore(Object sender, ClientEventArgs args)
        {
            Logger.Output(this.sim.timeFromTicks(Timer.getTick()) + " - " + args.client.ToString() + " entered store and buys " + args.client.getNumItems() + " items");
        }

        private void ClientLeftStore(Object sender, ClientEventArgs args)
        {
            Logger.Output(this.sim.timeFromTicks(Timer.getTick()) + " - " + args.client.ToString() + " left store");
        }

        private void ClientEnteredServicePoint(Object sender, ClientServicePointEventArgs args)
        {
            Logger.Output(this.sim.timeFromTicks(Timer.getTick()) + " - " + args.client.ToString() + " selects " + args.servicePoint.ToString());
        }

        private void ClientExitServicePoint(Object sender, ClientServicePointEventArgs args)
        {
            Logger.Output(this.sim.timeFromTicks(Timer.getTick()) + " - " + args.client.ToString() + " exits " + args.servicePoint.ToString());
        }

        private void ClientInFrontOfQueueCashier(Object sender, ClientServicePointEventArgs args)
        {
            Logger.Output(this.sim.timeFromTicks(Timer.getTick()) + " - " + args.client.ToString() + " is in front of " + args.servicePoint.ToString());
        }

        private void ServicePointOpened(Object sender, ServicePointArgs args)
        {
            Logger.Output(this.sim.timeFromTicks(Timer.getTick()) + " - " + args.servicePoint.ToString() + " has been opened.");
        }

        private void ServicePointClosed(Object sender, ServicePointArgs args)
        {
            Logger.Output(this.sim.timeFromTicks(Timer.getTick()) + " - " + args.servicePoint.ToString() + " has been closed.");
        }
    }

    
}
