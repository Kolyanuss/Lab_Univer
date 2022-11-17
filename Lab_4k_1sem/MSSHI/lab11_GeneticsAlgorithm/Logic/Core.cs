namespace Logic
{
    public class Core
    {
        public int lenghtChromosome = 20;
        public int countChromosomes = 20;
        public int populationSize = 100;
        public double probabilityCrossover = 1;
        public double probabilityMutation = 0.1;
        public int maxCountGeneration = 50;
        public List<Individual> individuals;

        Func<int> fitnesFunc;

        public Core()
        {
            individuals = new List<Individual>();
            //fitnesFunc = 
            CreateIndividuals();
        }

        private void CreateIndividuals()
        {
            individuals.Clear();
            for (int i = 0; i < populationSize; i++)
            {
                individuals.Add(new Individual(countChromosomes, lenghtChromosome));
            }
        }

    }
}
