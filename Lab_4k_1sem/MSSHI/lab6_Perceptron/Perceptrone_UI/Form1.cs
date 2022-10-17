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
        private class ArrayPoints
        {
            private int index = 0;
            private Point[] points;
            public ArrayPoints(int size)
            {
                if (size <= 0) { size = 2; }
                points = new Point[size];
            }
            public void SetPoint(int x, int y)
            {
                if (index >= points.Length) { index = 0; }
                points[index++] = new Point(x, y);
            }
            public void ResetPoints()
            {
                index = 0;
            }
            public int GetCountPoints() { return index; }
            public Point[] GetPoints() { return points; }
        }

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

        /// <summary>
        /// змінна яка вказує на те чи картинка та масив активних вхідів будуть очщатись після їх використання
        /// </summary>
        private bool isAutoClear = false;

        #region variable for drawing
        private bool isMouseDown = false;
        private ArrayPoints arrayPoints = new ArrayPoints(2);
        Bitmap map = new Bitmap(10, 10);
        Graphics graphics;
        Pen pen = new Pen(Color.Black, 3f);
        #endregion
        #endregion

        #region ctor
        public Form1()
        {
            InitializeComponent();
            myPerc = new Perceptron(sizeX, sizeY, 1, 10, 33);
            dataToLearn = new List<Tuple<int[], char>>();
            InitializeMyLetterButton();
            InitializeSizeBitmap();
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
        private void InitializeSizeBitmap()
        {
            map = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(map);
            graphics.Clear(pictureBox1.BackColor);
            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        }
        #endregion

        private void DrawEntrances()
        {
            selected_array = MyImageConverter.GetArrFromImage(pictureBox1.Image, myPerc.sizeX, myPerc.sizeY);
            label_SelectedArr.Text = "";
            for (int i = 0; i < selected_array.Length; i++)
            {
                label_SelectedArr.Text += selected_array[i];
                if (i % sizeX == sizeX - 1)
                {
                    label_SelectedArr.Text += "\n";
                }
                else label_SelectedArr.Text += "  ";
            }
        }
        private void ClearUI()
        {
            graphics.Clear(pictureBox1.BackColor);
            pictureBox1.Image = map;
            selected_array = null;
            label_SelectedArr.Text = "";
            label_rezult.Text = "";
        }

        private void ToolStripMenuItem_Open_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "JPG and PNG|*.jpg;*.png";
            DialogResult res = openFileDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                map = new Bitmap(Image.FromFile(openFileDialog1.FileName), pictureBox1.Width, pictureBox1.Height);
                graphics = Graphics.FromImage(map);
                pictureBox1.Image = map;
                DrawEntrances();
            }
            else
            {
                MessageBox.Show("Картинка не вибрана", "Потрібно вибрати картинку",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void ToolStripMenuItem_restart_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void ToolStripMenuItem_AutoClear_Click(object sender, EventArgs e)
        {
            isAutoClear = !isAutoClear;
            if (isAutoClear)
            {
                ToolStripMenuItem_AutoClear.Text = "Виключити Автоочищення";
            }
            else
            {
                ToolStripMenuItem_AutoClear.Text = "Включити Автоочищення";
            }
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
            label_rezult.Text = "Елемент (" + selected_char + ") додано до масиву. Всього: " + dataToLearn.Count + " ел";

            if (isAutoClear) { ClearUI(); }
        }

        private void button_StarLearn_Click(object sender, EventArgs e)
        {
            if (dataToLearn.Count > 0)
            {
                var res = myPerc.StartLearn(dataToLearn);
                label_rezult.Text = "Навчання завершено! Пройдено " + res.Item1 + " епох, середньоквадратична помилка - " + res.Item2;
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
                label_percent_from_letter.Text = text;

                if (isAutoClear) { ClearUI(); }
            }
            else MessageBox.Show("Помилка: масив вхідних даних пустий!", "Помилка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseDown = true;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
            arrayPoints.ResetPoints();
            DrawEntrances();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isMouseDown) { return; }
            arrayPoints.SetPoint(e.X, e.Y);
            if (arrayPoints.GetCountPoints() >= 2)
            {
                graphics.DrawLines(pen, arrayPoints.GetPoints());
                pictureBox1.Image = map;
                arrayPoints.SetPoint(e.X, e.Y);
            }
        }

        private void button_resetImage_Click(object sender, EventArgs e)
        {
            ClearUI();
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
            ClearUI();
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