using System.Reflection.Emit;

namespace Perceptrone_logic
{
    public class Perceptron2_xor
    {
        private Neiron[] hiden_layer;
        private Neiron[] output_layer;

        public Perceptron2_xor()
        {
            hiden_layer = new Neiron[2];
            for (int i = 0; i < hiden_layer.Length; i++)
            {
                hiden_layer[i] = new Neiron(2);
            }

            output_layer = new Neiron[1];
            for (int i = 0; i < output_layer.Length; i++)
            {
                output_layer[i] = new Neiron(hiden_layer.Length);
            }
        }

        public void StartLearn(List<Tuple<int[], bool>> data)
        {
        }

        public string Get_result(int[] arrWithState)
        {
            var inputData = arrWithState;
            int[] outputData = new int[hiden_layer.Length];
            for (int i = 0; i < hiden_layer.Length; i++)
            {
                outputData[i] = hiden_layer[i].GetAnswer(inputData);
            }

            inputData = outputData;
            outputData = new int[output_layer.Length];
            for (int i = 0; i < output_layer.Length; i++)
            {
                outputData[i] = output_layer[i].GetAnswer(inputData);
            }
            return "" + outputData;
        }
    }
}
