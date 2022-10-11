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

for (int i = 0; i < 1; i++)
{
    var perc = new Perceptron2();
    perc.countOfEpochs = 10000;
    perc.StartLearn(examples);

    var example = new int[] { 1, 0 };
    var res = perc.Get_result(example);
    Console.WriteLine("for ({0};{1}), res: {2}", example[0], example[1], res[0]);
}
