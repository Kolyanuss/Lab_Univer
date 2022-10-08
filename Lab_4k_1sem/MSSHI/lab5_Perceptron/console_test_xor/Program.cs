using Perceptrone_logic;

var examples = new List<Tuple<int[], bool>>();
examples.Add(
    new Tuple<int[], bool>(
        new int[] { 0, 0 }, false)
    );
examples.Add(
    new Tuple<int[], bool>(
        new int[] { 0, 1 }, true)
    );
examples.Add(
    new Tuple<int[], bool>(
        new int[] { 1, 0 }, true)
    );
examples.Add(
    new Tuple<int[], bool>(
        new int[] { 1, 1 }, false)
    );


var perc = new Perceptron2_xor();
perc.StartLearn(examples);
var res = perc.Get_result(new int[] { 1, 0 });
Console.WriteLine(res);
