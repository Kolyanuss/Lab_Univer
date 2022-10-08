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
                    var rez_y = neironToLearn.CalcY();
                    if ((Convert.ToInt32(desire_response) == 1 && rez_y >= neironToLearn.activation_threshold_Y) ||
                        (Convert.ToInt32(desire_response) == 0 && rez_y <= 1 - neironToLearn.activation_threshold_Y))
                    {
                        continue;
                    }
                    var e = (Convert.ToInt32(desire_response) - rez_y);
                    ///neural error \ нейронна помилка
                    var ne = neironToLearn.Learning_speed * e * (rez_y * (1 - rez_y));
                    for (int i = 0; i < neironToLearn.CountOfEntrances; i++)
                    {
                        var x = neironToLearn.GetEntranceWeight(i) + ne * Convert.ToInt32(neironToLearn.GetEntranceState(i));
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
                    var rez_y = neironToLearn.CalcY();
                    if ((Convert.ToInt32(desire_response) == 1 && rez_y >= neironToLearn.activation_threshold_Y) ||
                        (Convert.ToInt32(desire_response) == 0 && rez_y <= 1 - neironToLearn.activation_threshold_Y))
                    {
                        continue;
                    }
                    var e = (Convert.ToInt32(desire_response) - rez_y);
                    ///neural error \ нейронна помилка
                    var ne = neironToLearn.Learning_speed * e * (rez_y * (1 - rez_y));
                    for (int i = 0; i < neironToLearn.CountOfEntrances; i++)
                    {
                        var x = neironToLearn.GetEntranceWeight(i) + ne * Convert.ToInt32(neironToLearn.GetEntranceState(i));
                        neironToLearn.SetEntrancesWeight(i, x);
                    }
                    rez = false;
                }
            }
        }

        public static void Learn_backpropagation(Neiron neironToLearn, int[] entrances)
        {
/*
            var e = ;
            ///neural error \ нейронна помилка
            var ne = neironToLearn.Learning_speed * e * (rez_y * (1 - rez_y));
            for (int i = 0; i < neironToLearn.CountOfEntrances; i++)
            {
                var x = neironToLearn.GetEntranceWeight(i) + ne * Convert.ToInt32(neironToLearn.GetEntranceState(i));
                neironToLearn.SetEntrancesWeight(i, x);
            }
*/

        }

        public static void Learn_xor_backpropagation(List<Neiron[]> layers, List<Tuple<int[], bool>> ArrWithExample)
        {
            bool rez = false;
            while (!rez)
            {
                rez = true;
                foreach (var item in ArrWithExample)
                {
                    // direct pass
                    var inputData = item.Item1;
                    for (int j = 0; j < layers.Count; j++)
                    {
                        double[] outputData = new double[layers[j].Length];
                        for (int i = 0; i < outputData.Length; i++)
                        {
                            outputData[i] = layers[j][i].GetAnswerDouble(inputData);
                        }
                        inputData = new double[outputData.Length]; // todo: fix
                        for (int i = 0; i < inputData.Length; i++)
                        {
                            inputData[i] = (outputData[i] >= layers[j][i].activation_threshold_Y) ? 1 : 0;
                        }
                    }

                    // return pass

                    // last layer
                    foreach (var item1 in layers[layers.Count - 1])
                    {
                        Learn_DerivationOfTheDeltaRule(item1, ArrWithExample);
                    }
                    // all hiden layers
                    // todo: add cycle
                }
                // добавити розрахунок середньо-квадратичної помилки
            }
        }
    }
}
