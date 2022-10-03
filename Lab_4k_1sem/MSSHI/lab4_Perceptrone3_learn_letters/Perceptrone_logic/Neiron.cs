using System;
using System.Collections.Generic;

namespace Perceptrone_logic
{
    public class Neiron
    {
        private class entrances // вхід
        {
            public bool is_active { get; set; }
            public double weight { get; set; }
            public entrances()
            {
                this.weight = GetRandNumInRange(-0.5, 0.5);
            }
            public entrances(bool isactive, double weight)
            {
                this.is_active = isactive;
                this.weight = weight;
            }
        }

        public int size { get; }
        private entrances[] arr_entrances; // всі входи в перцептрона
        public double Tetta // sensitivity threshold || поріг чутливості
        {
            get { return arr_entrances[0].weight; }
        }
        public double Learning_speed = 0.05;
        public char Name;
        /// <summary>
        /// Поріг активації сигмоїдної функції "y = fo(S)"
        /// </summary>
        public double activation_threshold_Y = 0.98;


        public Neiron(char name)
        {
            this.Name = name;
            this.size = 48 + 1;
            arr_entrances = new entrances[size];

            arr_entrances.SetValue(new entrances(true, GetRandNumInRange(-2,2)), 0);
            for (int i = 1; i < size; i++)
            {
                arr_entrances.SetValue(new entrances(), i);
            }
        }
        public Neiron(char name, int size)
        {
            this.Name = name;
            this.size = size + 1;
            arr_entrances = new entrances[this.size];

            arr_entrances.SetValue(new entrances(true, GetRandNumInRange(-2, 2)), 0);
            for (int i = 1; i < this.size; i++)
            {
                arr_entrances.SetValue(new entrances(), i);
            }
        }

        public static double GetRandNumInRange(double minNumber, double maxNumber)
        {
            return new Random().NextDouble() * (maxNumber - minNumber) + minNumber;
        }

        private double CalcWeight()
        {
            double S_weight = 0;
            for (int i = 0; i < size; i++)
            {
                S_weight += Convert.ToInt32(arr_entrances[i].is_active) * arr_entrances[i].weight;
            }
            return S_weight;
        }

        /// <summary>
        /// Сигмоїдна функція активації
        /// </summary>
        private double CalcY()
        {
            return 1 / (1 + Math.Exp(0-CalcWeight()));
        }

        public void ChangeEntrancesState(int[] masState)
        {
            if (masState.Length != size - 1)
            {
                throw new Exception("Error with size dimension");
            }
            for (int i = 1; i < size; i++)
            {
                arr_entrances[i].is_active = Convert.ToBoolean(masState[i - 1]);
            }
        }

        public char? GetAnswer(int[] testMas)
        {
            ChangeEntrancesState(testMas);
            return CalcY() >= activation_threshold_Y ? Name : null;
        }
        public Tuple<char, double>? GetAnswerWithPercent(int[] testMas)
        {
            ChangeEntrancesState(testMas);
            var y = CalcY();
            return y >= activation_threshold_Y ? new Tuple<char, double>(Name, y) : null;
        }
        public Tuple<char, double> GetAllAnswerWithPercent(int[] testMas)
        {
            ChangeEntrancesState(testMas);
            var y = CalcY();
            return new Tuple<char, double>(Name, y);
        }

        private bool LearnByOneExample(int[] masState, bool desire_response)
        {
            ChangeEntrancesState(masState);
            var rez_y = this.CalcY();
            if ((Convert.ToInt32(desire_response) == 1 && rez_y >= activation_threshold_Y) ||
                (Convert.ToInt32(desire_response) == 0 && rez_y <= 1 - activation_threshold_Y))
            {
                return true;
            }
            var e = (Convert.ToInt32(desire_response) - rez_y);
            ///neural error \ нейронна помилка
            var ne = Learning_speed * e * (rez_y * (1 - rez_y));
            //var ne = Learning_speed * e;
            for (int i = 0; i < size; i++)
            {
                arr_entrances[i].weight += ne * Convert.ToInt32(arr_entrances[i].is_active);
            }
            return false;
        }

        public void LearnBySeveralExample(List<Tuple<int[], char>> ArrWithExample)
        {
            bool rez = false;
            while (!rez)
            {
                rez = true;
                foreach (var item in ArrWithExample)
                {
                    if (!LearnByOneExample(item.Item1, (item.Item2 == this.Name) ? true : false))
                    {
                        rez = false;
                    }
                }
            }
        }
    }
}
