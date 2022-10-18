using Perceptrone_logic;
using DataBlock;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Linq;
using System.Data;
using System.Windows.Forms;
using System.Data.Common;

namespace Perceptrone_UI
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// additional class for drawing
        /// </summary>

        #region variable
        public Perceptron myPerc;

        private List<Tuple<int[], char>> dataToLearn;
        private List<CheckBox> listOfCheckBox;
        private List<string> listOfActiveCheckBox;

        private int[]? selected_array = null;
        private char selected_char;

        #endregion

        #region ctor
        public Form1()
        {
            InitializeComponent();
            dataToLearn = new List<Tuple<int[], char>>();
            InitializeMyCheckBoxes();
        }
        private void InitializeMyCheckBoxes()
        {
            listOfActiveCheckBox = new List<string>();
            List<string> nameOfDiseases = new List<string> {
                "Насморк", "Тошнота", "Біль в горлі", "Розлад кишечника",
                "Кашель", "Сухість в горлі", "Головні болі", "Слабкість",
                "Хрипи", "Болі в животі", "Відсутність апетиту", "Втрата пам'яті",
                "Чихання", "Температура", "Порушення сну", "Біль в м'язах" };
            listOfCheckBox = new List<CheckBox>();

            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    var temp = new CheckBox();
                    temp.Name = "checkBox_" + (j * 4 + i);
                    temp.Text = "" + nameOfDiseases[j * 4 + i];
                    temp.Size = new Size(150, 30);
                    temp.Location = new Point(10 + (i * temp.Size.Width), 30 + (j * temp.Size.Height));
                    temp.Font = new Font("Arial", 12);
                    //temp.Click += new EventHandler(some func);
                    listOfCheckBox.Add(temp);
                    groupBox_inputs.Controls.Add(temp);
                }
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
            if (dialog.DialogResult == DialogResult.OK)
            {
                myPerc = new Perceptron(listOfActiveCheckBox.Count,
                    Convert.ToInt32(dialog.textBox_countOfHidenLayers.Text),
                    Convert.ToInt32(dialog.textBox_countOfNeuronInHidenLayer.Text),
                    Convert.ToInt32(dialog.textBox_countOfNeuronInOutputLayer.Text));
                myPerc.countOfEpochs = Convert.ToInt32(dialog.textBox_maxCountOfEpochs.Text);
                myPerc.Learning_speed = Convert.ToDouble(dialog.textBox_Learning_speed.Text);
            }
            dialog.Dispose();
            this.Enabled = true;
        }

        private void ToolStripMenuItem_confirmInput_Click(object sender, EventArgs e)
        {
            foreach (var item in listOfCheckBox)
            {
                if (item.Checked)
                {
                    listOfActiveCheckBox.Add(item.Text);
                    dataGridView1.Columns.Add(new DataGridViewCheckBoxColumn()
                    {
                        Name = item.Text,
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader,
                    });
                    dataGridView2.Columns.Add(new DataGridViewCheckBoxColumn()
                    {
                        Name = item.Text,
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader,
                    });
                }
            }
            if (listOfActiveCheckBox.Count <= 0)
            {
                return;
            }
            myPerc = new Perceptron(listOfActiveCheckBox.Count, 1, 1, 1);

            dataGridView1.Columns.Add(new DataGridViewCheckBoxColumn()
            {
                Name = "Хворий грипом?",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader,
            });

            dataGridView2.Rows.Add();
            dataGridView2.Rows[0].Selected = false;

            groupBox_inputs.Enabled = false;
            ToolStripMenuItem_confirmInput.Enabled = false;
            ToolStripMenuItem_startLearn.Enabled = true;
            button_addExample.Enabled = true;
            button_deleteExample.Enabled = true;
        }

        private void button_addExample_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Selected = false;
                foreach (DataGridViewCell cell in row.Cells)
                {
                    // some code
                }
            }
        }

        private void button_deleteExample_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 1);
            }
        }
    }
}