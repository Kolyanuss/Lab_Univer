namespace Perceptrone_UI
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.groupBox_result = new System.Windows.Forms.GroupBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label_result = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button_CreateNetwork = new System.Windows.Forms.Button();
            this.groupBox_OutputLayer = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox_HidenLayers = new System.Windows.Forms.GroupBox();
            this.numericUpDown_countOfHidenLayers = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox_Inputlayer = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel_LearnControl = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button__StartLearn = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.numericUpDown_countOfNeuronInIntputLayer = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_countOfNeuronInOutputLayer = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_maxCountOfEpochs = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_Learning_speed = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown5 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown6 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown7 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown8 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown9 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown10 = new System.Windows.Forms.NumericUpDown();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox_result.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox_OutputLayer.SuspendLayout();
            this.groupBox_HidenLayers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_countOfHidenLayers)).BeginInit();
            this.groupBox_Inputlayer.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel_LearnControl.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_countOfNeuronInIntputLayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_countOfNeuronInOutputLayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_maxCountOfEpochs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Learning_speed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown10)).BeginInit();
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
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
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
            // groupBox_result
            // 
            resources.ApplyResources(this.groupBox_result, "groupBox_result");
            this.groupBox_result.Controls.Add(this.dataGridView2);
            this.groupBox_result.Name = "groupBox_result";
            this.groupBox_result.TabStop = false;
            // 
            // dataGridView2
            // 
            resources.ApplyResources(this.dataGridView2, "dataGridView2");
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersVisible = false;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dataGridView2.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView2.RowTemplate.Height = 25;
            // 
            // label_result
            // 
            resources.ApplyResources(this.label_result, "label_result");
            this.label_result.Name = "label_result";
            // 
            // tabControl1
            // 
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
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
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // groupBox_HidenLayers
            // 
            resources.ApplyResources(this.groupBox_HidenLayers, "groupBox_HidenLayers");
            this.groupBox_HidenLayers.Controls.Add(this.numericUpDown10);
            this.groupBox_HidenLayers.Controls.Add(this.numericUpDown9);
            this.groupBox_HidenLayers.Controls.Add(this.numericUpDown8);
            this.groupBox_HidenLayers.Controls.Add(this.numericUpDown7);
            this.groupBox_HidenLayers.Controls.Add(this.numericUpDown6);
            this.groupBox_HidenLayers.Controls.Add(this.numericUpDown5);
            this.groupBox_HidenLayers.Controls.Add(this.numericUpDown4);
            this.groupBox_HidenLayers.Controls.Add(this.numericUpDown3);
            this.groupBox_HidenLayers.Controls.Add(this.numericUpDown2);
            this.groupBox_HidenLayers.Controls.Add(this.numericUpDown1);
            this.groupBox_HidenLayers.Controls.Add(this.numericUpDown_countOfHidenLayers);
            this.groupBox_HidenLayers.Controls.Add(this.label2);
            this.groupBox_HidenLayers.Controls.Add(this.label1);
            this.groupBox_HidenLayers.Name = "groupBox_HidenLayers";
            this.groupBox_HidenLayers.TabStop = false;
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
            this.panel_LearnControl.Controls.Add(this.numericUpDown_Learning_speed);
            this.panel_LearnControl.Controls.Add(this.numericUpDown_maxCountOfEpochs);
            this.panel_LearnControl.Controls.Add(this.label4);
            this.panel_LearnControl.Controls.Add(this.label5);
            this.panel_LearnControl.Controls.Add(this.button__StartLearn);
            this.panel_LearnControl.Controls.Add(this.button_addExample);
            this.panel_LearnControl.Controls.Add(this.button_deleteExample);
            this.panel_LearnControl.Name = "panel_LearnControl";
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
            this.tabPage3.Controls.Add(this.groupBox_result);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
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
            // numericUpDown_maxCountOfEpochs
            // 
            resources.ApplyResources(this.numericUpDown_maxCountOfEpochs, "numericUpDown_maxCountOfEpochs");
            this.numericUpDown_maxCountOfEpochs.Maximum = new decimal(new int[] {
            1000,
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
            1,
            0,
            0,
            0});
            // 
            // numericUpDown_Learning_speed
            // 
            resources.ApplyResources(this.numericUpDown_Learning_speed, "numericUpDown_Learning_speed");
            this.numericUpDown_Learning_speed.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown_Learning_speed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_Learning_speed.Name = "numericUpDown_Learning_speed";
            this.numericUpDown_Learning_speed.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDown1
            // 
            resources.ApplyResources(this.numericUpDown1, "numericUpDown1");
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDown2
            // 
            resources.ApplyResources(this.numericUpDown2, "numericUpDown2");
            this.numericUpDown2.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDown3
            // 
            resources.ApplyResources(this.numericUpDown3, "numericUpDown3");
            this.numericUpDown3.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown3.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDown4
            // 
            resources.ApplyResources(this.numericUpDown4, "numericUpDown4");
            this.numericUpDown4.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown4.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown4.Name = "numericUpDown4";
            this.numericUpDown4.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDown5
            // 
            resources.ApplyResources(this.numericUpDown5, "numericUpDown5");
            this.numericUpDown5.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown5.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown5.Name = "numericUpDown5";
            this.numericUpDown5.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDown6
            // 
            resources.ApplyResources(this.numericUpDown6, "numericUpDown6");
            this.numericUpDown6.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown6.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown6.Name = "numericUpDown6";
            this.numericUpDown6.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDown7
            // 
            resources.ApplyResources(this.numericUpDown7, "numericUpDown7");
            this.numericUpDown7.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown7.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown7.Name = "numericUpDown7";
            this.numericUpDown7.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDown8
            // 
            resources.ApplyResources(this.numericUpDown8, "numericUpDown8");
            this.numericUpDown8.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown8.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown8.Name = "numericUpDown8";
            this.numericUpDown8.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDown9
            // 
            resources.ApplyResources(this.numericUpDown9, "numericUpDown9");
            this.numericUpDown9.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown9.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown9.Name = "numericUpDown9";
            this.numericUpDown9.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDown10
            // 
            resources.ApplyResources(this.numericUpDown10, "numericUpDown10");
            this.numericUpDown10.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown10.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown10.Name = "numericUpDown10";
            this.numericUpDown10.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label_result);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox_result.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox_OutputLayer.ResumeLayout(false);
            this.groupBox_OutputLayer.PerformLayout();
            this.groupBox_HidenLayers.ResumeLayout(false);
            this.groupBox_HidenLayers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_countOfHidenLayers)).EndInit();
            this.groupBox_Inputlayer.ResumeLayout(false);
            this.groupBox_Inputlayer.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.panel_LearnControl.ResumeLayout(false);
            this.panel_LearnControl.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_countOfNeuronInIntputLayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_countOfNeuronInOutputLayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_maxCountOfEpochs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Learning_speed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown10)).EndInit();
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
        private GroupBox groupBox_result;
        private Label label_result;
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
        private NumericUpDown numericUpDown10;
        private NumericUpDown numericUpDown9;
        private NumericUpDown numericUpDown8;
        private NumericUpDown numericUpDown7;
        private NumericUpDown numericUpDown6;
        private NumericUpDown numericUpDown5;
        private NumericUpDown numericUpDown4;
        private NumericUpDown numericUpDown3;
        private NumericUpDown numericUpDown2;
        private NumericUpDown numericUpDown1;
    }
}