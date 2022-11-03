namespace DataBlock
{
    public static class MyExtensions
    {
        private static Random rng = new Random();
        public static double min;
        public static double max;

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

        public static void FindMinMax<T>(List<Tuple<T[], double[]>> data)
        {
            max = double.MinValue;
            min = double.MaxValue;
            foreach (var item in data)
            {
                if (Convert.ToDouble(item.Item1.Max()) > max)
                {
                    max = Convert.ToDouble(item.Item1.Max());
                }
                if (Convert.ToDouble(item.Item1.Min()) < min)
                {
                    min = Convert.ToDouble(item.Item1.Min());
                }
            }
        }

        public static double[] MyNormalization<T>(T[] vector)
        {
            double mean = max - min;

            var result = new double[vector.Length];
            for (int i = 0; i < vector.Length; i++)
            {
                result[i] = (Convert.ToDouble(vector[i]) - min) / mean;
            }
            return result;
        }
    }
}
