using Perceptrone_logic;
using System.Text.Json;
using System.Data;

namespace Perceptrone_UI
{
    public partial class Form1 : Form
    {
        #region variable
        public NeuronNetwork myNetwork;

        private List<Tuple<double[], double[]>> listExamples;
        private List<NumericUpDown> listNumericUpDown;

        private double[]? selected_array = null;

        #endregion

        #region ctor
        public Form1()
        {
            InitializeComponent();
            listExamples = new List<Tuple<double[], double[]>>();
            listNumericUpDown = new List<NumericUpDown>();

            listNumericUpDown.Add(numericUpDown_CountOfNeuronInHidelLayer_1);
            listNumericUpDown.Add(numericUpDown_CountOfNeuronInHidelLayer_2);
            listNumericUpDown.Add(numericUpDown_CountOfNeuronInHidelLayer_3);
            listNumericUpDown.Add(numericUpDown_CountOfNeuronInHidelLayer_4);
            listNumericUpDown.Add(numericUpDown_CountOfNeuronInHidelLayer_5);
            listNumericUpDown.Add(numericUpDown_CountOfNeuronInHidelLayer_6);
            listNumericUpDown.Add(numericUpDown_CountOfNeuronInHidelLayer_7);
            listNumericUpDown.Add(numericUpDown_CountOfNeuronInHidelLayer_8);
            listNumericUpDown.Add(numericUpDown_CountOfNeuronInHidelLayer_9);
            listNumericUpDown.Add(numericUpDown_CountOfNeuronInHidelLayer_10);
        }
        #endregion

        #region my func
        private DataGridViewTextBoxColumn GetTextBoxColumn(string text)
        {
            var res = new DataGridViewTextBoxColumn()
            {
                Name = text,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,

            };
            return res;
        }
        private void ConfirmDesignNetwork()
        {
            // Create network
            int CountInput = Convert.ToInt32(numericUpDown_countOfNeuronInIntputLayer.Value);
            int CountHiden = Convert.ToInt32(numericUpDown_countOfHidenLayers.Value);
            int CountOuput = Convert.ToInt32(numericUpDown_countOfNeuronInOutputLayer.Value);
            int[] ArrCountNeuron = new int[CountHiden];
            for (int i = 0; i < CountHiden; i++)
            {
                ArrCountNeuron[i] = (int)listNumericUpDown[i].Value;
            }
            myNetwork = new NeuronNetwork(CountInput, CountHiden, ArrCountNeuron, CountOuput);

            // clear table
            dataGridView1.Columns.Clear();
            dataGridView2.Columns.Clear();
            // initialize table
            for (int i = 0; i < myNetwork.countOfInputEntrances; i++)
            {
                dataGridView1.Columns.Add(GetTextBoxColumn("x" + (i + 1)));
                dataGridView2.Columns.Add(GetTextBoxColumn("x" + (i + 1)));
            }
            for (int i = 0; i < myNetwork.countOfNeuronInOutputLayer; i++)
            {
                dataGridView1.Columns.Add(GetTextBoxColumn("y" + (i + 1)));
            }
            dataGridView2.Rows.Add();
            dataGridView2.Rows[0].Selected = false;

            // unlock button
            button__StartLearn.Enabled = true;
            button_addExample.Enabled = true;
            button_deleteExample.Enabled = true;
            button_CreateNetwork.Text = "Мережа успішно створена!";
        }

        private void StartLearn()
        {
            dataGridView1.EndEdit();
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    var vector_train = new double[myNetwork.countOfInputEntrances];
                    for (var i = 0; i < vector_train.Length; i++)
                    {
                        vector_train[i] = Convert.ToDouble(row.Cells[i].Value.ToString().Split('%')[0]);
                    }

                    var vector_desire = new double[myNetwork.countOfNeuronInOutputLayer];
                    for (var i = 0; i < vector_desire.Length; i++)
                    {
                        int current_index = i + vector_train.Length;
                        vector_desire[i] = Convert.ToDouble(row.Cells[current_index].Value.ToString().Split('%')[0]);
                    }

                    listExamples.Add(new Tuple<double[], double[]>(vector_train, vector_desire));
                }
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message + "\nНе залишайте пустих полів", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                listExamples.Clear();
                return;
            }

            if (listExamples.Count <= 0)
            {
                MessageBox.Show("Список навчальних даних пустий! \n Добавте приклади", "Інфо",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            int LearnSpeed = Convert.ToInt32(numericUpDown_Learning_speed.Value);
            int CountOfEpochs = Convert.ToInt32(numericUpDown_maxCountOfEpochs.Value);
            myNetwork.Learning_speed = LearnSpeed;
            myNetwork.countOfEpochs = CountOfEpochs;

            var res = myNetwork.StartLearn(listExamples);
            label_resultLearn.Text = "Навчання завершено! Пройдено " + res.Item1 + " епох, середньоквадратична помилка - " + res.Item2;
            listExamples.Clear();
        }

        private void Recognize()
        {
            if (dataGridView2.Rows.Count <= 0)
            {
                return;
            }
            dataGridView2.EndEdit();
            var cells = dataGridView2.Rows[0].Cells;
            selected_array = new double[cells.Count];
            for (var i = 0; i < cells.Count; i++)
            {
                selected_array[i] = Convert.ToDouble(cells[i].Value);
            }

            var res = myNetwork.Get_result(selected_array);
            label_result.Text = "";
            for (int i = 0; i < res.Length; i++)
            {
                label_result.Text += "y" + i + " - " + String.Format("{0:0.00}", res[i] * 100) + "%\n";
            }
        }
        #endregion


        #region events func

        #region Menu Files Functon
        private void ToolStripMenuItem_restart_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void ToolStripMenuItem_Save_AI_Click(object sender, EventArgs e)
        {
            var rez = myNetwork.GetWeightToSave();
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
                myNetwork.SetWeight(JsonSerializer.Deserialize<List<List<Tuple<char, List<double>>>>>(json));
            }
            else
            {
                MessageBox.Show("Помилка вибору шляху!", "Не вибрано файл!",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        #endregion

        #region page 1 funcs
        private void button_CreateNetwork_Click(object sender, EventArgs e)
        {
            ConfirmDesignNetwork();
        }
        private void numericUpDown_countOfHidenLayers_ValueChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < numericUpDown_countOfHidenLayers.Maximum; i++)
            {
                if (i < numericUpDown_countOfHidenLayers.Value)
                {
                    listNumericUpDown[i].Enabled = true;
                }
                else
                {
                    listNumericUpDown[i].Enabled = false;
                }
            }
        }
        #endregion

        #region page 2 funcs
        private void button_addExample_Click(object sender, EventArgs e)
        {
            var i = dataGridView1.Rows.Add();
            dataGridView1.Rows[i].Selected = false;
        }

        private void button_deleteExample_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                HashSet<int> indexes = new HashSet<int>();
                foreach (DataGridViewCell item in dataGridView1.SelectedCells)
                {
                    indexes.Add(item.RowIndex);
                }
                foreach (var item in indexes.OrderByDescending(x => x))
                {
                    dataGridView1.Rows.RemoveAt(item);
                }
            }
        }

        private void button__StartLearn_Click(object sender, EventArgs e)
        {
            StartLearn();
        }
        #endregion

        #region page 3 funcs
        private void button_recognize_Click(object sender, EventArgs e)
        {
            Recognize();
        }
        #endregion

        private void tabControl1_Deselected(object sender, TabControlEventArgs e)
        {
            button_CreateNetwork.Text = "Створити мережу";
        }

        #endregion
    }
}