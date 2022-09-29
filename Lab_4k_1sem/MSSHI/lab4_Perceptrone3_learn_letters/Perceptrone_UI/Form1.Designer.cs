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
            this.label_SelectedArr = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Open = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_draw = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox_comands = new System.Windows.Forms.GroupBox();
            this.button_Recognize = new System.Windows.Forms.Button();
            this.button_StarLearn = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label_rezult
            // 
            resources.ApplyResources(this.label_rezult, "label_rezult");
            this.label_rezult.Name = "label_rezult";
            // 
            // label_SelectedArr
            // 
            resources.ApplyResources(this.label_SelectedArr, "label_SelectedArr");
            this.label_SelectedArr.Name = "label_SelectedArr";
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
            this.ToolStripMenuItem_draw});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            // 
            // ToolStripMenuItem_Open
            // 
            resources.ApplyResources(this.ToolStripMenuItem_Open, "ToolStripMenuItem_Open");
            this.ToolStripMenuItem_Open.Name = "ToolStripMenuItem_Open";
            this.ToolStripMenuItem_Open.Click += new System.EventHandler(this.ToolStripMenuItem_Open_Click);
            // 
            // ToolStripMenuItem_draw
            // 
            resources.ApplyResources(this.ToolStripMenuItem_draw, "ToolStripMenuItem_draw");
            this.ToolStripMenuItem_draw.Name = "ToolStripMenuItem_draw";
            this.ToolStripMenuItem_draw.Click += new System.EventHandler(this.ToolStripMenuItem_draw_Click);
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.label_SelectedArr);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
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
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button_Recognize);
            this.Controls.Add(this.button_StarLearn);
            this.Controls.Add(this.label_rezult);
            this.Controls.Add(this.groupBox_comands);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label label_rezult;
        private Label label_SelectedArr;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem файлToolStripMenuItem;
        private ToolStripMenuItem ToolStripMenuItem_Open;
        private TableLayoutPanel tableLayoutPanel1;
        private GroupBox groupBox1;
        private PictureBox pictureBox1;
        private OpenFileDialog openFileDialog1;
        private ToolStripMenuItem ToolStripMenuItem_draw;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private GroupBox groupBox_comands;
        private Button button_StarLearn;
        private Button button_Recognize;
    }
}