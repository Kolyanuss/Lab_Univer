namespace Perceptrone_logic
{
    public class Perceptron2_xor
    {
        public const int countOfInputEntrances = 2;
        public const int countOfHidenLayers = 1;
        public const int countOfNeuronInHidenLayer = 2;
        public const int countOfNeuronInOutputLayer = 1;
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

        public void StartLearn(List<Tuple<int[], bool>> data)
        {
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
            for (int j = 0; j < countOfHidenLayers + 1; j++)
            {
                int[] outputData = new int[layers[j].Length];
                for (int i = 0; i < outputData.Length; i++)
                {
                    outputData[i] = layers[j][i].GetAnswer(inputData);
                }
                inputData = outputData;
            }

            var res = "";
            foreach (var item in inputData)
            {
                res += item + " ";
            }
            return res;
        }
    }
}
