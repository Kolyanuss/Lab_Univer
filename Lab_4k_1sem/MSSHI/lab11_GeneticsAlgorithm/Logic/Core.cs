namespace Logic
{
    public class Core
    {
        public readonly int lenghtChromosome = 20;
        public readonly int countChromosomes = 20;
        public readonly int populationSize = 100;
        public double probabilityCrossover = 1;
        public double probabilityMutation = 0.1;
        public int maxCountGeneration = 50;
        public List<Individual> popolation;

        private readonly Func<Individual, double> fitnesFunc;

        public Core()
        {
            popolation = new List<Individual>();
            for (int i = 0; i < populationSize; i++)
            {
                popolation.Add(new Individual(countChromosomes, lenghtChromosome));
            }
            fitnesFunc = OneMaxFitness;
        }

        private double OneMaxFitness(Individual individual)
        {
            individual.fitness = 0;
            foreach (var chromosome in individual.chromosomes)
            {
                individual.fitness += chromosome.genes.Sum();
            }
            return individual.fitness;
        }

        public void Start()
        {
            foreach (var item in popolation)
            {
                fitnesFunc(item);
            }
        }

    }
}
