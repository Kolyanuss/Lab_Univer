﻿namespace Perceptrone_logic
{
    public class Neiron
    {
        private class entrances // вхід
        {
            public double entrance { get; set; }
            public double weight { get; set; }
            public entrances()
            {
                this.weight = GetRandNumInRange(-0.5, 0.5);
            }
            public entrances(bool isactive, double weight)
            {
                this.entrance = Convert.ToDouble(isactive);
                this.weight = weight;
            }
            public entrances(double isactive, double weight)
            {
                this.entrance = isactive;
                this.weight = weight;
            }
        }

        public enum ActivationFuncs
        {
            STEP, SIGMOID, LINEAR
        }

        public int CountOfEntrances { get; }
        private entrances[] arr_entrances; // всі входи мережі
        public double Tetta // sensitivity threshold || поріг чутливості
        {
            get { return -arr_entrances[0].weight; }
        }
        public double Learning_speed = 0.1;
        public char Name;
        /// <summary>
        /// Поріг активації сигмоїдної функції "y = fo(S)"
        /// </summary>
        public double activation_threshold_Y = 0.98;
        private Tuple<double, double> rangeOfEntraceWeight = new Tuple<double, double>(-1, 1);
        private Func<double> ActivationFunc;
        private ActivationFuncs CurrentActivFunc;
        public ActivationFuncs TypeActivFunc
        {
            get
            {
                return CurrentActivFunc;
            }
            set
            {
                CurrentActivFunc = value;
                switch (CurrentActivFunc)
                {
                    case ActivationFuncs.STEP:
                        ActivationFunc = ActivationFunc_Step;
                        break;
                    case ActivationFuncs.SIGMOID:
                        ActivationFunc = ActivationFunc_Sigmoid;
                        break;
                    case ActivationFuncs.LINEAR:
                        ActivationFunc = ActivationFunc_Linear;
                        break;
                    default:
                        ActivationFunc = ActivationFunc_Sigmoid;
                        break;
                }                
            }
        }

        public Neiron(int CountOfEntrances)
        {
            this.CountOfEntrances = CountOfEntrances + 1;
            BasicInit();
        }
        public Neiron(int CountOfEntrances, char name) : this(CountOfEntrances) => this.Name = name;
        private void BasicInit()
        {
            TypeActivFunc = ActivationFuncs.SIGMOID;

            arr_entrances = new entrances[this.CountOfEntrances];
            for (int i = 0; i < this.CountOfEntrances; i++)
            {
                arr_entrances.SetValue(new entrances(true, GetRandNumInRange(rangeOfEntraceWeight.Item1, rangeOfEntraceWeight.Item2)), i);
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
                S_weight += arr_entrances[i].entrance * arr_entrances[i].weight;
            }
            return S_weight;
        }

        /// <summary>
        /// Сигмоїдна функція активації
        /// </summary>
        private double ActivationFunc_Sigmoid()
        {
            return (1.0 / (1.0 + Math.Exp(0 - CalcWeight())));
        }
        /// <summary>
        /// активізаційна функція сходинки
        /// </summary>
        private double ActivationFunc_Step()
        {
            return CalcWeight() >= 0 ? 1 : 0;
        }
        private double ActivationFunc_Linear()
        {
            return CalcWeight();
        }

        public double GetNeuralError(double desire_response)
        {
            var Y = ActivationFunc();
            var res = desire_response - Y;
            if (TypeActivFunc == ActivationFuncs.SIGMOID)
            {
                res *= Y * (1.0 - Y);
            }
            return res;
        }

        /*public bool GetAnswerBool(int[] testMas)
        {
            SetEntrancesState(testMas);
            return ActivationFunc_Sigmoid() >= activation_threshold_Y ? true : false;
        }*/

        public double GetAnswerDouble(int[] testMas)
        {
            SetEntrancesState(testMas);
            return ActivationFunc();
        }
        public double GetAnswerDouble(double[] testMas)
        {
            SetEntrancesState(testMas);
            return ActivationFunc();
        }
        public double GetAnswerDouble()
        {
            return ActivationFunc();
        }

        #region get\set weight\state
        public List<double> GetAllWeight()
        {
            var list = new List<double>();
            foreach (var item in arr_entrances)
            {
                list.Add(item.weight);
            }
            return list;
        }
        public double GetEntranceWeight(int id_of_entrance)
        {
            return arr_entrances[id_of_entrance].weight;
        }
        /// <summary>
        /// parametr id_of_entrance always be +1 for ignore displacement entrance
        /// </summary>
        public double GetEntranceWeightWithRelationToNeuron(int id_of_entrance)
        {
            return arr_entrances[id_of_entrance + 1].weight;
        }
        public double GetEntranceState(int id_of_entrance)
        {
            return arr_entrances[id_of_entrance].entrance;
        }
        /// <summary>
        /// parametr id_of_entrance always be +1 for ignore displacement entrance
        /// </summary>
        public double GetEntranceStateWithRelationToNeuron(int id_of_entrance)
        {
            return arr_entrances[id_of_entrance + 1].entrance;
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
                arr_entrances[i].entrance = Convert.ToDouble(masState[i - 1]);
            }
        }
        public void SetEntrancesState(double[] masState)
        {
            if (masState.Length != CountOfEntrances - 1)
            {
                throw new Exception("Error with size dimension");
            }
            for (int i = 1; i < CountOfEntrances; i++)
            {
                arr_entrances[i].entrance = masState[i - 1];
            }
        }
        #endregion
    }
}
