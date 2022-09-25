using System;
using System.Collections.Generic;

namespace lab3_Perceptrone2_learn_letters
{
    public class Neiron
    {
        private class entrances // вхід
        {
            public bool is_active { get; set; }
            public double weight { get; set; }
            public entrances()
            {
                this.weight = new Random().Next(-5, 5);
            }
            public entrances(bool isactive, int weight)
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


        public Neiron(char name)
        {
            this.Name = name;
            this.size = 48 + 1;
            arr_entrances = new entrances[size];

            arr_entrances.SetValue(new entrances(true, new Random().Next(-2, 2)), 0);
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

            arr_entrances.SetValue(new entrances(true, new Random().Next(-2, 2)), 0);
            for (int i = 1; i < this.size; i++)
            {
                arr_entrances.SetValue(new entrances(), i);
            }
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

        private bool CalcY()
        {
            return CalcWeight() >= 0;
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
            return CalcY() ? Name : null;
        }

        private bool LearnByOneExample(int[] masState, bool desire_response)
        {
            ChangeEntrancesState(masState);
            bool rez_y = this.CalcY();
            int E = Convert.ToInt32(desire_response) - Convert.ToInt32(rez_y);
            if (E != 0)
            {
                for (int i = 0; i < size; i++)
                {
                    arr_entrances[i].weight += Learning_speed * E * Convert.ToInt32(arr_entrances[i].is_active);
                }
                return false;
            }
            return true;
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
