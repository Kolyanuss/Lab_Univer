using Perceptrone_logic;
using DataBlock;
using System.Resources;
using System.Windows.Forms;

namespace Perceptrone_UI
{
    public partial class Form1 : Form
    {
        public Perceptron myPerc;
        private List<Tuple<int[], char>> dataToLearn;
        private int[] selected_array;
        private char selected_char;
        private string filePath = string.Empty;

        private List<Button> buttonListWithLetter;

        private int sizeX = 15;
        private int sizeY = 15;

        public Form1()
        {
            InitializeComponent();
            myPerc = new Perceptron(sizeX, sizeY);
            dataToLearn = new List<Tuple<int[], char>>();
            InitializeMyLetterButton();
        }

        private void InitializeMyLetterButton()
        {
            char A_letter = Convert.ToChar(1040);
            char[] additionalVal = new char[7] { '�', '�', '�', '�', '�', '�', '�' };
            var massletter = new char[33];
            for (int i = 0; i < massletter.Length - 7; i++)
            {
                massletter[i] = A_letter++;
            }
            for (int i = 0; i < additionalVal.Length; i++)
            {
                massletter[massletter.Length - 7 + i] = additionalVal[i];
            }

            // create �-� button on screan
            buttonListWithLetter = new List<Button>();

            for (int i = 0; i < 33 / 2; i++)
            {
                var temp = new Button();
                temp.Name = "button_letter_" + massletter[i];
                temp.Text = "" + massletter[i];
                temp.UseVisualStyleBackColor = true;
                temp.Size = new Size(32, 30);
                temp.Location = new Point(3 + (i * temp.Size.Width), 10);
                temp.Font = new Font("Arial", 12);
                temp.Click += new EventHandler(AddToLearn);

                groupBox_comands.Controls.Add(temp);
                buttonListWithLetter.Add(temp);
            }

            for (int i = 0; i < 33 / 2 + 1; i++)
            {
                var temp = new Button();
                temp.Name = "button_letter_" + massletter[i + 33 / 2];
                temp.Text = "" + massletter[i + 33 / 2];
                temp.UseVisualStyleBackColor = true;
                temp.Size = new Size(32, 30);
                temp.Location = new Point(3 + (i * temp.Size.Width), 10 + temp.Size.Height);
                temp.Font = new Font("Arial", 12);
                temp.Click += new EventHandler(AddToLearn);

                groupBox_comands.Controls.Add(temp);
                buttonListWithLetter.Add(temp);
            }
        }

        private bool checkFilePath()
        {
            if (string.IsNullOrEmpty(filePath) || string.IsNullOrWhiteSpace(filePath))
            {
                MessageBox.Show("�������� �� �������", "�������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void ToolStripMenuItem_Open_Click(object sender, EventArgs e)
        {
            DialogResult res = openFileDialog1.ShowDialog();

            if (res == DialogResult.OK)
            {
                filePath = openFileDialog1.FileName;
                pictureBox1.Image = Image.FromFile(filePath);
                selected_array = MyImageConverter.GetArrFromImage(filePath, myPerc.sizeX, myPerc.sizeY);

                label_SelectedArr.Text = "";
                for (int i = 0; i < selected_array.Length; i++)
                {
                    label_SelectedArr.Text += selected_array[i] + " ";
                    if (i % sizeX == sizeX - 1)
                    {
                        label_SelectedArr.Text += "\n";
                    }
                }
            }
            else
            {
                MessageBox.Show("�������� �� �������", "������� ������� ��������", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void ToolStripMenuItem_draw_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            filePath = string.Empty;
            selected_array = new int[myPerc.generalSize];
            label_SelectedArr.Text = "";
        }

        private void AddToLearn(object sender, EventArgs e)
        {
            if (checkFilePath())
            {
                if (selected_array == null)
                {
                    MessageBox.Show("�������: ����� ������� ����� ������!", "�������",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var btn = sender as Button;                
                selected_char = btn.Text[0];                

                dataToLearn.Add(new Tuple<int[], char>(selected_array, selected_char));
                label_rezult.Text = "������� ("+ selected_char +") ������ �� ������. ������: "+dataToLearn.Count + " ��";
                button_StarLearn.Enabled = true;
            }
        }

        private void button_StarLearn_Click(object sender, EventArgs e)
        {
            groupBox_comands.Enabled = false;
            button_StarLearn.Enabled = false;
            myPerc.StartLearn(dataToLearn);
            button_Recognize.Enabled = true;
            label_rezult.Text = "�������� ���������!";
        }

        private void button_Recognize_Click(object sender, EventArgs e)
        {
            if (checkFilePath())
            {
                if (selected_array != null)
                {
                    label_rezult.Text = myPerc.Guess_letter(selected_array);
                }
                else MessageBox.Show("������� ������� ��������", "�������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}