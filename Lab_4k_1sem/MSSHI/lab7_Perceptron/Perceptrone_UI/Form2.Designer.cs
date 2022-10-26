namespace Perceptrone_UI
{
    partial class Form2
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
            this.button_submit = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.textBox_countOfHidenLayers = new System.Windows.Forms.TextBox();
            this.textBox_countOfNeuronInHidenLayer = new System.Windows.Forms.TextBox();
            this.textBox_countOfNeuronInOutputLayer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_maxCountOfEpochs = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_Learning_speed = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_submit
            // 
            this.button_submit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_submit.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_submit.Location = new System.Drawing.Point(96, 312);
            this.button_submit.Name = "button_submit";
            this.button_submit.Size = new System.Drawing.Size(126, 34);
            this.button_submit.TabIndex = 0;
            this.button_submit.Text = "Застосувати";
            this.button_submit.UseVisualStyleBackColor = true;
            this.button_submit.Click += new System.EventHandler(this.button_submit_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_cancel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_cancel.Location = new System.Drawing.Point(241, 312);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(126, 34);
            this.button_cancel.TabIndex = 1;
            this.button_cancel.Text = "Відмінити";
            this.button_cancel.UseVisualStyleBackColor = true;
            // 
            // textBox_countOfHidenLayers
            // 
            this.textBox_countOfHidenLayers.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox_countOfHidenLayers.Location = new System.Drawing.Point(16, 9);
            this.textBox_countOfHidenLayers.Name = "textBox_countOfHidenLayers";
            this.textBox_countOfHidenLayers.Size = new System.Drawing.Size(64, 33);
            this.textBox_countOfHidenLayers.TabIndex = 2;
            // 
            // textBox_countOfNeuronInHidenLayer
            // 
            this.textBox_countOfNeuronInHidenLayer.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox_countOfNeuronInHidenLayer.ImeMode = System.Windows.Forms.ImeMode.On;
            this.textBox_countOfNeuronInHidenLayer.Location = new System.Drawing.Point(16, 73);
            this.textBox_countOfNeuronInHidenLayer.Name = "textBox_countOfNeuronInHidenLayer";
            this.textBox_countOfNeuronInHidenLayer.Size = new System.Drawing.Size(64, 33);
            this.textBox_countOfNeuronInHidenLayer.TabIndex = 3;
            // 
            // textBox_countOfNeuronInOutputLayer
            // 
            this.textBox_countOfNeuronInOutputLayer.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox_countOfNeuronInOutputLayer.ImeMode = System.Windows.Forms.ImeMode.On;
            this.textBox_countOfNeuronInOutputLayer.Location = new System.Drawing.Point(16, 137);
            this.textBox_countOfNeuronInOutputLayer.Name = "textBox_countOfNeuronInOutputLayer";
            this.textBox_countOfNeuronInOutputLayer.Size = new System.Drawing.Size(64, 33);
            this.textBox_countOfNeuronInOutputLayer.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(254, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Кількість прихованих шарів";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(3, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(357, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Кількість нейронів в прихованому шарі";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(3, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(329, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "Кількість нейронів в вихідному шарі";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(3, 201);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(308, 25);
            this.label4.TabIndex = 8;
            this.label4.Text = "Максимальна ксть епох навчання";
            // 
            // textBox_maxCountOfEpochs
            // 
            this.textBox_maxCountOfEpochs.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox_maxCountOfEpochs.ImeMode = System.Windows.Forms.ImeMode.On;
            this.textBox_maxCountOfEpochs.Location = new System.Drawing.Point(16, 201);
            this.textBox_maxCountOfEpochs.Name = "textBox_maxCountOfEpochs";
            this.textBox_maxCountOfEpochs.Size = new System.Drawing.Size(64, 33);
            this.textBox_maxCountOfEpochs.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(3, 265);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(191, 25);
            this.label5.TabIndex = 10;
            this.label5.Text = "Швидкість навчання";
            // 
            // textBox_Learning_speed
            // 
            this.textBox_Learning_speed.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox_Learning_speed.ImeMode = System.Windows.Forms.ImeMode.On;
            this.textBox_Learning_speed.Location = new System.Drawing.Point(16, 265);
            this.textBox_Learning_speed.Name = "textBox_Learning_speed";
            this.textBox_Learning_speed.Size = new System.Drawing.Size(64, 33);
            this.textBox_Learning_speed.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button_submit);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.button_cancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(372, 358);
            this.panel1.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.textBox_Learning_speed);
            this.panel2.Controls.Add(this.textBox_maxCountOfEpochs);
            this.panel2.Controls.Add(this.textBox_countOfNeuronInOutputLayer);
            this.panel2.Controls.Add(this.textBox_countOfNeuronInHidenLayer);
            this.panel2.Controls.Add(this.textBox_countOfHidenLayers);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(372, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(107, 358);
            this.panel2.TabIndex = 13;
            // 
            // Form2
            // 
            this.AcceptButton = this.button_submit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_cancel;
            this.ClientSize = new System.Drawing.Size(479, 358);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form2";
            this.Text = "Налаштування Перцептрона";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Button button_submit;
        private Button button_cancel;
        public TextBox textBox_countOfHidenLayers;
        public TextBox textBox_countOfNeuronInHidenLayer;
        public TextBox textBox_countOfNeuronInOutputLayer;
        public TextBox textBox_maxCountOfEpochs;
        public TextBox textBox_Learning_speed;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Panel panel1;
        private Panel panel2;
    }
}