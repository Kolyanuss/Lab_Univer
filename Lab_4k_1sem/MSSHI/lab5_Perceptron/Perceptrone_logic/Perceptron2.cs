namespace Perceptrone_logic
{
    public class Perceptron2
    {
        public int countOfInputEntrances { get; } = 2;
        public int countOfHidenLayers { get; } = 1;
        public int countOfNeuronInHidenLayer { get; } = 2;
        public int countOfNeuronInOutputLayer { get; } = 1;
        public int countOfEpochs { get; set; } = 100;
        public double Learning_speed { get; set; } = 0.8;

        private List<Neiron[]> layers;

        public Perceptron2()
        {
            BasicInit();
        }
        public Perceptron2(int countOfInputEntrances, int countOfHidenLayers, int countOfNeuronInHidenLayer, int countOfNeuronInOutputLayer)
        {
            this.countOfInputEntrances = countOfInputEntrances;
            this.countOfHidenLayers = countOfHidenLayers;
            this.countOfNeuronInHidenLayer = countOfNeuronInHidenLayer;
            this.countOfNeuronInOutputLayer = countOfNeuronInOutputLayer;
            BasicInit();
        }

        public void BasicInit()
        {
            layers = new List<Neiron[]>();

            int countOfEntrancesInPreviousLayer = countOfInputEntrances;
            for (int j = 0; j < countOfHidenLayers; j++)
            {
                Neiron[] hiden_layer = new Neiron[countOfNeuronInHidenLayer];
                for (int i = 0; i < hiden_layer.Length; i++)
                {
                    hiden_layer[i] = new Neiron(countOfEntrancesInPreviousLayer);
                }
                layers.Add(hiden_layer);
                countOfEntrancesInPreviousLayer = countOfNeuronInHidenLayer;
                // countOfEntrancesInPreviousLayer = layers[layers.Count - 1].Length; // same
            }

            Neiron[] output_layer = new Neiron[countOfNeuronInOutputLayer];
            for (int i = 0; i < output_layer.Length; i++)
            {
                output_layer[i] = new Neiron(countOfEntrancesInPreviousLayer);
            }
            layers.Add(output_layer);
        }

        public void StartLearn(List<Tuple<int[], double[]>> data)
        {
            this.countOfEpochs = countOfEpochs;
            var res = Teacher.Learn_backpropagation(layers, data, countOfEpochs, Learning_speed);
            Console.WriteLine("Epochs: {0}.\nСередньоквадратична помилка: (before;after) ({1};{2})", res.Item1, res.Item2[0], res.Item2[res.Item2.Count - 1]);
        }

        /// <summary>
        /// Видає результат роботи навченої моделі
        /// </summary>
        /// <param name="arrWithState">Довжина arrWithState повинна дорівнювати "countOfEntrances"</param>
        /// <returns></returns>
        public string Get_result(int[] arrWithState)
        {
            if (arrWithState.Length != countOfInputEntrances)
            {
                return "Неправильна довжина вхідного масиву даних!";
            }

            double[] inputData = new double[arrWithState.Length];
            for (int i = 0; i < arrWithState.Length; i++)
            {
                inputData[i] = arrWithState[i];
            }

            for (int j = 0; j < layers.Count; j++)
            {
                double[] outputData = new double[layers[j].Length];
                for (int i = 0; i < outputData.Length; i++)
                {
                    outputData[i] = layers[j][i].GetAnswerDouble(inputData);
                }
                inputData = outputData;
            }

            string res = "";
            foreach (var item in inputData)
            {
                res += item + " ";
            }
            return res;
        }
    }
}
