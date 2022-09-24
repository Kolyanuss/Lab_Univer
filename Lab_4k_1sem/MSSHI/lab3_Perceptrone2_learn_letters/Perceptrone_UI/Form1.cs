using lab3_Perceptrone2_learn_letters;
using DataBlock;

namespace Perceptrone_UI
{
    public partial class Form1 : Form
    {
        public Perceptron myPerc;
        private List<Tuple<int[], char>> dataToLearn;
        private int[] selected_array;
        private char selected_char;

        public Form1()
        {
            InitializeComponent();
            myPerc = new Perceptron();
            dataToLearn = new List<Tuple<int[], char>>();
        }

        private void toolStripButton_AddToLearn_Click(object sender, EventArgs e)
        {
            if (selected_array != null)
            {
                dataToLearn.Add(new Tuple<int[], char>(selected_array, selected_char));
                selected_array = null;
                selected_char = Convert.ToChar(0);
                toolStripButton_StartLearn.Enabled = true;
            }
            else label_rezult.Text = "Відкрийте картинку з буквою";
        }

        private void toolStripButton_StartLearn_Click(object sender, EventArgs e)
        {
            toolStripButton_AddToLearn.Enabled = false;
            myPerc.StartLearn(dataToLearn);
            toolStripButton_Recognize.Enabled = true;
        }

        private void toolStripButton_Recognize_Click(object sender, EventArgs e)
        {
            if (selected_array != null)
            {
                label_rezult.Text = myPerc.Guess_letter(selected_array);
            }
            else label_rezult.Text = "Відкрийте картинку з буквою";
        }
    }
}