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
            this.відкритиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_AddToLearn = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_StartLearn = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Recognize = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
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
            this.відкритиToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            // 
            // відкритиToolStripMenuItem
            // 
            resources.ApplyResources(this.відкритиToolStripMenuItem, "відкритиToolStripMenuItem");
            this.відкритиToolStripMenuItem.Name = "відкритиToolStripMenuItem";
            // 
            // toolStrip1
            // 
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_AddToLearn,
            this.toolStripButton_StartLearn,
            this.toolStripSeparator1,
            this.toolStripButton_Recognize});
            this.toolStrip1.Name = "toolStrip1";
            // 
            // toolStripButton_AddToLearn
            // 
            resources.ApplyResources(this.toolStripButton_AddToLearn, "toolStripButton_AddToLearn");
            this.toolStripButton_AddToLearn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_AddToLearn.Name = "toolStripButton_AddToLearn";
            this.toolStripButton_AddToLearn.Click += new System.EventHandler(this.toolStripButton_AddToLearn_Click);
            // 
            // toolStripButton_StartLearn
            // 
            resources.ApplyResources(this.toolStripButton_StartLearn, "toolStripButton_StartLearn");
            this.toolStripButton_StartLearn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_StartLearn.Name = "toolStripButton_StartLearn";
            this.toolStripButton_StartLearn.Click += new System.EventHandler(this.toolStripButton_StartLearn_Click);
            // 
            // toolStripButton_Recognize
            // 
            resources.ApplyResources(this.toolStripButton_Recognize, "toolStripButton_Recognize");
            this.toolStripButton_Recognize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_Recognize.Name = "toolStripButton_Recognize";
            this.toolStripButton_Recognize.Click += new System.EventHandler(this.toolStripButton_Recognize_Click);
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
            this.groupBox1.Controls.Add(this.label_rezult);
            this.groupBox1.Controls.Add(this.label_SelectedArr);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            resources.ApplyResources(this.openFileDialog1, "openFileDialog1");
            // 
            // toolStripSeparator1
            // 
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
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
        private ToolStripMenuItem відкритиToolStripMenuItem;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButton_Recognize;
        private ToolStripButton toolStripButton_AddToLearn;
        private ToolStripButton toolStripButton_StartLearn;
        private TableLayoutPanel tableLayoutPanel1;
        private GroupBox groupBox1;
        private PictureBox pictureBox1;
        private OpenFileDialog openFileDialog1;
        private ToolStripSeparator toolStripSeparator1;
    }
}