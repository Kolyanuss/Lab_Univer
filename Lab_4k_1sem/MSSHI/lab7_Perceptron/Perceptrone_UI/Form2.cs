using Perceptrone_logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Perceptrone_UI
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button_submit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        public void SetAllField(Perceptron perceptron)
        {
            textBox_countOfHidenLayers.Text += perceptron.countOfHidenLayers;
            textBox_countOfNeuronInHidenLayer.Text += perceptron.countOfNeuronInHidenLayer;
            textBox_countOfNeuronInOutputLayer.Text += perceptron.countOfNeuronInOutputLayer;
            textBox_maxCountOfEpochs.Text += perceptron.countOfEpochs;
            textBox_Learning_speed.Text += perceptron.Learning_speed;
        }

        public Perceptron GetPerceptronFromField(int countOfInputEntrances)
        {
            var res = new Perceptron(countOfInputEntrances,
                    Convert.ToInt32(textBox_countOfHidenLayers.Text),
                    Convert.ToInt32(textBox_countOfNeuronInHidenLayer.Text),
                    Convert.ToInt32(textBox_countOfNeuronInOutputLayer.Text));
            res.countOfEpochs = Convert.ToInt32(textBox_maxCountOfEpochs.Text);
            res.Learning_speed = Convert.ToDouble(textBox_Learning_speed.Text);
            return res;
        }
    }
}
