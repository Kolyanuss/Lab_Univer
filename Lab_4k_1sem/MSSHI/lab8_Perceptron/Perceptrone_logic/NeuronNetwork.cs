namespace Perceptrone_logic
{
    public class NeuronNetwork
    {
        public int countOfInputEntrances { get; } = 1;
        public int countOfHidenLayers { get; } = 1;
        public int[] arrCountsOfNeuronInHidenLayer { get; } = new int[] { 1 };
        public int countOfNeuronInOutputLayer { get; } = 1;
        public int countOfEpochs { get; set; } = 1000;
        public double Learning_speed { get; set; } = 0.8;

        private List<Neiron[]> layers = new List<Neiron[]>();

        #region ctors
        public NeuronNetwork()
        {
            BasicInit();
        }

        public NeuronNetwork(int countOfInputEntrances, int countOfHidenLayers,
            int[] arrCountOfNeuronInHidenLayers, int countOfNeuronInOutputLayer)
        {
            if (arrCountOfNeuronInHidenLayers.Length != countOfHidenLayers)
            {
                throw new Exception("Довжина масиву із нейронами для прихованого шару != кількості прихованих шарів");
            }
            this.countOfInputEntrances = countOfInputEntrances;
            this.countOfHidenLayers = countOfHidenLayers;
            this.arrCountsOfNeuronInHidenLayer = arrCountOfNeuronInHidenLayers;
            this.countOfNeuronInOutputLayer = countOfNeuronInOutputLayer;
            BasicInit();
        }

        private void BasicInit()
        {
            layers = new List<Neiron[]>();

            int countOfEntrancesInPreviousLayer = countOfInputEntrances;
            for (int j = 0; j < countOfHidenLayers; j++)
            {
                Neiron[] hiden_layer = new Neiron[arrCountsOfNeuronInHidenLayer[j]];
                for (int i = 0; i < hiden_layer.Length; i++)
                {
                    hiden_layer[i] = new Neiron(countOfEntrancesInPreviousLayer);
                }
                layers.Add(hiden_layer);
                countOfEntrancesInPreviousLayer = hiden_layer.Length;
            }

            Neiron[] output_layer = new Neiron[countOfNeuronInOutputLayer];
            for (int i = 0; i < output_layer.Length; i++)
            {
                output_layer[i] = new Neiron(countOfEntrancesInPreviousLayer);
            }
            layers.Add(output_layer);
        }
        #endregion

        public Tuple<int, double> StartLearn(List<Tuple<double[], double[]>> data)
        {
            var res = Teacher.Learn_backpropagation(layers, data.ToList(), countOfEpochs, Learning_speed);
            Console.WriteLine("Epochs: {0}.\nСередньоквадратична помилка: (before;after) ({1};{2})", res.Item1, res.Item2[0], res.Item2[res.Item2.Count - 1]);
            return new Tuple<int, double>(res.Item1, res.Item2[res.Item2.Count - 1]);
        }

        /// <summary>
        /// Видає результат роботи навченої моделі
        /// </summary>
        /// <param name="arrWithState">Довжина arrWithState повинна дорівнювати "countOfEntrances"</param>
        /// <returns></returns>
        public double[] Get_result(double[] arrWithState)
        {
            if (arrWithState.Length != countOfInputEntrances)
            {
                throw new Exception("Неправильна довжина вхідного масиву даних!");
            }

            double[] inputData = arrWithState;

            for (int j = 0; j < layers.Count; j++)
            {
                double[] outputData = new double[layers[j].Length];
                for (int i = 0; i < outputData.Length; i++)
                {
                    outputData[i] = layers[j][i].GetAnswerDouble(inputData);
                }
                inputData = outputData;
            }
            return inputData;
        }

        /*public List<string> Guess_letter_and_return_all_percent(int[] arrWithState)
        {
            List<string> list = new List<string>();
            var resY = Get_result(arrWithState);
            var lastLayer = layers[layers.Count - 1];
            for (int i = 0; i < lastLayer.Length; i++)
            {
                var neuron = lastLayer[i];
                list.Add("" + neuron.Name + "\t " + String.Format("{0:0.0000}", resY[i] * 100) + "%");
            }
            return list;
        }*/

        public List<List<List<double>>> GetWeightToSave()
        {
            var res = new List<List<List<double>>>();
            foreach (var layer in layers)
            {
                var res_layer = new List<List<double>>();
                foreach (var neuron in layer)
                {
                    res_layer.Add(neuron.GetAllWeight());
                }
                res.Add(res_layer);
            }
            return res;
        }

        public void SetWeight(List<List<List<double>>> items)
        {
            int i = 0;
            foreach (var item in items)
            {
                int j = 0;
                foreach (var oneExample in item)
                {
                    layers[i][j].SetEntrancesWeight(oneExample);
                    j++;
                }
                i++;
            }
        }

        public void ChangeActivationFunc(Neiron.ActivationFuncs activationType)
        {
            foreach (var layer in layers)
            {
                foreach (var item in layer)
                {
                    item.TypeActivFunc = activationType;
                }
            }
        }
        public void ChangeActivationFuncOnLastLayer(Neiron.ActivationFuncs activationType)
        {
            foreach (var item in layers[layers.Count - 1])
            {
                item.TypeActivFunc = activationType;
            }
        }
    }
}
