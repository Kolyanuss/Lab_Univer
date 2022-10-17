using System.Collections.Generic;

namespace Perceptrone_logic
{
    public class Perceptron
    {
        public int countOfInputEntrances { get; } = 2;
        public int countOfHidenLayers { get; } = 1;
        public int countOfNeuronInHidenLayer { get; } = 2;
        public int countOfNeuronInOutputLayer { get; } = 1;
        public int countOfEpochs { get; set; } = 100;
        public double Learning_speed { get; set; } = 0.8;
        /// <summary>
        /// How many parts will the picture be divided into on the X axis.
        /// На скільки частин буде поділятись картинка по осі Х
        /// </summary>
        public int sizeX { get; }
        /// <summary>
        /// How many parts will the picture be divided into on the Y axis.
        /// На скільки частин буде поділятись картинка по осі Y
        /// </summary>
        public int sizeY { get; }
        private string allLetter = "";

        private List<Neiron[]> layers;

        public Perceptron()
        {
            BasicInit();
        }
        public Perceptron(int countOfInputEntrances_X, int countOfInputEntrances_Y,
            int countOfHidenLayers, int countOfNeuronInHidenLayer, int countOfNeuronInOutputLayer)
        {
            sizeX = countOfInputEntrances_X;
            sizeY = countOfInputEntrances_Y;
            this.countOfInputEntrances = sizeX * sizeY;
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

            char A_letter = Convert.ToChar(1040);
            string additionalVal = "ҐЄІЇЬЮЯ";
            for (int i = 0; i < 33 - additionalVal.Length; i++)
            {
                allLetter += A_letter++;
            }
            allLetter += additionalVal;

            Neiron[] output_layer = new Neiron[countOfNeuronInOutputLayer];
            for (int i = 0; i < output_layer.Length; i++)
            {
                output_layer[i] = new Neiron(countOfEntrancesInPreviousLayer, allLetter[i]);
            }
            layers.Add(output_layer);
        }

        public Tuple<int,double> StartLearn(List<Tuple<int[], double[]>> data)
        {
            var res = Teacher.Learn_backpropagation(layers, data, countOfEpochs, Learning_speed);
            Console.WriteLine("Epochs: {0}.\nСередньоквадратична помилка: (before;after) ({1};{2})", res.Item1, res.Item2[0], res.Item2[res.Item2.Count - 1]);
            return new Tuple<int, double>(res.Item1, res.Item2[res.Item2.Count-1]);
        }
        public Tuple<int, double> StartLearn(List<Tuple<int[], char>> data)
        {
            var transform = new List<Tuple<int[], double[]>>();
            foreach (var item in data)
            {
                var answer = new double[this.countOfNeuronInOutputLayer];
                for (int i = 0; i < allLetter.Length; i++)
                {
                    if (allLetter[i] == item.Item2)
                    {
                        answer[i] = 1;
                        break;
                    }
                }
                transform.Add(new Tuple<int[], double[]>(item.Item1, answer));
            }
            return StartLearn(transform);
        }

        /// <summary>
        /// Видає результат роботи навченої моделі
        /// </summary>
        /// <param name="arrWithState">Довжина arrWithState повинна дорівнювати "countOfEntrances"</param>
        /// <returns></returns>
        public double[] Get_result(int[] arrWithState)
        {
            if (arrWithState.Length != countOfInputEntrances)
            {
                throw new Exception("Неправильна довжина вхідного масиву даних!");
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
            return inputData;
            /*
            string res = "";
            foreach (var item in inputData)
            {
                res += item + " ";
            }
            return res;*/
        }

        public List<string> Guess_letter_and_return_all_percent(int[] arrWithState)
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
        }

        public List<List<Tuple<char, List<double>>>> GetWeightToSave()
        {
            var res = new List<List<Tuple<char, List<double>>>>();
            foreach (var layer in layers)
            {
                var res_layer = new List<Tuple<char, List<double>>>();
                foreach (var neuron in layer)
                {
                    res_layer.Add(neuron.GetEntranceWeight());
                }
                res.Add(res_layer);
            }
            return res;
        }

        public void SetWeight(List<List<Tuple<char, List<double>>>> items)
        {
            int i = 0;
            foreach (var dict in items)
            {
                int j = 0;
                foreach (var oneExample in dict)
                {
                    layers[i][j].SetEntrancesWeight(oneExample.Item2);
                    j++;
                }
                i++;
            }
        }
    }
}
