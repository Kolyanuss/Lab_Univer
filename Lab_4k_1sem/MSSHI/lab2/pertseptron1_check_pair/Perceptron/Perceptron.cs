using System;
using System.Collections.Generic;

namespace Perceptron_logic
{
    public class Perceptron
    {
        private class entrances // входи
        {
            public bool is_active { get; set; }
            public int weight { get; set; }
            public entrances()
            {
                this.weight = new Random().Next(-5, 5);
            }
        }

        public const int size = 48;
        // розмір можна міняти, в цьому класі ніде залежноті від константного розміру немає

        private entrances[] arr_entrances;

        public int Tetta = new Random().Next(-2, 2); // sensitivity threshold || поріг чутливості


        public Perceptron()
        {
            arr_entrances = new entrances[size];
            for (int i = 0; i < size; i++)
            {
                arr_entrances.SetValue(new entrances(), i);
            }
        }

        private int CalcWeight()
        {
            int S_weight = 0;
            for (int i = 0; i < size; i++)
            {
                if (arr_entrances[i].is_active)
                {
                    S_weight += arr_entrances[i].weight;
                }
            }
            return S_weight;
        }

        private bool CalcY()
        {
            return CalcWeight() >= this.Tetta;
        }

        public void ChangeEntrancesState(int[] masState)
        {
            if (masState.Length != size)
            {
                throw new Exception("Error with size dimension");
            }
            for (int i = 0; i < size; i++)
            {
                arr_entrances[i].is_active = Convert.ToBoolean(masState[i]);
            }
        }

        public void Start(int[] testMas)
        {
            ChangeEntrancesState(testMas);
            if (this.CalcY())
            {
                Console.WriteLine("Число ПАРНЕ!");
            }
            else Console.WriteLine("Число НЕ ПАРНЕ!");
        }

        public string CheckNum(int[] testMas)
        {
            ChangeEntrancesState(testMas);
            if (this.CalcY())
            {
                return "ПАРНЕ!";
            }
            else return "НЕ ПАРНЕ!";
        }

        public bool LearnByOne(int[] masState, bool real_rez_y)
        {
            ChangeEntrancesState(masState);
            bool rez_y = this.CalcY();
            if (rez_y != real_rez_y)
            {
                if (rez_y)
                {
                    for (int i = 0; i < size; i++)
                    {
                        arr_entrances[i].weight -= Convert.ToInt32(arr_entrances[i].is_active);
                    }
                }
                else
                    for (int i = 0; i < size; i++)
                    {
                        arr_entrances[i].weight += Convert.ToInt32(arr_entrances[i].is_active);
                    }
                return false;
            }
            return true;
        }

        public void LearnBySeveralArr(List<Tuple<int[], bool>> ArrWithNum)
        {
            bool rez = false;
            while (!rez)
            {
                Console.WriteLine("\n----Start learn again----");
                rez = true;
                foreach (var item in ArrWithNum)
                {
                    if(!LearnByOne(item.Item1, item.Item2))
                    {
                        rez = false;
                        Console.Write("F");
                    }
                }
            }
            Console.WriteLine("--------END learn--------");
        }
    }
}
