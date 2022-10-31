using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBlock
{
    public static class MyExtensions
    {
        private static Random rng = new Random();
        private static double min = 0;
        private static double max = 100;

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public static double[] MyNormalization(int[] vector)
        {
            var result = new double[vector.Length];
            if (vector.Min() < min)
            {
                min = vector.Min();
            }
            if (vector.Max() > max)
            {
                max = vector.Max();
            }
            double mean = max - min;
            for (int i = 0; i < vector.Length; i++)
            {
                result[i] = (vector[i] - min) / mean;
            }
            return result;
        }

        public static double[] MyNormalization(double[] vector)
        {
            var result = new double[vector.Length];
            if (vector.Min() < min)
            {
                min = vector.Min();
            }
            if (vector.Max() > max)
            {
                max = vector.Max();
            }
            double mean = max - min;
            for (int i = 0; i < vector.Length; i++)
            {
                result[i] = (vector[i] - min) / mean;
            }
            return result;
        }
    }
}
