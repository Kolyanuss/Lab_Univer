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
            this.label_rezult = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Open = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox_comands = new System.Windows.Forms.GroupBox();
            this.button_Recognize = new System.Windows.Forms.Button();
            this.button_StarLearn = new System.Windows.Forms.Button();
            this.label_SelectedArr = new System.Windows.Forms.Label();
            this.button_resetImage = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ToolStripMenuItem_restart = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_rezult
            // 
            resources.ApplyResources(this.label_rezult, "label_rezult");
            this.label_rezult.Name = "label_rezult";
            // 
            // menuStrip1
            // 
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this.menuStrip1.Name = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            resources.ApplyResources(this.файлToolStripMenuItem, "файлToolStripMenuItem");
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_Open,
            this.ToolStripMenuItem_restart});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            // 
            // ToolStripMenuItem_Open
            // 
            resources.ApplyResources(this.ToolStripMenuItem_Open, "ToolStripMenuItem_Open");
            this.ToolStripMenuItem_Open.Name = "ToolStripMenuItem_Open";
            this.ToolStripMenuItem_Open.Click += new System.EventHandler(this.ToolStripMenuItem_Open_Click);
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // openFileDialog1
            // 
            resources.ApplyResources(this.openFileDialog1, "openFileDialog1");
            // 
            // groupBox_comands
            // 
            resources.ApplyResources(this.groupBox_comands, "groupBox_comands");
            this.groupBox_comands.Name = "groupBox_comands";
            this.groupBox_comands.TabStop = false;
            // 
            // button_Recognize
            // 
            resources.ApplyResources(this.button_Recognize, "button_Recognize");
            this.button_Recognize.Name = "button_Recognize";
            this.button_Recognize.UseVisualStyleBackColor = true;
            this.button_Recognize.Click += new System.EventHandler(this.button_Recognize_Click);
            // 
            // button_StarLearn
            // 
            resources.ApplyResources(this.button_StarLearn, "button_StarLearn");
            this.button_StarLearn.Name = "button_StarLearn";
            this.button_StarLearn.UseVisualStyleBackColor = true;
            this.button_StarLearn.Click += new System.EventHandler(this.button_StarLearn_Click);
            // 
            // label_SelectedArr
            // 
            resources.ApplyResources(this.label_SelectedArr, "label_SelectedArr");
            this.label_SelectedArr.Name = "label_SelectedArr";
            // 
            // button_resetImage
            // 
            resources.ApplyResources(this.button_resetImage, "button_resetImage");
            this.button_resetImage.Name = "button_resetImage";
            this.button_resetImage.UseVisualStyleBackColor = true;
            this.button_resetImage.Click += new System.EventHandler(this.button_resetImage_Click);
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.groupBox_comands);
            this.panel1.Controls.Add(this.label_rezult);
            this.panel1.Controls.Add(this.button_StarLearn);
            this.panel1.Controls.Add(this.button_Recognize);
            this.panel1.Name = "panel1";
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Controls.Add(this.label_SelectedArr);
            this.panel2.Controls.Add(this.button_resetImage);
            this.panel2.Name = "panel2";
            // 
            // ToolStripMenuItem_restart
            // 
            resources.ApplyResources(this.ToolStripMenuItem_restart, "ToolStripMenuItem_restart");
            this.ToolStripMenuItem_restart.Name = "ToolStripMenuItem_restart";
            this.ToolStripMenuItem_restart.Click += new System.EventHandler(this.ToolStripMenuItem_restart_Click);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label label_rezult;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem файлToolStripMenuItem;
        private ToolStripMenuItem ToolStripMenuItem_Open;
        private PictureBox pictureBox1;
        private OpenFileDialog openFileDialog1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private GroupBox groupBox_comands;
        private Button button_StarLearn;
        private Button button_Recognize;
        private Label label_SelectedArr;
        private Button button_resetImage;
        private Panel panel1;
        private Panel panel2;
        private ToolStripMenuItem ToolStripMenuItem_restart;
    }
}