using Perceptrone_logic;

var examples = new List<Tuple<int[], double[]>>();
examples.Add(
    new Tuple<int[], double[]>(
        new int[] { 0, 0 },
        new double[] { 0 })
    );
examples.Add(
    new Tuple<int[], double[]>(
        new int[] { 0, 1 },
        new double[] { 1 })
    );
examples.Add(
    new Tuple<int[], double[]>(
        new int[] { 1, 0 },
        new double[] { 1 })
    );
examples.Add(
    new Tuple<int[], double[]>(
        new int[] { 1, 1 },
        new double[] { 0 })
    );

for (int i = 0; i < 20; i++)
{
    var perc = new Perceptron2_xor_Copy();
    perc.StartLearn(examples, 300);
    var res = perc.Get_result(new int[] { 1, 1 });
    Console.WriteLine("res: " + res);
}
