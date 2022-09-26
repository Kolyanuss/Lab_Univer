using Perceptrone_logic;
using DataBlock;

namespace Perceptrone_UI
{
    public partial class Form1 : Form
    {
        public Perceptron myPerc;
        private List<Tuple<int[], char>> dataToLearn;
        private int[] selected_array;
        private char selected_char;
        private string filePath = string.Empty;

        private int sizeX = 15;
        private int sizeY = 15;

        public Form1()
        {
            InitializeComponent();
            myPerc = new Perceptron(sizeX, sizeY);
            dataToLearn = new List<Tuple<int[], char>>();
        }

        private bool checkFilePath()
        {
            if (string.IsNullOrEmpty(filePath) || string.IsNullOrWhiteSpace(filePath))
            {
                MessageBox.Show("Картинка не вибрана", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void toolStripButton_AddToLearn_Click(object sender, EventArgs e)
        {
            if (checkFilePath())
            {
                if (selected_array == null)
                {
                    MessageBox.Show("Помилка читання картинки", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrEmpty(toolStripTextBox1.Text))
                {
                    MessageBox.Show("Ви не ввели букву. \nВведіть її", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                selected_char = toolStripTextBox1.Text.ToCharArray()[0];
                toolStripTextBox1.Text = "";

                dataToLearn.Add(new Tuple<int[], char>(selected_array, selected_char));
                toolStripButton_StartLearn.Enabled = true;
            }
        }

        private void toolStripButton_StartLearn_Click(object sender, EventArgs e)
        {
            toolStripButton_AddToLearn.Enabled = false;
            toolStripButton_StartLearn.Enabled = false;
            toolStripTextBox1.Enabled = false;
            toolStripLabel1.Enabled = false;
            myPerc.StartLearn(dataToLearn);
            toolStripButton_Recognize.Enabled = true;
        }

        private void toolStripButton_Recognize_Click(object sender, EventArgs e)
        {
            if (checkFilePath())
            {
                if (selected_array != null)
                {
                    label_rezult.Text = myPerc.Guess_letter(selected_array);
                }
                else MessageBox.Show("Помилка читання картинки", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                MessageBox.Show("Картинка не вибрана", "Потрібно вибрати картинку", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}