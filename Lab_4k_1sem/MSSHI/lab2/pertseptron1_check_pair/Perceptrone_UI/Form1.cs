using Perceptron_logic;
using DataBlock;

namespace Perceptrone_UI
{
    public partial class Form1 : Form
    {
        public Perceptron myPerc;
        private int[] selected_array;
        private List<CheckBox> listOfCheckBox;
        public Form1()
        {
            InitializeComponent();
            myPerc = new Perceptron();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            buttonDeffoltLearn.Enabled = false;
            buttonUImode.Enabled = false;
            buttonDeffoltLearn.Text = "Зачекайте, триває навчання";
            myPerc.LearnBySeveralArr(DataForLearn.NumForLearn);
            buttonDeffoltLearn.Text = "Готово!";
            comboBox1.Enabled = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
            selected_array = DataForLearn.NumForLearn[Convert.ToInt32(comboBox1.Text)].Item1;
            label3.Text = "";
            foreach (var item in selected_array)
            {
                label3.Text += item + " ";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label2.Text = myPerc.CheckNum(selected_array);
        }

        private void buttonUImode_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            listOfCheckBox = new List<CheckBox>();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    var checkBox = new CheckBox();
                    checkBox.AutoSize = true;
                    checkBox.Size = new Size(20, 20);
                    checkBox.Location = new Point(20 + (j * checkBox.Size.Width), 30 + (i * checkBox.Size.Height));
                    checkBox.Name = "checkBox" + i;
                    checkBox.UseVisualStyleBackColor = true;

                    listOfCheckBox.Add(checkBox);
                    //Controls.Add(checkBox);
                    groupBox1.Controls.Add(checkBox);
                }
            }
            buttonSupport.Visible = true;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }
    }
}