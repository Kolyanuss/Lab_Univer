using Logic;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var myModel = new PlotModel();
            var Yaxis = new LinearAxis { Position = AxisPosition.Left, Title = "Fitness" };
            var Xaxis = new LinearAxis { Position = AxisPosition.Bottom, Title = "Generation" };
            myModel.Axes.Add(Yaxis);
            myModel.Axes.Add(Xaxis);

            var tupe = new GeneticAlgorithmCore().Start();
            var list1 = tupe.Item1;
            var list2 = tupe.Item2;
            var series1 = new LineSeries { Title = "max" };
            var series2 = new LineSeries { Title = "mean" };
            for (int i = 0; i < list1.Count; i++)
            {
                series1.Points.Add(new DataPoint(i, list1[i]));
                series2.Points.Add(new DataPoint(i, list2[i]));
            }

            myModel.Series.Add(series1);
            myModel.Series.Add(series2);
            plotView1.Model = myModel;
        }
    }
}