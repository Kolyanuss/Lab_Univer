using Perceptron_logic;
using DataBlock;

namespace Perceptrone_UI
{
    public partial class Form1 : Form
    {
        public Perceptron myPerc;
        private int[] selected_array;
        private List<CheckBox> listOfCheckBox;
        private List<Tuple<int[], bool>> listDataToLearn;

        public Form1()
        {
            InitializeComponent();
            myPerc = new Perceptron();
        }

        private void button_DeffoltLearn_Click(object sender, EventArgs e)
        {
            button_DeffoltLearn.Enabled = false;
            buttonUImode.Enabled = false;
            groupBox_manual_input.Enabled = false;
            button_DeffoltLearn.Text = "Зачекайте, триває навчання";
            myPerc.LearnBySeveralArr(DataForLearn.NumForLearn);
            button_DeffoltLearn.Text = "Готово!";
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
            groupBox_manual_input.Visible = true;
            listOfCheckBox = new List<CheckBox>();
            listDataToLearn = new List<Tuple<int[], bool>>();

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    var checkBox = new CheckBox();
                    checkBox.AutoSize = true;
                    checkBox.Size = new Size(20, 20);
                    checkBox.Location = new Point(10 + (j * checkBox.Size.Width), 30 + (i * checkBox.Size.Height));
                    checkBox.Name = "checkBox" + i;
                    checkBox.UseVisualStyleBackColor = true;

                    listOfCheckBox.Add(checkBox);
                    groupBox_manual_input.Controls.Add(checkBox);
                }
            }
            buttonSupport.Visible = true;
            button_pair.Visible = true;
            button_notpair.Visible = true;
        }

        private void button_pair_Click(object sender, EventArgs e)
        {
            int[] arr = new int[listOfCheckBox.Count];
            for (int i = 0; i < listOfCheckBox.Count; i++)
            {
                if (listOfCheckBox[i].Checked)
                {
                    arr[i] = 1;
                    listOfCheckBox[i].Checked = false;
                }
                else arr[i] = 0;
            }
            listDataToLearn.Add(new Tuple<int[], bool>(arr, true));
            buttonSupport.Enabled = true;
        }

        private void button_notpair_Click(object sender, EventArgs e)
        {
            var arr = new int[Perceptron.size];
            for (int i = 0; i < listOfCheckBox.Count; i++)
            {
                if (listOfCheckBox[i].Checked)
                {
                    arr[i] = 1;
                    listOfCheckBox[i].Checked = false;
                }
                else arr[i] = 0;
            }
            listDataToLearn.Add(new Tuple<int[], bool>(arr, false));
            buttonSupport.Enabled = true;
        }

        private void buttonSupport_Click(object sender, EventArgs e)
        {
            groupBox_manual_input.Enabled = false;
            button_DeffoltLearn.Enabled = false;
            buttonUImode.Enabled = false;

            buttonSupport.Text = "Зачекайте, триває навчання";
            myPerc.LearnBySeveralArr(this.listDataToLearn);
            buttonSupport.Text = "Готово!";
            comboBox1.Enabled = true;
        }

    }
}