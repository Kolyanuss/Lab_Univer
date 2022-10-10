namespace Perceptrone_logic
{
    public class Perceptron2_xor_Copy
    {
        public const int countOfInputEntrances = 2;
        public int countOfEpochs = 100;
        public Neiron neuron_hide_1;
        public Neiron neuron_hide_2;
        public Neiron neuron_out;

        public Perceptron2_xor_Copy()
        {
            neuron_hide_1 = new Neiron(2);
            neuron_hide_2 = new Neiron(2);
            neuron_out = new Neiron(2);
        }

        public void StartLearn(List<Tuple<int[], double[]>> data, int countOfEpochs = 100)
        {
            this.countOfEpochs = countOfEpochs;
            var res = Teacher.Learn_xor_backpropagation(this, data, this.countOfEpochs);
            Console.WriteLine("Epochs: {0}.\nСередньоквадратична помилка: ({1};{2})", res.Item1, res.Item2);
        }

        /// <summary>
        /// Видає результат роботи навченої моделі
        /// </summary>
        /// <param name="arrWithState">Довжина arrWithState повинна дорівнювати "countOfEntrances"</param>
        /// <returns></returns>
        public string Get_result(int[] arrWithState)
        {
            if (arrWithState.Length != countOfInputEntrances)
            {
                return "Неправильна довжина вхідного масиву даних!";
            }
            double[] outputData = new double[2];
            outputData[0] = neuron_hide_1.GetAnswerDouble(arrWithState);
            outputData[1] = neuron_hide_2.GetAnswerDouble(arrWithState);
            double finalY = neuron_out.GetAnswerDouble(outputData);

            return ""+finalY;
        }
    }
}
