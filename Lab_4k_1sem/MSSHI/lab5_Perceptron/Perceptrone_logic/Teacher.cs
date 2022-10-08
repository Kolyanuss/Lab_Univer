namespace Perceptrone_logic
{
    public static class Teacher
    {
        public static void Learn_letter_DerivationOfTheDeltaRule(Neiron neironToLearn, List<Tuple<int[], char>> ArrWithExample)
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
                        rez = true;
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

        public static void Learn_xor_backpropagation(List<Neiron[]> layers, List<Tuple<int[], bool>> ArrWithExample)
        {

        }
    }
}
