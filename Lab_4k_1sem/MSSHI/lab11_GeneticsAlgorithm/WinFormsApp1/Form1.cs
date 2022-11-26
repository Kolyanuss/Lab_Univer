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
            var series = new LineSeries
            {
                Title = "test"
            };
            var Yaxis = new LinearAxis { Position = AxisPosition.Left, Title = "Fitness" };
            var Xaxis = new LinearAxis { Position = AxisPosition.Bottom, Title = "Generation" };

            myModel.Axes.Add(Yaxis);
            myModel.Axes.Add(Xaxis);

            var list = new GeneticAlgorithmCore().Start();
            for (int i = 0; i < list.Count; i++)
            {
                series.Points.Add(new DataPoint(i, list[i]));
            }

            myModel.Series.Add(series);
            plotView1.Model = myModel;
        }
    }
}