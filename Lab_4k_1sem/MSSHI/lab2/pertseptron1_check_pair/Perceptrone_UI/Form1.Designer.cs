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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button_DeffoltLearn = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonUImode = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox_manual_input = new System.Windows.Forms.GroupBox();
            this.button_notpair = new System.Windows.Forms.Button();
            this.buttonSupport = new System.Windows.Forms.Button();
            this.button_pair = new System.Windows.Forms.Button();
            this.groupBox_manual_input.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // button_DeffoltLearn
            // 
            resources.ApplyResources(this.button_DeffoltLearn, "button_DeffoltLearn");
            this.button_DeffoltLearn.Name = "button_DeffoltLearn";
            this.button_DeffoltLearn.UseVisualStyleBackColor = true;
            this.button_DeffoltLearn.Click += new System.EventHandler(this.button_DeffoltLearn_Click);
            // 
            // comboBox1
            // 
            resources.ApplyResources(this.comboBox1, "comboBox1");
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            resources.GetString("comboBox1.Items"),
            resources.GetString("comboBox1.Items1"),
            resources.GetString("comboBox1.Items2"),
            resources.GetString("comboBox1.Items3"),
            resources.GetString("comboBox1.Items4"),
            resources.GetString("comboBox1.Items5"),
            resources.GetString("comboBox1.Items6"),
            resources.GetString("comboBox1.Items7"),
            resources.GetString("comboBox1.Items8"),
            resources.GetString("comboBox1.Items9")});
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // buttonUImode
            // 
            resources.ApplyResources(this.buttonUImode, "buttonUImode");
            this.buttonUImode.Name = "buttonUImode";
            this.buttonUImode.UseVisualStyleBackColor = true;
            this.buttonUImode.Click += new System.EventHandler(this.buttonUImode_Click);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // groupBox_manual_input
            // 
            resources.ApplyResources(this.groupBox_manual_input, "groupBox_manual_input");
            this.groupBox_manual_input.Controls.Add(this.button_notpair);
            this.groupBox_manual_input.Controls.Add(this.buttonSupport);
            this.groupBox_manual_input.Controls.Add(this.button_pair);
            this.groupBox_manual_input.Name = "groupBox_manual_input";
            this.groupBox_manual_input.TabStop = false;
            // 
            // button_notpair
            // 
            resources.ApplyResources(this.button_notpair, "button_notpair");
            this.button_notpair.Name = "button_notpair";
            this.button_notpair.UseVisualStyleBackColor = true;
            this.button_notpair.Click += new System.EventHandler(this.button_notpair_Click);
            // 
            // buttonSupport
            // 
            resources.ApplyResources(this.buttonSupport, "buttonSupport");
            this.buttonSupport.Name = "buttonSupport";
            this.buttonSupport.UseVisualStyleBackColor = true;
            this.buttonSupport.Click += new System.EventHandler(this.buttonSupport_Click);
            // 
            // button_pair
            // 
            resources.ApplyResources(this.button_pair, "button_pair");
            this.button_pair.Name = "button_pair";
            this.button_pair.UseVisualStyleBackColor = true;
            this.button_pair.Click += new System.EventHandler(this.button_pair_Click);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox_manual_input);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonUImode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button_DeffoltLearn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.groupBox_manual_input.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button1;
        private Label label1;
        private Button button_DeffoltLearn;
        private ComboBox comboBox1;
        private Label label2;
        private Label label3;
        private Button buttonUImode;
        private Label label4;
        private GroupBox groupBox_manual_input;
        private Button buttonSupport;
        private Button button_pair;
        private Button button_notpair;
    }
}