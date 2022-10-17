using Perceptrone_logic;
using DataBlock;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace Perceptrone_UI
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// additional class for drawing
        /// </summary>
        
        #region variable
        public Perceptron myPerc;
        /// <summary>
        /// розмір вхідних даних по X
        /// </summary>
        private int sizeX = 13;
        /// <summary>
        /// розмір вхідних даних по Y
        /// </summary>
        private int sizeY = 13;

        private List<Tuple<int[], char>> dataToLearn;
        private List<Button> buttonListWithLetter;

        private int[]? selected_array = null;
        private char selected_char;

        #endregion

        #region ctor
        public Form1()
        {
            InitializeComponent();
            myPerc = new Perceptron(sizeX, sizeY, 1, 10, 33);
            dataToLearn = new List<Tuple<int[], char>>();
            InitializeMyLetterButton();
        }
        private void InitializeMyLetterButton()
        {
            char A_letter = Convert.ToChar(1040);
            char[] additionalVal = new char[7] { 'Ґ', 'Є', 'І', 'Ї', 'Ь', 'Ю', 'Я' };
            var massletter = new char[33];
            for (int i = 0; i < massletter.Length - 7; i++)
            {
                massletter[i] = A_letter++;
            }
            for (int i = 0; i < additionalVal.Length; i++)
            {
                massletter[massletter.Length - 7 + i] = additionalVal[i];
            }

            // create а-я button on screan
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

                groupBox_inputs.Controls.Add(temp);
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

                groupBox_inputs.Controls.Add(temp);
                buttonListWithLetter.Add(temp);
            }
        }
        #endregion


        private void ToolStripMenuItem_restart_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void AddToLearn(object sender, EventArgs e)
        {
            if (selected_array == null)
            {
                MessageBox.Show("Помилка: масив вхідних даних пустий!", "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var btn = sender as Button;
            selected_char = btn.Text[0];

            dataToLearn.Add(new Tuple<int[], char>(selected_array, selected_char));
            label_result.Text = "Елемент (" + selected_char + ") додано до масиву. Всього: " + dataToLearn.Count + " ел";
        }

        private void button_StarLearn_Click(object sender, EventArgs e)
        {
            if (dataToLearn.Count > 0)
            {
                var res = myPerc.StartLearn(dataToLearn);
                label_result.Text = "Навчання завершено! Пройдено " + res.Item1 + " епох, середньоквадратична помилка - " + res.Item2;
                dataToLearn.Clear();
            }
            else
            {
                MessageBox.Show("Список навчальних даних пустий!", "Інфо", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button_Recognize_Click(object sender, EventArgs e)
        {
            if (selected_array != null)
            {
                //label_rezult.Text = myPerc.Guess_letter(selected_array);
                var text = "";
                var rez = myPerc.Guess_letter_and_return_all_percent(selected_array);
                foreach (var item in rez)
                {
                    text += item + "\n";
                }
                label_result.Text = text;
            }
            else MessageBox.Show("Помилка: масив вхідних даних пустий!", "Помилка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ToolStripMenuItem_Save_AI_Click(object sender, EventArgs e)
        {
            var rez = myPerc.GetWeightToSave();
            string json = JsonSerializer.Serialize(rez);

            DialogResult res = saveFileDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, json);
                MessageBox.Show("Файл збережено в: " + saveFileDialog1.FileName, "Файл збережено!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Помилка вибору шляху!", "Не вибрано шлях!",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void ToolStripMenuItem_Load_AI_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "JSON|*.json";
            DialogResult res = openFileDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                string json = File.ReadAllText(openFileDialog1.FileName);
                myPerc.SetWeight(JsonSerializer.Deserialize<List<List<Tuple<char, List<double>>>>>(json));
            }
            else
            {
                MessageBox.Show("Помилка вибору шляху!", "Не вибрано файл!",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void ToolStripMenuItem_perceptronSettings_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            var dialog = new Form2();
            dialog.textBox_countOfHidenLayers.Text += myPerc.countOfHidenLayers;
            dialog.textBox_countOfNeuronInHidenLayer.Text += myPerc.countOfNeuronInHidenLayer;
            dialog.textBox_countOfNeuronInOutputLayer.Text += myPerc.countOfNeuronInOutputLayer;
            dialog.textBox_maxCountOfEpochs.Text += myPerc.countOfEpochs;
            dialog.textBox_Learning_speed.Text += myPerc.Learning_speed;
            dialog.ShowDialog();
            if(dialog.DialogResult == DialogResult.OK)
            {
                myPerc = new Perceptron(13,13, 
                    Convert.ToInt32(dialog.textBox_countOfHidenLayers.Text),
                    Convert.ToInt32(dialog.textBox_countOfNeuronInHidenLayer.Text),
                    Convert.ToInt32(dialog.textBox_countOfNeuronInOutputLayer.Text));
                myPerc.countOfEpochs = Convert.ToInt32(dialog.textBox_maxCountOfEpochs.Text);
                myPerc.Learning_speed = Convert.ToDouble(dialog.textBox_Learning_speed.Text);
            }
            dialog.Dispose();
            this.Enabled = true;
        }
    }
}