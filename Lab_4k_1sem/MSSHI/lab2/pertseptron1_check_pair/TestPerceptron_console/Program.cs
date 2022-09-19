using Perceptron_logic;
using DataBlock;

for (int i = 0; i < 30; i++)
{
    var myPerc = new Perceptron();
    myPerc.LearnBySeveralArr(DataForLearn.NumForLearn);
    myPerc.Start(DataForLearn.num7);
}
