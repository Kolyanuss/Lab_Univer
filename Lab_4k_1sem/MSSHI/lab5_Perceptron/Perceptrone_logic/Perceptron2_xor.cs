namespace Perceptrone_logic
{
    public class Perceptron2_xor
    {
        public const int countOfInputEntrances = 2;
        public const int countOfHidenLayers = 1;
        public const int countOfNeuronInHidenLayer = 2;
        public const int countOfNeuronInOutputLayer = 1;
        public int countOfEpochs = 100;
        private List<Neiron[]> layers;

        public Perceptron2_xor()
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

        public void StartLearn(List<Tuple<int[], double[]>> data, int countOfEpochs = 100)
        {
            this.countOfEpochs = countOfEpochs;
            var res = Teacher.Learn_xor_backpropagation(layers, data, this.countOfEpochs);
            Console.WriteLine("Кількість пройдених епох: {0}. Середньоквадратична помилка: {1}", res.Item1, res.Item2);
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

            var inputData = arrWithState;
            for (int j = 0; j < layers.Count; j++)
            {
                double[] outputData = new double[layers[j].Length];
                for (int i = 0; i < outputData.Length; i++)
                {
                    outputData[i] = layers[j][i].GetAnswerDouble(inputData);
                }
                inputData = new int[outputData.Length];
                for (int i = 0; i < inputData.Length; i++)
                {
                    inputData[i] = (outputData[i] >= layers[j][i].activation_threshold_Y) ? 1 : 0;
                }
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
