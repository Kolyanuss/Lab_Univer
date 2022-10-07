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

        public int CountOfEntrances { get; }
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

        public Neiron(int CountOfEntrances)
        {
            this.CountOfEntrances = CountOfEntrances + 1;
            arr_entrances = new entrances[this.CountOfEntrances];

            arr_entrances.SetValue(new entrances(true, GetRandNumInRange(-2, 2)), 0);
            for (int i = 1; i < this.CountOfEntrances; i++)
            {
                arr_entrances.SetValue(new entrances(), i);
            }
        }
        public Neiron(char name)
        {
            this.Name = name;
            this.CountOfEntrances = 48 + 1;
            arr_entrances = new entrances[CountOfEntrances];

            arr_entrances.SetValue(new entrances(true, GetRandNumInRange(-2, 2)), 0);
            for (int i = 1; i < CountOfEntrances; i++)
            {
                arr_entrances.SetValue(new entrances(), i);
            }
        }
        public Neiron(char name, int CountOfEntrances)
        {
            this.Name = name;
            this.CountOfEntrances = CountOfEntrances + 1;
            arr_entrances = new entrances[this.CountOfEntrances];

            arr_entrances.SetValue(new entrances(true, GetRandNumInRange(-2, 2)), 0);
            for (int i = 1; i < this.CountOfEntrances; i++)
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
            for (int i = 0; i < CountOfEntrances; i++)
            {
                S_weight += Convert.ToInt32(arr_entrances[i].is_active) * arr_entrances[i].weight;
            }
            return S_weight;
        }

        /// <summary>
        /// Сигмоїдна функція активації
        /// </summary>
        public double CalcY()
        {
            return 1 / (1 + Math.Exp(0 - CalcWeight()));
        }
        public int GetAnswer(int[] testMas)
        {
            SetEntrancesState(testMas);
            return CalcY() >= activation_threshold_Y ? 1 : 0;
        }

        public Tuple<char, double>? GetAnswerWithPercent(int[] testMas)
        {
            SetEntrancesState(testMas);
            var y = CalcY();
            return y >= activation_threshold_Y ? new Tuple<char, double>(Name, y) : null;
        }
        public Tuple<char, double> GetAllAnswerWithPercent(int[] testMas)
        {
            SetEntrancesState(testMas);
            var y = CalcY();
            return new Tuple<char, double>(Name, y);
        }


        #region get\set
        public Tuple<char, List<double>> GetEntranceWeight()
        {
            var list = new List<double>();
            foreach (var item in arr_entrances)
            {
                list.Add(item.weight);
            }
            return new Tuple<char, List<double>>(Name, list);

        }
        public double GetEntranceWeight(int id_of_entrance)
        {
            return arr_entrances[id_of_entrance].weight;
        }
        public bool GetEntranceState(int id_of_entrance)
        {
            return arr_entrances[id_of_entrance].is_active;
        }

        public void SetEntrancesWeight(List<double> list)
        {
            for (int i = 0; i < arr_entrances.Length; i++)
            {
                arr_entrances[i].weight = list[i];
            }
        }
        public void SetEntrancesWeight(int id_of_entrance, double weight)
        {
            arr_entrances[id_of_entrance].weight = weight;
        }
        public void SetEntrancesState(int[] masState)
        {
            if (masState.Length != CountOfEntrances - 1)
            {
                throw new Exception("Error with size dimension");
            }
            for (int i = 1; i < CountOfEntrances; i++)
            {
                arr_entrances[i].is_active = Convert.ToBoolean(masState[i - 1]);
            }
        }
        #endregion
    }
}
