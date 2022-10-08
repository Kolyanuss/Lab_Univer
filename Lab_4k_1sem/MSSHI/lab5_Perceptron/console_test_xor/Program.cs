using Perceptrone_logic;


var perc = new Perceptron2_xor();
var res = perc.Get_result(new int[2] { 1, 1 });
Console.WriteLine(res);
