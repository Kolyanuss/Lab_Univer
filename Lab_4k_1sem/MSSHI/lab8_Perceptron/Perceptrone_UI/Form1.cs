using Perceptrone_logic;
using System.Text.Json;
using System.Data;
using DataBlock;
using static Perceptrone_logic.Neiron;

namespace Perceptrone_UI
{
    public partial class Form1 : Form
    {
        #region variable
        public NeuronNetwork myNetwork = new NeuronNetwork();

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

            comboBox_activationFuncIn.SelectedItem = comboBox_activationFuncIn.Items[0];
            comboBox_activationFuncHiden.SelectedItem = comboBox_activationFuncHiden.Items[0];
            comboBox_activationFuncOut.SelectedItem = comboBox_activationFuncOut.Items[0];

            var DefaultCellStyle = new Font("Segoe UI", 14);
            var HeaderCellStyle = new Font("Segoe UI Semibold", 18, FontStyle.Bold);

            dataGridView_train.DefaultCellStyle.Font = DefaultCellStyle;
            dataGridView_train.ColumnHeadersDefaultCellStyle.Font = HeaderCellStyle;

            dataGridView_check.DefaultCellStyle.Font = DefaultCellStyle;
            dataGridView_check.ColumnHeadersDefaultCellStyle.Font = HeaderCellStyle;

            dataGridView_predict.DefaultCellStyle.Font = DefaultCellStyle;
            dataGridView_predict.ColumnHeadersDefaultCellStyle.Font = HeaderCellStyle;
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

        public ActivationFuncs AssignmentOfActivationFunction(string? str)
        {
            switch (str)
            {
                case "Сходинка":
                    return ActivationFuncs.STEP;
                case "Сигмоїда":
                    return ActivationFuncs.SIGMOID;
                case "Лінійна":
                    return ActivationFuncs.LINEAR;
                default:
                    throw new Exception("Error: немає співпадіння для функції активації");
            };
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

            // Assignment of the activation function
            ActivationFuncs activationFuncs;

            activationFuncs = AssignmentOfActivationFunction(comboBox_activationFuncIn.SelectedItem.ToString());
            myNetwork.ChangeActivationFuncOnFirstLayer(activationFuncs);

            if (comboBox_activationFuncHiden.Enabled)
            {
                activationFuncs = AssignmentOfActivationFunction(comboBox_activationFuncHiden.SelectedItem.ToString());
                myNetwork.ChangeActivationFunc(activationFuncs);
            }

            activationFuncs = AssignmentOfActivationFunction(comboBox_activationFuncOut.SelectedItem.ToString());
            myNetwork.ChangeActivationFuncOnLastLayer(activationFuncs);

            // clear table
            dataGridView_train.Columns.Clear();
            dataGridView_check.Columns.Clear();
            dataGridView_predict.Columns.Clear();
            // initialize table
            for (int i = 0; i < myNetwork.countOfInputEntrances; i++)
            {
                dataGridView_train.Columns.Add(GetTextBoxColumn("x" + (i + 1)));
                dataGridView_check.Columns.Add(GetTextBoxColumn("x" + (i + 1)));
                dataGridView_predict.Columns.Add(GetTextBoxColumn("x" + (i + 1)));
            }
            for (int i = 0; i < myNetwork.countOfNeuronInOutputLayer; i++)
            {
                dataGridView_train.Columns.Add(GetTextBoxColumn("d" + (i + 1)));
                dataGridView_check.Columns.Add(GetTextBoxColumn("d" + (i + 1)));
                dataGridView_check.Columns.Add(GetTextBoxColumn("y" + (i + 1)));
            }
            dataGridView_predict.Rows.Add();
            dataGridView_predict.Rows[0].Selected = false;

            // unlock button
            button__StartLearn.Enabled = true;
            button_addExample.Enabled = true;
            button_deleteExample.Enabled = true;
            button_CreateNetwork.Text = "Мережа успішно створена!";
        }

        private void StartLearn()
        {
            dataGridView_train.EndEdit();
            try
            {
                foreach (DataGridViewRow row in dataGridView_train.Rows)
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
                return;
            }

            double LearnSpeed = Convert.ToDouble(numericUpDown_Learning_speed.Value);
            int CountOfEpochs = Convert.ToInt32(numericUpDown_maxCountOfEpochs.Value);
            myNetwork.Learning_speed = LearnSpeed;
            myNetwork.countOfEpochs = CountOfEpochs;

            if (checkBox_Normalization.Checked)
            {
                listExamples = MyExtensions.MyNormalization(listExamples);
            }
            var res = myNetwork.StartLearn(listExamples);

            label_resultLearn.Text = "Навчання завершено! Пройдено " + res.Item1 + " епох, середньоквадратична помилка - " + res.Item2;
            FillCheckTable();
            listExamples.Clear();
        }

        private void FillCheckTable()
        {
            double maxError = 0;
            double trueValOfMaxError = 0;
            dataGridView_check.Rows.Clear();
            for (int i = 0; i < listExamples.Count; i++)
            {
                dataGridView_check.Rows.Add();
                dataGridView_check.Rows[i].Selected = false;

                List<double> example = new List<double>(listExamples[i].Item1.Concat(listExamples[i].Item2));
                var cells = dataGridView_check.Rows[i].Cells;

                for (int j = 0; j < example.Count; j++)
                {
                    cells[j].Value = example[j];
                }
                cells[cells.Count - 1].Value = myNetwork.Get_result(listExamples[i].Item1).FirstOrDefault();
                var x = Math.Abs(Convert.ToDouble(cells[cells.Count - 1].Value) -
                    Convert.ToDouble(cells[cells.Count - 2].Value));
                if (x > maxError)
                {
                    maxError = x;
                    trueValOfMaxError = Convert.ToDouble(cells[cells.Count - 2].Value);
                }
            }
            label_check.Text = "Max Error: " + maxError;
            label_check.Text += "\n% of Max Error: " + (maxError / trueValOfMaxError) * 100;
        }

        private void Recognize()
        {
            if (dataGridView_predict.Rows.Count <= 0)
            {
                return;
            }
            dataGridView_predict.EndEdit();
            var cells = dataGridView_predict.Rows[0].Cells;
            selected_array = new double[cells.Count];
            for (var i = 0; i < cells.Count; i++)
            {
                selected_array[i] = Convert.ToDouble(cells[i].Value);
            }

            var res = myNetwork.Get_result(selected_array);
            label_result.Text = "";
            for (int i = 0; i < res.Length; i++)
            {
                label_result.Text += "y" + i + " - " + String.Format("{0:0.00}", res[i]) + "\n";
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
                try
                {
                    myNetwork.SetWeight(JsonSerializer.Deserialize<List<List<List<double>>>>(json));
                }
                catch (JsonException)
                {
                    MessageBox.Show("Тип загруженої моделі не співпадає дійсною", "Error!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
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
            if (numericUpDown_countOfHidenLayers.Value != 0)
            {
                comboBox_activationFuncHiden.Enabled = true;
                label7.Enabled = true;
            }
            else
            {
                comboBox_activationFuncHiden.Enabled = false;
                label7.Enabled = false;
            }

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
            var i = dataGridView_train.Rows.Add();
            dataGridView_train.Rows[i].Selected = false;
        }

        private void button_deleteExample_Click(object sender, EventArgs e)
        {
            if (dataGridView_train.Rows.Count > 0)
            {
                HashSet<int> indexes = new HashSet<int>();
                foreach (DataGridViewCell item in dataGridView_train.SelectedCells)
                {
                    indexes.Add(item.RowIndex);
                }
                foreach (var item in indexes.OrderByDescending(x => x))
                {
                    dataGridView_train.Rows.RemoveAt(item);
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