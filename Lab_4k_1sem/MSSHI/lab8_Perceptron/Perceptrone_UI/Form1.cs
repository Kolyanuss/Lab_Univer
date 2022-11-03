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
        #region variable
        public NeuronNetwork myNetwork;

        private List<Tuple<double[], double[]>> listExamples;

        private double[]? selected_array = null;

        #endregion

        #region ctor
        public Form1()
        {
            InitializeComponent();
            listExamples = new List<Tuple<double[], double[]>>();
        }
        #endregion

        #region my func
        private DataGridViewComboBoxColumn GetComboBoxColumn(string text)
        {
            var param = "0% 25% 50% 75% 100%".Split(' ');
            var res = new DataGridViewComboBoxColumn()
            {
                Name = text,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader,

            };
            res.Items.AddRange(param);
            return res;
        }
        private void ConfirmDesignNetwork()
        {
            for (int i = 0; i < myNetwork.countOfInputEntrances; i++)
            {
                dataGridView1.Columns.Add(GetComboBoxColumn("x" + i));
                dataGridView2.Columns.Add(GetComboBoxColumn("x" + i));
            }

            for (int i = 0; i < myNetwork.countOfNeuronInOutputLayer; i++)
            {
                dataGridView1.Columns.Add(GetComboBoxColumn("y" + i));
            }
            int CountInput = Convert.ToInt32(numericUpDown_countOfNeuronInIntputLayer.Value);
            int CountHiden = Convert.ToInt32(numericUpDown_countOfHidenLayers.Value);
            int CountOuput = Convert.ToInt32(numericUpDown_countOfNeuronInOutputLayer.Value);
            myNetwork = new NeuronNetwork(CountInput, CountHiden, 1, CountOuput);

            dataGridView2.Rows.Add();
            dataGridView2.Rows[0].Selected = false;
            
            button__StartLearn.Enabled = true;
            button_addExample.Enabled = true;
            button_deleteExample.Enabled = true;
        }

        private void StartLearn()
        {
            dataGridView1.EndEdit();
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

            if (listExamples.Count <= 0)
            {
                MessageBox.Show("Список навчальних даних пустий! \n Добавте приклади", "Інфо", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            int LearnSpeed = Convert.ToInt32(numericUpDown_Learning_speed.Value);
            int CountOfEpochs = Convert.ToInt32(numericUpDown_maxCountOfEpochs.Value);
            myNetwork.Learning_speed = LearnSpeed;
            myNetwork.countOfEpochs = CountOfEpochs;

            var res = myNetwork.StartLearn(listExamples);
            label_result.Text = "Навчання завершено! Пройдено " + res.Item1 + " епох, середньоквадратична помилка - " + res.Item2;
            listExamples.Clear();
        }

        private void Recognize()
        {
            dataGridView2.EndEdit();
            var cells = dataGridView2.Rows[0].Cells;
            selected_array = new double[cells.Count];
            for (var i = 0; i < cells.Count; i++)
            {
                selected_array[i] = Convert.ToDouble(cells[i].Value.ToString().Split('%')[0]);
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

        }
        #endregion

        #region page 2 funcs
        private void button_addExample_Click(object sender, EventArgs e)
        {
            var i = dataGridView1.Rows.Add();
            //dataGridView1.Rows[i].Selected = false;
        }

        private void button_deleteExample_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 1);
            }
        }

        private void button__StartLearn_Click(object sender, EventArgs e)
        {
            StartLearn();
        }
        #endregion

        #region page 3 funcs

        #endregion

        #endregion

    }
}