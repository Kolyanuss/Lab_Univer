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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ToolStripMenuItem_File = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Save_AI = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Load_AI = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_restart = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_perceptronSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_confirmInput = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_startLearn = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_recognize = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupBox_inputs = new System.Windows.Forms.GroupBox();
            this.groupBox_examples = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button_deleteExample = new System.Windows.Forms.Button();
            this.button_addExample = new System.Windows.Forms.Button();
            this.groupBox_result = new System.Windows.Forms.GroupBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label_result = new System.Windows.Forms.Label();
            this.groupBox_outputs = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.groupBox_examples.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox_result.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_File,
            this.ToolStripMenuItem_perceptronSettings,
            this.ToolStripMenuItem_confirmInput,
            this.ToolStripMenuItem_startLearn,
            this.ToolStripMenuItem_recognize});
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
            // ToolStripMenuItem_perceptronSettings
            // 
            resources.ApplyResources(this.ToolStripMenuItem_perceptronSettings, "ToolStripMenuItem_perceptronSettings");
            this.ToolStripMenuItem_perceptronSettings.Name = "ToolStripMenuItem_perceptronSettings";
            this.ToolStripMenuItem_perceptronSettings.Click += new System.EventHandler(this.ToolStripMenuItem_perceptronSettings_Click);
            // 
            // ToolStripMenuItem_confirmInput
            // 
            resources.ApplyResources(this.ToolStripMenuItem_confirmInput, "ToolStripMenuItem_confirmInput");
            this.ToolStripMenuItem_confirmInput.Name = "ToolStripMenuItem_confirmInput";
            this.ToolStripMenuItem_confirmInput.Click += new System.EventHandler(this.ToolStripMenuItem_confirmInput_Click);
            // 
            // ToolStripMenuItem_startLearn
            // 
            resources.ApplyResources(this.ToolStripMenuItem_startLearn, "ToolStripMenuItem_startLearn");
            this.ToolStripMenuItem_startLearn.Name = "ToolStripMenuItem_startLearn";
            this.ToolStripMenuItem_startLearn.Click += new System.EventHandler(this.button_StarLearn_Click);
            // 
            // ToolStripMenuItem_recognize
            // 
            resources.ApplyResources(this.ToolStripMenuItem_recognize, "ToolStripMenuItem_recognize");
            this.ToolStripMenuItem_recognize.Name = "ToolStripMenuItem_recognize";
            this.ToolStripMenuItem_recognize.Click += new System.EventHandler(this.button_Recognize_Click);
            // 
            // openFileDialog1
            // 
            resources.ApplyResources(this.openFileDialog1, "openFileDialog1");
            // 
            // saveFileDialog1
            // 
            resources.ApplyResources(this.saveFileDialog1, "saveFileDialog1");
            // 
            // groupBox_inputs
            // 
            resources.ApplyResources(this.groupBox_inputs, "groupBox_inputs");
            this.groupBox_inputs.Name = "groupBox_inputs";
            this.groupBox_inputs.TabStop = false;
            // 
            // groupBox_examples
            // 
            resources.ApplyResources(this.groupBox_examples, "groupBox_examples");
            this.groupBox_examples.Controls.Add(this.dataGridView1);
            this.groupBox_examples.Controls.Add(this.button_deleteExample);
            this.groupBox_examples.Controls.Add(this.button_addExample);
            this.groupBox_examples.Name = "groupBox_examples";
            this.groupBox_examples.TabStop = false;
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
            this.dataGridView2.RowTemplate.Height = 25;
            // 
            // label_result
            // 
            resources.ApplyResources(this.label_result, "label_result");
            this.label_result.Name = "label_result";
            // 
            // groupBox_outputs
            // 
            resources.ApplyResources(this.groupBox_outputs, "groupBox_outputs");
            this.groupBox_outputs.Name = "groupBox_outputs";
            this.groupBox_outputs.TabStop = false;
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.groupBox_outputs);
            this.panel1.Controls.Add(this.groupBox_inputs);
            this.panel1.Name = "panel1";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label_result);
            this.Controls.Add(this.groupBox_result);
            this.Controls.Add(this.groupBox_examples);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox_examples.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox_result.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem ToolStripMenuItem_File;
        private OpenFileDialog openFileDialog1;
        private ToolStripMenuItem ToolStripMenuItem_restart;
        private ToolStripMenuItem ToolStripMenuItem_startLearn;
        private ToolStripMenuItem ToolStripMenuItem_recognize;
        private ToolStripMenuItem ToolStripMenuItem_Save_AI;
        private ToolStripMenuItem ToolStripMenuItem_Load_AI;
        private SaveFileDialog saveFileDialog1;
        private ToolStripMenuItem ToolStripMenuItem_perceptronSettings;
        private GroupBox groupBox_inputs;
        private GroupBox groupBox_examples;
        private GroupBox groupBox_result;
        private Label label_result;
        private ToolStripMenuItem ToolStripMenuItem_confirmInput;
        private Button button_deleteExample;
        private Button button_addExample;
        private DataGridView dataGridView1;
        private DataGridView dataGridView2;
        private GroupBox groupBox_outputs;
        private Panel panel1;
    }
}