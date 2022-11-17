namespace Logic
{
    public class Core
    {
        public int chromosomeLenght = 20;
        public int populationSize = 100;
        public double probabilityCrossover = 1;
        public double probabilityMutation = 0.1;
        public int CountMaxGeneration = 50;

        Func<int> fitnesFunc;

        public Core()
        {

        }

    }
}
