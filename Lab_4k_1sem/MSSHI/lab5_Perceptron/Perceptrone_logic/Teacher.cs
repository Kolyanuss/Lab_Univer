using DataBlock;
namespace Perceptrone_logic
{
    public static class Teacher
    {
        public static void Learn_letter_DerivationOfTheDeltaRule(Neiron[] neironsToLearn, List<Tuple<int[], char>> ArrWithExample)
        {
            foreach (var item in neironsToLearn)
            {
                Learn_DerivationOfTheDeltaRule(item, ArrWithExample);
            }
        }

        public static void Learn_DerivationOfTheDeltaRule(Neiron neironToLearn, List<Tuple<int[], char>> ArrWithExample)
        {
            bool rez = false;
            while (!rez)
            {
                rez = true;
                foreach (var item in ArrWithExample)
                {
                    bool desire_response = (item.Item2 == neironToLearn.Name) ? true : false;

                    neironToLearn.SetEntrancesState(item.Item1);
                    var rez_y = neironToLearn.CalcY_SigmoidFunc();
                    if ((Convert.ToInt32(desire_response) == 1 && rez_y >= neironToLearn.activation_threshold_Y) ||
                        (Convert.ToInt32(desire_response) == 0 && rez_y <= 1 - neironToLearn.activation_threshold_Y))
                    {
                        continue;
                    }

                    ///neural error \ нейронна помилка
                    var e = rez_y * (1 - rez_y) * (Convert.ToInt32(desire_response) - rez_y);
                    var ne = neironToLearn.Learning_speed * e;
                    for (int i = 0; i < neironToLearn.CountOfEntrances; i++)
                    {
                        var x = neironToLearn.GetEntranceWeight(i) + ne * neironToLearn.GetEntranceState(i);
                        neironToLearn.SetEntrancesWeight(i, x);
                    }
                    rez = false;
                }
            }
        }

        public static void Learn_DerivationOfTheDeltaRule(Neiron neironToLearn, List<Tuple<int[], bool>> ArrWithExample)
        {
            bool rez = false;
            while (!rez)
            {
                rez = true;
                foreach (var item in ArrWithExample)
                {
                    bool desire_response = item.Item2;

                    neironToLearn.SetEntrancesState(item.Item1);
                    var rez_y = neironToLearn.CalcY_SigmoidFunc();
                    if ((Convert.ToInt32(desire_response) == 1 && rez_y >= neironToLearn.activation_threshold_Y) ||
                        (Convert.ToInt32(desire_response) == 0 && rez_y <= 1 - neironToLearn.activation_threshold_Y))
                    {
                        continue;
                    }
                    ///neural error \ нейронна помилка
                    var e = rez_y * (1 - rez_y) * (Convert.ToInt32(desire_response) - rez_y);
                    var ne = neironToLearn.Learning_speed * e;
                    for (int i = 0; i < neironToLearn.CountOfEntrances; i++)
                    {
                        var x = neironToLearn.GetEntranceWeight(i) + ne * neironToLearn.GetEntranceState(i);
                        neironToLearn.SetEntrancesWeight(i, x);
                    }
                    rez = false;
                }
            }
        }

        public static Tuple<int, List<double>> Learn_backpropagation(List<Neiron[]> layers,
            List<Tuple<int[], double[]>> ListWithExamples, int epochs_of_learning, double Learning_speed)
        {
            int current_epochs_of_learning = 0;
            List<double> list_root_mean_squared_error = new List<double>();
            var counOfNeuronInLastLayer = layers[layers.Count - 1].Length;
            do
            {
                //Console.WriteLine("Епоха: " + current_epochs_of_learning);
                double sum_squared_error = 0;
                foreach (var example in ListWithExamples)
                {
                    //Console.WriteLine("  Приклад: ({0} - {1}) - {2}",
                    //    example.Item1[0], example.Item1[1], example.Item2[0]);
                    #region prepare data
                    var desire_response = example.Item2;
                    double[] inputData = new double[example.Item1.Length];
                    for (int i = 0; i < inputData.Length; i++)
                    {
                        inputData[i] = example.Item1[i];
                    }
                    #endregion

                    #region Forward
                    for (int j = 0; j < layers.Count; j++)
                    {
                        //Console.WriteLine("    Шар: " + j);
                        double[] outputData = new double[layers[j].Length];
                        for (int i = 0; i < outputData.Length; i++)
                        {
                            outputData[i] = layers[j][i].GetAnswerDouble(inputData);
                            //Console.WriteLine("      Нейрон: " + i + ", Y: " + outputData[i] + " ");
                        }
                        inputData = outputData;
                    }
                    #endregion

                    #region Backward
                    #region last layer
                    var listWithNeuralError = new double[counOfNeuronInLastLayer];
                    for (int j = 0; j < counOfNeuronInLastLayer; j++)
                    {
                        var neuron = layers[layers.Count - 1][j];
                        ///neural error \ нейронна помилка
                        var e = neuron.GetNeuralErrorBySigmoidFunc(desire_response[j]);
                        var ne = Learning_speed * e;
                        for (int i = 0; i < neuron.CountOfEntrances; i++)
                        {
                            var x = neuron.GetEntranceWeight(i) + ne * neuron.GetEntranceState(i);
                            neuron.SetEntrancesWeight(i, x);
                        }
                        listWithNeuralError[j] = e;
                        sum_squared_error += Math.Pow(desire_response[j] - neuron.CalcY_SigmoidFunc(), 2);
                    }
                    #endregion

                    #region all hiden layers
                    for (int l = layers.Count - 2; l >= 0; l--) // revese for by layers
                    {
                        var countOfNeuronInCurrentLayer = layers[l].Length;
                        var listWithNewNeuralError = new double[countOfNeuronInCurrentLayer];
                        for (int j = 0; j < countOfNeuronInCurrentLayer; j++) // for by neurons
                        {
                            var neuron = layers[l][j];
                            var rez_y = neuron.CalcY_SigmoidFunc();

                            double sumOfNeuralErrorNextLayer = 0;
                            for (int i = 0; i < listWithNeuralError.Length; i++)
                            {
                                sumOfNeuralErrorNextLayer += listWithNeuralError[i] * layers[l + 1][i].GetEntranceWeightWithRelationToNeuron(j);
                            }
                            ///neural error \ нейронна помилка
                            var e = rez_y * (1 - rez_y) * sumOfNeuralErrorNextLayer;
                            var ne = Learning_speed * e;
                            for (int i = 0; i < neuron.CountOfEntrances; i++)
                            {
                                var x = neuron.GetEntranceWeight(i) + ne * neuron.GetEntranceState(i);
                                neuron.SetEntrancesWeight(i, x);
                            }
                            listWithNewNeuralError[j] = e;
                        }
                        listWithNeuralError = listWithNewNeuralError;
                    }
                    #endregion
                    #endregion
                }
                ListWithExamples.Shuffle();
                current_epochs_of_learning += 1;
                list_root_mean_squared_error.Add(1.0 / (ListWithExamples.Count * counOfNeuronInLastLayer) * sum_squared_error);
            } while (current_epochs_of_learning < epochs_of_learning && list_root_mean_squared_error[list_root_mean_squared_error.Count - 1] >= 0.005);

            return new Tuple<int, List<double>>(current_epochs_of_learning, list_root_mean_squared_error);
        }
    }
}
