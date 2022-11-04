﻿namespace Perceptrone_UI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ToolStripMenuItem_File = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Save_AI = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Load_AI = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_restart = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button_deleteExample = new System.Windows.Forms.Button();
            this.button_addExample = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button_CreateNetwork = new System.Windows.Forms.Button();
            this.groupBox_OutputLayer = new System.Windows.Forms.GroupBox();
            this.numericUpDown_countOfNeuronInOutputLayer = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox_HidenLayers = new System.Windows.Forms.GroupBox();
            this.numericUpDown_CountOfNeuronInHidelLayer_10 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_CountOfNeuronInHidelLayer_9 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_CountOfNeuronInHidelLayer_8 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_CountOfNeuronInHidelLayer_7 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_CountOfNeuronInHidelLayer_6 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_CountOfNeuronInHidelLayer_5 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_CountOfNeuronInHidelLayer_4 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_CountOfNeuronInHidelLayer_3 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_CountOfNeuronInHidelLayer_2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_CountOfNeuronInHidelLayer_1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_countOfHidenLayers = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox_Inputlayer = new System.Windows.Forms.GroupBox();
            this.numericUpDown_countOfNeuronInIntputLayer = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel_LearnControl = new System.Windows.Forms.Panel();
            this.label_resultLearn = new System.Windows.Forms.Label();
            this.numericUpDown_Learning_speed = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_maxCountOfEpochs = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button__StartLearn = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.button_recognize = new System.Windows.Forms.Button();
            this.label_result = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox_OutputLayer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_countOfNeuronInOutputLayer)).BeginInit();
            this.groupBox_HidenLayers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_CountOfNeuronInHidelLayer_10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_CountOfNeuronInHidelLayer_9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_CountOfNeuronInHidelLayer_8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_CountOfNeuronInHidelLayer_7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_CountOfNeuronInHidelLayer_6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_CountOfNeuronInHidelLayer_5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_CountOfNeuronInHidelLayer_4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_CountOfNeuronInHidelLayer_3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_CountOfNeuronInHidelLayer_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_CountOfNeuronInHidelLayer_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_countOfHidenLayers)).BeginInit();
            this.groupBox_Inputlayer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_countOfNeuronInIntputLayer)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.panel_LearnControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Learning_speed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_maxCountOfEpochs)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_File});
            this.menuStrip1.Name = "menuStrip1";
            // 
            // ToolStripMenuItem_File
            // 
            resources.ApplyResources(this.ToolStripMenuItem_File, "ToolStripMenuItem_File");
            this.ToolStripMenuItem_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_Save_AI,
            this.ToolStripMenuItem_Load_AI,
            this.ToolStripMenuItem_restart});
            this.ToolStripMenuItem_File.Name = "ToolStripMenuItem_File";
            // 
            // ToolStripMenuItem_Save_AI
            // 
            resources.ApplyResources(this.ToolStripMenuItem_Save_AI, "ToolStripMenuItem_Save_AI");
            this.ToolStripMenuItem_Save_AI.Name = "ToolStripMenuItem_Save_AI";
            this.ToolStripMenuItem_Save_AI.Click += new System.EventHandler(this.ToolStripMenuItem_Save_AI_Click);
            // 
            // ToolStripMenuItem_Load_AI
            // 
            resources.ApplyResources(this.ToolStripMenuItem_Load_AI, "ToolStripMenuItem_Load_AI");
            this.ToolStripMenuItem_Load_AI.Name = "ToolStripMenuItem_Load_AI";
            this.ToolStripMenuItem_Load_AI.Click += new System.EventHandler(this.ToolStripMenuItem_Load_AI_Click);
            // 
            // ToolStripMenuItem_restart
            // 
            resources.ApplyResources(this.ToolStripMenuItem_restart, "ToolStripMenuItem_restart");
            this.ToolStripMenuItem_restart.Name = "ToolStripMenuItem_restart";
            this.ToolStripMenuItem_restart.Click += new System.EventHandler(this.ToolStripMenuItem_restart_Click);
            // 
            // openFileDialog1
            // 
            resources.ApplyResources(this.openFileDialog1, "openFileDialog1");
            // 
            // saveFileDialog1
            // 
            resources.ApplyResources(this.saveFileDialog1, "saveFileDialog1");
            // 
            // dataGridView1
            // 
            resources.ApplyResources(this.dataGridView1, "dataGridView1");
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.ShowCellToolTips = false;
            // 
            // button_deleteExample
            // 
            resources.ApplyResources(this.button_deleteExample, "button_deleteExample");
            this.button_deleteExample.Name = "button_deleteExample";
            this.button_deleteExample.UseVisualStyleBackColor = true;
            this.button_deleteExample.Click += new System.EventHandler(this.button_deleteExample_Click);
            // 
            // button_addExample
            // 
            resources.ApplyResources(this.button_addExample, "button_addExample");
            this.button_addExample.Name = "button_addExample";
            this.button_addExample.UseVisualStyleBackColor = true;
            this.button_addExample.Click += new System.EventHandler(this.button_addExample_Click);
            // 
            // dataGridView2
            // 
            resources.ApplyResources(this.dataGridView2, "dataGridView2");
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView2.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.RowTemplate.Height = 25;
            // 
            // tabControl1
            // 
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Deselected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Deselected);
            // 
            // tabPage1
            // 
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Controls.Add(this.button_CreateNetwork);
            this.tabPage1.Controls.Add(this.groupBox_OutputLayer);
            this.tabPage1.Controls.Add(this.groupBox_HidenLayers);
            this.tabPage1.Controls.Add(this.groupBox_Inputlayer);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button_CreateNetwork
            // 
            resources.ApplyResources(this.button_CreateNetwork, "button_CreateNetwork");
            this.button_CreateNetwork.Name = "button_CreateNetwork";
            this.button_CreateNetwork.UseVisualStyleBackColor = true;
            this.button_CreateNetwork.Click += new System.EventHandler(this.button_CreateNetwork_Click);
            // 
            // groupBox_OutputLayer
            // 
            resources.ApplyResources(this.groupBox_OutputLayer, "groupBox_OutputLayer");
            this.groupBox_OutputLayer.Controls.Add(this.numericUpDown_countOfNeuronInOutputLayer);
            this.groupBox_OutputLayer.Controls.Add(this.label3);
            this.groupBox_OutputLayer.Name = "groupBox_OutputLayer";
            this.groupBox_OutputLayer.TabStop = false;
            // 
            // numericUpDown_countOfNeuronInOutputLayer
            // 
            resources.ApplyResources(this.numericUpDown_countOfNeuronInOutputLayer, "numericUpDown_countOfNeuronInOutputLayer");
            this.numericUpDown_countOfNeuronInOutputLayer.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown_countOfNeuronInOutputLayer.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_countOfNeuronInOutputLayer.Name = "numericUpDown_countOfNeuronInOutputLayer";
            this.numericUpDown_countOfNeuronInOutputLayer.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // groupBox_HidenLayers
            // 
            resources.ApplyResources(this.groupBox_HidenLayers, "groupBox_HidenLayers");
            this.groupBox_HidenLayers.Controls.Add(this.numericUpDown_CountOfNeuronInHidelLayer_10);
            this.groupBox_HidenLayers.Controls.Add(this.numericUpDown_CountOfNeuronInHidelLayer_9);
            this.groupBox_HidenLayers.Controls.Add(this.numericUpDown_CountOfNeuronInHidelLayer_8);
            this.groupBox_HidenLayers.Controls.Add(this.numericUpDown_CountOfNeuronInHidelLayer_7);
            this.groupBox_HidenLayers.Controls.Add(this.numericUpDown_CountOfNeuronInHidelLayer_6);
            this.groupBox_HidenLayers.Controls.Add(this.numericUpDown_CountOfNeuronInHidelLayer_5);
            this.groupBox_HidenLayers.Controls.Add(this.numericUpDown_CountOfNeuronInHidelLayer_4);
            this.groupBox_HidenLayers.Controls.Add(this.numericUpDown_CountOfNeuronInHidelLayer_3);
            this.groupBox_HidenLayers.Controls.Add(this.numericUpDown_CountOfNeuronInHidelLayer_2);
            this.groupBox_HidenLayers.Controls.Add(this.numericUpDown_CountOfNeuronInHidelLayer_1);
            this.groupBox_HidenLayers.Controls.Add(this.numericUpDown_countOfHidenLayers);
            this.groupBox_HidenLayers.Controls.Add(this.label2);
            this.groupBox_HidenLayers.Controls.Add(this.label1);
            this.groupBox_HidenLayers.Name = "groupBox_HidenLayers";
            this.groupBox_HidenLayers.TabStop = false;
            // 
            // numericUpDown_CountOfNeuronInHidelLayer_10
            // 
            resources.ApplyResources(this.numericUpDown_CountOfNeuronInHidelLayer_10, "numericUpDown_CountOfNeuronInHidelLayer_10");
            this.numericUpDown_CountOfNeuronInHidelLayer_10.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown_CountOfNeuronInHidelLayer_10.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_CountOfNeuronInHidelLayer_10.Name = "numericUpDown_CountOfNeuronInHidelLayer_10";
            this.numericUpDown_CountOfNeuronInHidelLayer_10.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDown_CountOfNeuronInHidelLayer_9
            // 
            resources.ApplyResources(this.numericUpDown_CountOfNeuronInHidelLayer_9, "numericUpDown_CountOfNeuronInHidelLayer_9");
            this.numericUpDown_CountOfNeuronInHidelLayer_9.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown_CountOfNeuronInHidelLayer_9.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_CountOfNeuronInHidelLayer_9.Name = "numericUpDown_CountOfNeuronInHidelLayer_9";
            this.numericUpDown_CountOfNeuronInHidelLayer_9.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDown_CountOfNeuronInHidelLayer_8
            // 
            resources.ApplyResources(this.numericUpDown_CountOfNeuronInHidelLayer_8, "numericUpDown_CountOfNeuronInHidelLayer_8");
            this.numericUpDown_CountOfNeuronInHidelLayer_8.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown_CountOfNeuronInHidelLayer_8.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_CountOfNeuronInHidelLayer_8.Name = "numericUpDown_CountOfNeuronInHidelLayer_8";
            this.numericUpDown_CountOfNeuronInHidelLayer_8.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDown_CountOfNeuronInHidelLayer_7
            // 
            resources.ApplyResources(this.numericUpDown_CountOfNeuronInHidelLayer_7, "numericUpDown_CountOfNeuronInHidelLayer_7");
            this.numericUpDown_CountOfNeuronInHidelLayer_7.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown_CountOfNeuronInHidelLayer_7.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_CountOfNeuronInHidelLayer_7.Name = "numericUpDown_CountOfNeuronInHidelLayer_7";
            this.numericUpDown_CountOfNeuronInHidelLayer_7.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDown_CountOfNeuronInHidelLayer_6
            // 
            resources.ApplyResources(this.numericUpDown_CountOfNeuronInHidelLayer_6, "numericUpDown_CountOfNeuronInHidelLayer_6");
            this.numericUpDown_CountOfNeuronInHidelLayer_6.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown_CountOfNeuronInHidelLayer_6.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_CountOfNeuronInHidelLayer_6.Name = "numericUpDown_CountOfNeuronInHidelLayer_6";
            this.numericUpDown_CountOfNeuronInHidelLayer_6.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDown_CountOfNeuronInHidelLayer_5
            // 
            resources.ApplyResources(this.numericUpDown_CountOfNeuronInHidelLayer_5, "numericUpDown_CountOfNeuronInHidelLayer_5");
            this.numericUpDown_CountOfNeuronInHidelLayer_5.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown_CountOfNeuronInHidelLayer_5.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_CountOfNeuronInHidelLayer_5.Name = "numericUpDown_CountOfNeuronInHidelLayer_5";
            this.numericUpDown_CountOfNeuronInHidelLayer_5.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDown_CountOfNeuronInHidelLayer_4
            // 
            resources.ApplyResources(this.numericUpDown_CountOfNeuronInHidelLayer_4, "numericUpDown_CountOfNeuronInHidelLayer_4");
            this.numericUpDown_CountOfNeuronInHidelLayer_4.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown_CountOfNeuronInHidelLayer_4.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_CountOfNeuronInHidelLayer_4.Name = "numericUpDown_CountOfNeuronInHidelLayer_4";
            this.numericUpDown_CountOfNeuronInHidelLayer_4.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDown_CountOfNeuronInHidelLayer_3
            // 
            resources.ApplyResources(this.numericUpDown_CountOfNeuronInHidelLayer_3, "numericUpDown_CountOfNeuronInHidelLayer_3");
            this.numericUpDown_CountOfNeuronInHidelLayer_3.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown_CountOfNeuronInHidelLayer_3.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_CountOfNeuronInHidelLayer_3.Name = "numericUpDown_CountOfNeuronInHidelLayer_3";
            this.numericUpDown_CountOfNeuronInHidelLayer_3.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDown_CountOfNeuronInHidelLayer_2
            // 
            resources.ApplyResources(this.numericUpDown_CountOfNeuronInHidelLayer_2, "numericUpDown_CountOfNeuronInHidelLayer_2");
            this.numericUpDown_CountOfNeuronInHidelLayer_2.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown_CountOfNeuronInHidelLayer_2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_CountOfNeuronInHidelLayer_2.Name = "numericUpDown_CountOfNeuronInHidelLayer_2";
            this.numericUpDown_CountOfNeuronInHidelLayer_2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDown_CountOfNeuronInHidelLayer_1
            // 
            resources.ApplyResources(this.numericUpDown_CountOfNeuronInHidelLayer_1, "numericUpDown_CountOfNeuronInHidelLayer_1");
            this.numericUpDown_CountOfNeuronInHidelLayer_1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown_CountOfNeuronInHidelLayer_1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_CountOfNeuronInHidelLayer_1.Name = "numericUpDown_CountOfNeuronInHidelLayer_1";
            this.numericUpDown_CountOfNeuronInHidelLayer_1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDown_countOfHidenLayers
            // 
            resources.ApplyResources(this.numericUpDown_countOfHidenLayers, "numericUpDown_countOfHidenLayers");
            this.numericUpDown_countOfHidenLayers.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown_countOfHidenLayers.Name = "numericUpDown_countOfHidenLayers";
            this.numericUpDown_countOfHidenLayers.ValueChanged += new System.EventHandler(this.numericUpDown_countOfHidenLayers_ValueChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // groupBox_Inputlayer
            // 
            resources.ApplyResources(this.groupBox_Inputlayer, "groupBox_Inputlayer");
            this.groupBox_Inputlayer.Controls.Add(this.numericUpDown_countOfNeuronInIntputLayer);
            this.groupBox_Inputlayer.Controls.Add(this.label6);
            this.groupBox_Inputlayer.Name = "groupBox_Inputlayer";
            this.groupBox_Inputlayer.TabStop = false;
            // 
            // numericUpDown_countOfNeuronInIntputLayer
            // 
            resources.ApplyResources(this.numericUpDown_countOfNeuronInIntputLayer, "numericUpDown_countOfNeuronInIntputLayer");
            this.numericUpDown_countOfNeuronInIntputLayer.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown_countOfNeuronInIntputLayer.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_countOfNeuronInIntputLayer.Name = "numericUpDown_countOfNeuronInIntputLayer";
            this.numericUpDown_countOfNeuronInIntputLayer.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // tabPage2
            // 
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Controls.Add(this.panel_LearnControl);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel_LearnControl
            // 
            resources.ApplyResources(this.panel_LearnControl, "panel_LearnControl");
            this.panel_LearnControl.Controls.Add(this.label_resultLearn);
            this.panel_LearnControl.Controls.Add(this.numericUpDown_Learning_speed);
            this.panel_LearnControl.Controls.Add(this.numericUpDown_maxCountOfEpochs);
            this.panel_LearnControl.Controls.Add(this.label4);
            this.panel_LearnControl.Controls.Add(this.label5);
            this.panel_LearnControl.Controls.Add(this.button__StartLearn);
            this.panel_LearnControl.Controls.Add(this.button_addExample);
            this.panel_LearnControl.Controls.Add(this.button_deleteExample);
            this.panel_LearnControl.Name = "panel_LearnControl";
            // 
            // label_resultLearn
            // 
            resources.ApplyResources(this.label_resultLearn, "label_resultLearn");
            this.label_resultLearn.Name = "label_resultLearn";
            // 
            // numericUpDown_Learning_speed
            // 
            resources.ApplyResources(this.numericUpDown_Learning_speed, "numericUpDown_Learning_speed");
            this.numericUpDown_Learning_speed.DecimalPlaces = 3;
            this.numericUpDown_Learning_speed.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown_Learning_speed.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown_Learning_speed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numericUpDown_Learning_speed.Name = "numericUpDown_Learning_speed";
            this.numericUpDown_Learning_speed.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // numericUpDown_maxCountOfEpochs
            // 
            resources.ApplyResources(this.numericUpDown_maxCountOfEpochs, "numericUpDown_maxCountOfEpochs");
            this.numericUpDown_maxCountOfEpochs.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDown_maxCountOfEpochs.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numericUpDown_maxCountOfEpochs.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_maxCountOfEpochs.Name = "numericUpDown_maxCountOfEpochs";
            this.numericUpDown_maxCountOfEpochs.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // button__StartLearn
            // 
            resources.ApplyResources(this.button__StartLearn, "button__StartLearn");
            this.button__StartLearn.Name = "button__StartLearn";
            this.button__StartLearn.UseVisualStyleBackColor = true;
            this.button__StartLearn.Click += new System.EventHandler(this.button__StartLearn_Click);
            // 
            // tabPage3
            // 
            resources.ApplyResources(this.tabPage3, "tabPage3");
            this.tabPage3.Controls.Add(this.button_recognize);
            this.tabPage3.Controls.Add(this.label_result);
            this.tabPage3.Controls.Add(this.dataGridView2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // button_recognize
            // 
            resources.ApplyResources(this.button_recognize, "button_recognize");
            this.button_recognize.Name = "button_recognize";
            this.button_recognize.UseVisualStyleBackColor = true;
            this.button_recognize.Click += new System.EventHandler(this.button_recognize_Click);
            // 
            // label_result
            // 
            resources.ApplyResources(this.label_result, "label_result");
            this.label_result.Name = "label_result";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox_OutputLayer.ResumeLayout(false);
            this.groupBox_OutputLayer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_countOfNeuronInOutputLayer)).EndInit();
            this.groupBox_HidenLayers.ResumeLayout(false);
            this.groupBox_HidenLayers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_CountOfNeuronInHidelLayer_10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_CountOfNeuronInHidelLayer_9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_CountOfNeuronInHidelLayer_8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_CountOfNeuronInHidelLayer_7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_CountOfNeuronInHidelLayer_6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_CountOfNeuronInHidelLayer_5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_CountOfNeuronInHidelLayer_4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_CountOfNeuronInHidelLayer_3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_CountOfNeuronInHidelLayer_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_CountOfNeuronInHidelLayer_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_countOfHidenLayers)).EndInit();
            this.groupBox_Inputlayer.ResumeLayout(false);
            this.groupBox_Inputlayer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_countOfNeuronInIntputLayer)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.panel_LearnControl.ResumeLayout(false);
            this.panel_LearnControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Learning_speed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_maxCountOfEpochs)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem ToolStripMenuItem_File;
        private OpenFileDialog openFileDialog1;
        private ToolStripMenuItem ToolStripMenuItem_restart;
        private ToolStripMenuItem ToolStripMenuItem_Save_AI;
        private ToolStripMenuItem ToolStripMenuItem_Load_AI;
        private SaveFileDialog saveFileDialog1;
        private Button button_deleteExample;
        private Button button_addExample;
        private DataGridView dataGridView1;
        private DataGridView dataGridView2;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private Panel panel_LearnControl;
        private Button button__StartLearn;
        private Label label4;
        private Label label5;
        private GroupBox groupBox_OutputLayer;
        private GroupBox groupBox_Inputlayer;
        private GroupBox groupBox_HidenLayers;
        private Button button_CreateNetwork;
        private Label label3;
        private Label label1;
        private Label label2;
        private Label label6;
        private NumericUpDown numericUpDown_countOfHidenLayers;
        private NumericUpDown numericUpDown_countOfNeuronInIntputLayer;
        private NumericUpDown numericUpDown_countOfNeuronInOutputLayer;
        private NumericUpDown numericUpDown_Learning_speed;
        private NumericUpDown numericUpDown_maxCountOfEpochs;
        private NumericUpDown numericUpDown_CountOfNeuronInHidelLayer_10;
        private NumericUpDown numericUpDown_CountOfNeuronInHidelLayer_9;
        private NumericUpDown numericUpDown_CountOfNeuronInHidelLayer_8;
        private NumericUpDown numericUpDown_CountOfNeuronInHidelLayer_7;
        private NumericUpDown numericUpDown_CountOfNeuronInHidelLayer_6;
        private NumericUpDown numericUpDown_CountOfNeuronInHidelLayer_5;
        private NumericUpDown numericUpDown_CountOfNeuronInHidelLayer_4;
        private NumericUpDown numericUpDown_CountOfNeuronInHidelLayer_3;
        private NumericUpDown numericUpDown_CountOfNeuronInHidelLayer_2;
        private NumericUpDown numericUpDown_CountOfNeuronInHidelLayer_1;
        private Label label_result;
        private Label label_resultLearn;
        private Button button_recognize;
    }
}