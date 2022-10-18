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

        private List<Tuple<int[], double[]>> listExamples;
        private List<CheckBox> listOfCheckBox;
        private List<string> listOfActiveCheckBox;

        private int[]? selected_array = null;
        private char selected_char;

        #endregion

        #region ctor
        public Form1()
        {
            InitializeComponent();
            InitializeMyCheckBoxes();
            listExamples = new List<Tuple<int[], double[]>>();
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


        private void button_StarLearn_Click(object sender, EventArgs e)
        {
            dataGridView1.EndEdit();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                var vector = new int[row.Cells.Count - 1];
                var i = 0;
                for (i = 0; i < row.Cells.Count - 1; i++)
                {
                    vector[i] = Convert.ToBoolean(row.Cells[i].Value) ? 1 : 0;
                }
                double desire = Convert.ToBoolean(row.Cells[i].Value) ? 1 : 0;
                listExamples.Add(new Tuple<int[], double[]>(vector, new double[1] { desire }));
            }

            if (listExamples.Count > 0)
            {
                var res = myPerc.StartLearn(listExamples);
                label_result.Text = "Навчання завершено! Пройдено " + res.Item1 + " епох, середньоквадратична помилка - " + res.Item2;
                listExamples.Clear();
            }
            else
            {
                MessageBox.Show("Список навчальних даних пустий!", "Інфо", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            ToolStripMenuItem_recognize.Enabled = true;
        }

        private void button_Recognize_Click(object sender, EventArgs e)
        {
            dataGridView2.EndEdit();
            var cells = dataGridView2.Rows[0].Cells;
            selected_array = new int[cells.Count];
            for (var i = 0; i < cells.Count; i++)
            {
                selected_array[i] = Convert.ToBoolean(cells[i].Value) ? 1 : 0;
            }

            var res = myPerc.Get_result(selected_array);
            label_result.Text = "Вірогідність що ти хворий грипом: " + String.Format("{0:0.00}", res[0] * 100) + "%";
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
            var i = dataGridView1.Rows.Add();
            dataGridView1.Rows[i].Selected = false;
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