using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using StoreSimulation.SimModels;
using StoreSimulation.Simulation.SimViews;
using System.Threading;
using StoreSimulation.SimModels.Strategies;

namespace StoreSimulation
{
    public partial class MainView : Form
    {
        StoreSimulation.SimModels.Simulation sim;
        List<ClientStoreArg> client_args;
        List<SPStoreArg> SP_args;
        TextBoxStreamWriter output = null;
        LoggingView simView = null;
        Thread simulationThread;

        public MainView()
        {
            InitializeComponent();
            client_args = new List<ClientStoreArg>();
            SP_args = new List<SPStoreArg>();
            output = new TextBoxStreamWriter(this.tbOutput);
            sim = new StoreSimulation.SimModels.Simulation();
            simView = new LoggingView(sim, (System.IO.TextWriter)output);
            Timer.TimerTicked += new Timer.TimerTickedEventHandler(updateTimerLbl);

            this.init();

            //event handlers
            //Store.ServicePointOpened += new Store.ServicePointOpenedEventHandler(onServicePointCreatedHandler);
        }

        public void init()
        {
            cbSupStrats.Items.Clear();
            lbQueues.Items.Clear();
            tbOutput.Clear();
            Timer.Reset();
            Client.CUSTOMERID = 0;

            client_args = new List<ClientStoreArg>();
            SP_args = new List<SPStoreArg>();
            output = new TextBoxStreamWriter(this.tbOutput);
            sim = new StoreSimulation.SimModels.Simulation();
            simView.SetSim(sim);

            List<SupervisorStrategy> strats = this.sim.getStore().getSupervisor().getStrategies();
            foreach (SupervisorStrategy strat in strats)
            {
                this.cbSupStrats.Items.Add(strat.ToString());
            }
            this.cbSupStrats.SelectedIndex = 0;

            lbQueues.Items.Add("MainQueue_Queue");
            lbQueues.SelectedIndex = 0;
        }
        private void updateTimerLbl(Object sender, TimerEventArgs e)
        {
            if (this.lblTimer.InvokeRequired)
            {
                SetTextCallback c = new SetTextCallback(this.SetText);
                this.lblTimer.Invoke(c, new Object[] { this.sim.timeFromTicks(e.tick) });
            }
            else
            {
                this.lblTimer.Text = this.sim.timeFromTicks(e.tick);
            }
            
        }


        private void MainView_Load(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            this.tbOutput.Clear();
            this.simulationThread = new Thread(() => this.sim.Start());
            this.simulationThread.Start();
        }

        private void btnAddClients_Click(object sender, EventArgs e)
        {
            this.sim.AddClientArgument(new ClientStoreArg(  
                                    System.Convert.ToInt16(this.tbNumClients.Text),
                                    System.Convert.ToInt16(this.tbHours.Text),
                                    System.Convert.ToInt16(this.tbTimeMin.Text), 
                                    System.Convert.ToInt16(this.tbTimeSec.Text), 
                                    System.Convert.ToInt16(this.tbNumItems.Text)));

            Logger.Output("Clients added!");
        }

        private void btnAddSP_Click(object sender, EventArgs e)
        {

            string queue_type = this.lbQueues.SelectedItem.ToString();
            this.sim.AddSPArgument(new SPStoreArg(
                                    System.Convert.ToInt16(this.tbCustomSPEntTimeHours.Text),
                                    System.Convert.ToInt16(this.tbCustomSPEntTimeMins.Text),
                                    System.Convert.ToInt16(this.tbCustomSPEntTimeSecs.Text),
                                    tbCustomSPType.Text,
                                    System.Convert.ToInt16(this.tbCustomSPMaxQueueSize.Text),
                                    System.Convert.ToInt16(this.tbCustomSPMaxItems.Text),
                                    System.Convert.ToInt16(this.tbCustomSPtimePerItem.Text),
                                    queue_type));

            Logger.Output("Service point added!");
        }

        private void SetText(string value)
        {
            this.lblTimer.Text = value;
        }
        delegate void SetTextCallback(String value);


        private void btnChangeConfigs_Click(object sender, EventArgs e)
        {
            int ms = (tbFrameTime.Text != "")?Convert.ToInt16(tbFrameTime.Text):-1;
            if (ms >= 0)
            {
                this.sim.setConfigValue(ConfigsList.FRAME_TIME, ms);
            }

            int maxSP = (tbMaxSP.Text != "")?Convert.ToInt16(tbMaxSP.Text):-1;
            if (maxSP > 0)
            {
                this.sim.setConfigValue(ConfigsList.MAX_SERVICE_POINTS, maxSP);
            }

            int minSP = (tbMinSP.Text != "")?Convert.ToInt16(tbMinSP.Text):-1;
            if (minSP > 0)
            {
                this.sim.setConfigValue(ConfigsList.MIN_SERVICE_POINTS, minSP);
            }

            int maxQueueLength = (tbMaxQueueSP.Text != "")?Convert.ToInt16(tbMaxQueueSP.Text):-1;
            if (maxQueueLength > 0)
            {
                this.sim.setConfigValue(ConfigsList.MAX_CLIENTS_PER_CASH, maxQueueLength);
            }
        }

        private void cbSupStrats_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.sim.getStore().getSupervisor().changeStrategy(cbSupStrats.SelectedIndex);
        }


        private void onServicePointCreatedHandler(Object sender, ServicePointArgs e)
        {
            ListViewItem newItem = new ListViewItem();
            newItem.Text = e.servicePoint.ToString();
            newItem.Tag = e.servicePoint.getId();

            if (this.lbQueues.InvokeRequired)
            {
                lbInsertCallback c = new lbInsertCallback(this.lbQueues.Items.Insert);
                this.lbQueues.Invoke(c, new Object[] { e.servicePoint.getId(), newItem });
            }
            else
            {
                this.lbQueues.Items.Insert(e.servicePoint.getId(), newItem);
            }
        }

        private void onServicePointDeletedHandler(Object sender, ServicePointArgs e)
        {
            
        }

        delegate void lbInsertCallback(int index, ListViewItem item);

        private void btnAddQueueToSP_Click(object sender, EventArgs e)
        {
            int queueSize = (tbQueueSize.Text != "")?Convert.ToInt16(tbQueueSize.Text):-1;
            if(queueSize > 0){
                this.sim.AddQueueArgument(new QueueStoreArg(this.tbQueueName.Text,  queueSize));
                this.lbQueues.Items.Add(this.tbQueueName.Text + "_Queue");
            }
        }

        private void cbOutput_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbOutput.SelectedIndex == 0)
                Logger.changeOutput(new System.IO.StreamWriter("log.txt", true));
            else
                Logger.changeOutput(new TextBoxStreamWriter(this.tbOutput));
        }

        private void btnReinit_Click(object sender, EventArgs e)
        {
            this.init();
        }
    }
}
