namespace StoreSimulation
{
    partial class MainView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tbNumItems = new System.Windows.Forms.TextBox();
            this.tbNumClients = new System.Windows.Forms.TextBox();
            this.tbTimeMin = new System.Windows.Forms.TextBox();
            this.tbTimeSec = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.tbOutput = new System.Windows.Forms.TextBox();
            this.btnAddClients = new System.Windows.Forms.Button();
            this.tbHours = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cbSupStrats = new System.Windows.Forms.ComboBox();
            this.tbMaxSP = new System.Windows.Forms.TextBox();
            this.tbMinSP = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbMaxQueueSP = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.lblTimer = new System.Windows.Forms.Label();
            this.tbFrameTime = new System.Windows.Forms.TextBox();
            this.btnChangeConfigs = new System.Windows.Forms.Button();
            this.tbCustomSPMaxItems = new System.Windows.Forms.TextBox();
            this.tbCustomSPType = new System.Windows.Forms.TextBox();
            this.tbCustomSPMaxQueueSize = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.tbCustomSPtimePerItem = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.btnAddSP = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.tbCustomSPEntTimeHours = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.tbCustomSPEntTimeSecs = new System.Windows.Forms.TextBox();
            this.tbCustomSPEntTimeMins = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.lbQueues = new System.Windows.Forms.ListBox();
            this.btnAddQueueToSP = new System.Windows.Forms.Button();
            this.label24 = new System.Windows.Forms.Label();
            this.tbQueueSize = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.tbQueueName = new System.Windows.Forms.TextBox();
            this.labelOutput = new System.Windows.Forms.Label();
            this.cbOutput = new System.Windows.Forms.ComboBox();
            this.btnReinit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Number of clients";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Entrance time";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Number of items";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 816);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(796, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tbNumItems
            // 
            this.tbNumItems.Location = new System.Drawing.Point(192, 78);
            this.tbNumItems.Name = "tbNumItems";
            this.tbNumItems.Size = new System.Drawing.Size(36, 20);
            this.tbNumItems.TabIndex = 5;
            // 
            // tbNumClients
            // 
            this.tbNumClients.Location = new System.Drawing.Point(192, 22);
            this.tbNumClients.Name = "tbNumClients";
            this.tbNumClients.Size = new System.Drawing.Size(36, 20);
            this.tbNumClients.TabIndex = 1;
            // 
            // tbTimeMin
            // 
            this.tbTimeMin.Location = new System.Drawing.Point(249, 49);
            this.tbTimeMin.Name = "tbTimeMin";
            this.tbTimeMin.Size = new System.Drawing.Size(36, 20);
            this.tbTimeMin.TabIndex = 3;
            // 
            // tbTimeSec
            // 
            this.tbTimeSec.Location = new System.Drawing.Point(307, 49);
            this.tbTimeSec.Name = "tbTimeSec";
            this.tbTimeSec.Size = new System.Drawing.Size(36, 20);
            this.tbTimeSec.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(291, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(10, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = ":";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(110, 790);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(253, 23);
            this.btnStart.TabIndex = 7;
            this.btnStart.Text = "Start simulation";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // tbOutput
            // 
            this.tbOutput.Location = new System.Drawing.Point(387, 26);
            this.tbOutput.Multiline = true;
            this.tbOutput.Name = "tbOutput";
            this.tbOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbOutput.Size = new System.Drawing.Size(396, 783);
            this.tbOutput.TabIndex = 13;
            // 
            // btnAddClients
            // 
            this.btnAddClients.Location = new System.Drawing.Point(191, 104);
            this.btnAddClients.Name = "btnAddClients";
            this.btnAddClients.Size = new System.Drawing.Size(95, 23);
            this.btnAddClients.TabIndex = 6;
            this.btnAddClients.Text = "Add client(s)";
            this.btnAddClients.UseVisualStyleBackColor = true;
            this.btnAddClients.Click += new System.EventHandler(this.btnAddClients_Click);
            // 
            // tbHours
            // 
            this.tbHours.Location = new System.Drawing.Point(192, 48);
            this.tbHours.Name = "tbHours";
            this.tbHours.Size = new System.Drawing.Size(36, 20);
            this.tbHours.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(233, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(10, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = ":";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(49, 651);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Frame time";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(66, 545);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Supervisor strategies";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(78, 723);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Min number";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(78, 698);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "Max number";
            // 
            // cbSupStrats
            // 
            this.cbSupStrats.FormattingEnabled = true;
            this.cbSupStrats.Location = new System.Drawing.Point(193, 542);
            this.cbSupStrats.Name = "cbSupStrats";
            this.cbSupStrats.Size = new System.Drawing.Size(121, 21);
            this.cbSupStrats.TabIndex = 22;
            this.cbSupStrats.SelectedIndexChanged += new System.EventHandler(this.cbSupStrats_SelectedIndexChanged);
            // 
            // tbMaxSP
            // 
            this.tbMaxSP.Location = new System.Drawing.Point(174, 695);
            this.tbMaxSP.Name = "tbMaxSP";
            this.tbMaxSP.Size = new System.Drawing.Size(36, 20);
            this.tbMaxSP.TabIndex = 24;
            // 
            // tbMinSP
            // 
            this.tbMinSP.Location = new System.Drawing.Point(174, 720);
            this.tbMinSP.Name = "tbMinSP";
            this.tbMinSP.Size = new System.Drawing.Size(36, 20);
            this.tbMinSP.TabIndex = 25;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(49, 674);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(74, 13);
            this.label11.TabIndex = 26;
            this.label11.Text = "Service points";
            // 
            // tbMaxQueueSP
            // 
            this.tbMaxQueueSP.Location = new System.Drawing.Point(174, 744);
            this.tbMaxQueueSP.Name = "tbMaxQueueSP";
            this.tbMaxQueueSP.Size = new System.Drawing.Size(36, 20);
            this.tbMaxQueueSP.TabIndex = 28;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(78, 747);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(92, 13);
            this.label12.TabIndex = 27;
            this.label12.Text = "Max queue length";
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.Location = new System.Drawing.Point(384, 10);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(43, 13);
            this.lblTimer.TabIndex = 29;
            this.lblTimer.Text = "0:00:00";
            // 
            // tbFrameTime
            // 
            this.tbFrameTime.Location = new System.Drawing.Point(174, 651);
            this.tbFrameTime.Name = "tbFrameTime";
            this.tbFrameTime.Size = new System.Drawing.Size(34, 20);
            this.tbFrameTime.TabIndex = 30;
            this.tbFrameTime.Text = "0";
            this.tbFrameTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnChangeConfigs
            // 
            this.btnChangeConfigs.Location = new System.Drawing.Point(231, 736);
            this.btnChangeConfigs.Name = "btnChangeConfigs";
            this.btnChangeConfigs.Size = new System.Drawing.Size(95, 23);
            this.btnChangeConfigs.TabIndex = 31;
            this.btnChangeConfigs.Text = "Change configs";
            this.btnChangeConfigs.UseVisualStyleBackColor = true;
            this.btnChangeConfigs.Click += new System.EventHandler(this.btnChangeConfigs_Click);
            // 
            // tbCustomSPMaxItems
            // 
            this.tbCustomSPMaxItems.Location = new System.Drawing.Point(187, 368);
            this.tbCustomSPMaxItems.Name = "tbCustomSPMaxItems";
            this.tbCustomSPMaxItems.Size = new System.Drawing.Size(36, 20);
            this.tbCustomSPMaxItems.TabIndex = 36;
            // 
            // tbCustomSPType
            // 
            this.tbCustomSPType.Location = new System.Drawing.Point(187, 342);
            this.tbCustomSPType.Name = "tbCustomSPType";
            this.tbCustomSPType.Size = new System.Drawing.Size(94, 20);
            this.tbCustomSPType.TabIndex = 34;
            // 
            // tbCustomSPMaxQueueSize
            // 
            this.tbCustomSPMaxQueueSize.Location = new System.Drawing.Point(187, 398);
            this.tbCustomSPMaxQueueSize.Name = "tbCustomSPMaxQueueSize";
            this.tbCustomSPMaxQueueSize.Size = new System.Drawing.Size(36, 20);
            this.tbCustomSPMaxQueueSize.TabIndex = 37;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(35, 401);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(105, 13);
            this.label13.TabIndex = 35;
            this.label13.Text = "Maximum queue size";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(35, 376);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(142, 13);
            this.label14.TabIndex = 33;
            this.label14.Text = "Maximum items per customer";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(35, 349);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(31, 13);
            this.label15.TabIndex = 32;
            this.label15.Text = "Type";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(21, 320);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(105, 13);
            this.label16.TabIndex = 38;
            this.label16.Text = "Custom service point";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(12, 10);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(38, 13);
            this.label17.TabIndex = 39;
            this.label17.Text = "Clients";
            // 
            // tbCustomSPtimePerItem
            // 
            this.tbCustomSPtimePerItem.Location = new System.Drawing.Point(187, 423);
            this.tbCustomSPtimePerItem.Name = "tbCustomSPtimePerItem";
            this.tbCustomSPtimePerItem.Size = new System.Drawing.Size(36, 20);
            this.tbCustomSPtimePerItem.TabIndex = 41;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(35, 426);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(116, 13);
            this.label18.TabIndex = 40;
            this.label18.Text = "Time per item(seconds)";
            // 
            // btnAddSP
            // 
            this.btnAddSP.Location = new System.Drawing.Point(175, 478);
            this.btnAddSP.Name = "btnAddSP";
            this.btnAddSP.Size = new System.Drawing.Size(121, 23);
            this.btnAddSP.TabIndex = 42;
            this.btnAddSP.Text = "Add service point";
            this.btnAddSP.UseVisualStyleBackColor = true;
            this.btnAddSP.Click += new System.EventHandler(this.btnAddSP_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(228, 452);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(10, 13);
            this.label19.TabIndex = 48;
            this.label19.Text = ":";
            // 
            // tbCustomSPEntTimeHours
            // 
            this.tbCustomSPEntTimeHours.Location = new System.Drawing.Point(187, 449);
            this.tbCustomSPEntTimeHours.Name = "tbCustomSPEntTimeHours";
            this.tbCustomSPEntTimeHours.Size = new System.Drawing.Size(36, 20);
            this.tbCustomSPEntTimeHours.TabIndex = 44;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(286, 453);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(10, 13);
            this.label20.TabIndex = 47;
            this.label20.Text = ":";
            // 
            // tbCustomSPEntTimeSecs
            // 
            this.tbCustomSPEntTimeSecs.Location = new System.Drawing.Point(302, 450);
            this.tbCustomSPEntTimeSecs.Name = "tbCustomSPEntTimeSecs";
            this.tbCustomSPEntTimeSecs.Size = new System.Drawing.Size(36, 20);
            this.tbCustomSPEntTimeSecs.TabIndex = 46;
            // 
            // tbCustomSPEntTimeMins
            // 
            this.tbCustomSPEntTimeMins.Location = new System.Drawing.Point(244, 450);
            this.tbCustomSPEntTimeMins.Name = "tbCustomSPEntTimeMins";
            this.tbCustomSPEntTimeMins.Size = new System.Drawing.Size(36, 20);
            this.tbCustomSPEntTimeMins.TabIndex = 45;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(35, 453);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(72, 13);
            this.label21.TabIndex = 43;
            this.label21.Text = "Entrance time";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(18, 599);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(74, 13);
            this.label22.TabIndex = 49;
            this.label22.Text = "Configurations";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(19, 515);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(54, 13);
            this.label23.TabIndex = 50;
            this.label23.Text = "Strategies";
            // 
            // lbQueues
            // 
            this.lbQueues.FormattingEnabled = true;
            this.lbQueues.Location = new System.Drawing.Point(187, 191);
            this.lbQueues.Name = "lbQueues";
            this.lbQueues.Size = new System.Drawing.Size(187, 134);
            this.lbQueues.TabIndex = 51;
            // 
            // btnAddQueueToSP
            // 
            this.btnAddQueueToSP.Location = new System.Drawing.Point(47, 217);
            this.btnAddQueueToSP.Name = "btnAddQueueToSP";
            this.btnAddQueueToSP.Size = new System.Drawing.Size(121, 23);
            this.btnAddQueueToSP.TabIndex = 52;
            this.btnAddQueueToSP.Text = "Add queue";
            this.btnAddQueueToSP.UseVisualStyleBackColor = true;
            this.btnAddQueueToSP.Click += new System.EventHandler(this.btnAddQueueToSP_Click);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(12, 136);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(80, 13);
            this.label24.TabIndex = 53;
            this.label24.Text = "Custom queues";
            // 
            // tbQueueSize
            // 
            this.tbQueueSize.Location = new System.Drawing.Point(110, 188);
            this.tbQueueSize.Name = "tbQueueSize";
            this.tbQueueSize.Size = new System.Drawing.Size(36, 20);
            this.tbQueueSize.TabIndex = 54;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(44, 191);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(60, 13);
            this.label25.TabIndex = 55;
            this.label25.Text = "Queue size";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(44, 167);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(31, 13);
            this.label26.TabIndex = 57;
            this.label26.Text = "Type";
            // 
            // tbQueueName
            // 
            this.tbQueueName.Location = new System.Drawing.Point(110, 162);
            this.tbQueueName.Name = "tbQueueName";
            this.tbQueueName.Size = new System.Drawing.Size(113, 20);
            this.tbQueueName.TabIndex = 56;
            // 
            // labelOutput
            // 
            this.labelOutput.AutoSize = true;
            this.labelOutput.Location = new System.Drawing.Point(49, 629);
            this.labelOutput.Name = "labelOutput";
            this.labelOutput.Size = new System.Drawing.Size(39, 13);
            this.labelOutput.TabIndex = 50;
            this.labelOutput.Text = "Output";
            // 
            // cbOutput
            // 
            this.cbOutput.FormattingEnabled = true;
            this.cbOutput.Items.AddRange(new object[] {
            "File",
            "Console"});
            this.cbOutput.Location = new System.Drawing.Point(174, 621);
            this.cbOutput.Name = "cbOutput";
            this.cbOutput.Size = new System.Drawing.Size(89, 21);
            this.cbOutput.TabIndex = 23;
            this.cbOutput.SelectedIndexChanged += new System.EventHandler(this.cbOutput_SelectedIndexChanged);
            // 
            // btnReinit
            // 
            this.btnReinit.Location = new System.Drawing.Point(10, 790);
            this.btnReinit.Name = "btnReinit";
            this.btnReinit.Size = new System.Drawing.Size(92, 23);
            this.btnReinit.TabIndex = 58;
            this.btnReinit.Text = "Reinitialize";
            this.btnReinit.UseVisualStyleBackColor = true;
            this.btnReinit.Click += new System.EventHandler(this.btnReinit_Click);
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 838);
            this.Controls.Add(this.btnReinit);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.tbQueueName);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.tbQueueSize);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.btnAddQueueToSP);
            this.Controls.Add(this.lbQueues);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.labelOutput);
            this.Controls.Add(this.cbOutput);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.tbCustomSPEntTimeHours);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.tbCustomSPEntTimeSecs);
            this.Controls.Add(this.tbCustomSPEntTimeMins);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.btnAddSP);
            this.Controls.Add(this.tbCustomSPtimePerItem);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.tbCustomSPMaxItems);
            this.Controls.Add(this.tbCustomSPType);
            this.Controls.Add(this.tbCustomSPMaxQueueSize);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.btnChangeConfigs);
            this.Controls.Add(this.tbFrameTime);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.tbMaxQueueSP);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tbMinSP);
            this.Controls.Add(this.tbMaxSP);
            this.Controls.Add(this.cbSupStrats);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbHours);
            this.Controls.Add(this.btnAddClients);
            this.Controls.Add(this.tbOutput);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbTimeSec);
            this.Controls.Add(this.tbTimeMin);
            this.Controls.Add(this.tbNumClients);
            this.Controls.Add(this.tbNumItems);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "MainView";
            this.Text = "SimStore";
            this.Load += new System.EventHandler(this.MainView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TextBox tbNumItems;
        private System.Windows.Forms.TextBox tbNumClients;
        private System.Windows.Forms.TextBox tbTimeMin;
        private System.Windows.Forms.TextBox tbTimeSec;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox tbOutput;
        private System.Windows.Forms.Button btnAddClients;
        private System.Windows.Forms.TextBox tbHours;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbSupStrats;
        private System.Windows.Forms.TextBox tbMaxSP;
        private System.Windows.Forms.TextBox tbMinSP;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbMaxQueueSP;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.TextBox tbFrameTime;
        private System.Windows.Forms.Button btnChangeConfigs;
        private System.Windows.Forms.TextBox tbCustomSPMaxItems;
        private System.Windows.Forms.TextBox tbCustomSPType;
        private System.Windows.Forms.TextBox tbCustomSPMaxQueueSize;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox tbCustomSPtimePerItem;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnAddSP;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox tbCustomSPEntTimeHours;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox tbCustomSPEntTimeSecs;
        private System.Windows.Forms.TextBox tbCustomSPEntTimeMins;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ListBox lbQueues;
        private System.Windows.Forms.Button btnAddQueueToSP;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox tbQueueSize;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox tbQueueName;
        private System.Windows.Forms.Label labelOutput;
        private System.Windows.Forms.ComboBox cbOutput;
        private System.Windows.Forms.Button btnReinit;

    }
}

