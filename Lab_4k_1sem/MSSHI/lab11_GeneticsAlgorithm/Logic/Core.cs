using System.Data.SqlTypes;

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

        private Random rnd;

        private readonly Func<Individual, double> fitnesFunc;
        private readonly Func<List<Individual>> selectionFunc;
        private readonly Action<Individual, Individual> crossoverFunc;

        public Core()
        {
            popolation = new List<Individual>();
            for (int i = 0; i < populationSize; i++)
            {
                popolation.Add(new Individual(countChromosomes, lenghtChromosome));
            }
            fitnesFunc = OneMaxFitness;
            selectionFunc = SelectionTournament;
            crossoverFunc = CrossoverOnePoint;

            rnd = new Random();
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

        private List<Individual> SelectionTournament()
        {
            var res = new List<Individual>();
            var rnd = new Random();
            for (int i = 0; i < popolation.Count; i++)
            {
                int x = 0, y = 0, z = 0;
                while (x == y || x == z || y == z)
                {
                    x = rnd.Next(populationSize);
                    y = rnd.Next(populationSize);
                    z = rnd.Next(populationSize);
                }
                res.Add(new List<Individual>() { popolation[x], popolation[y], popolation[z] }.MaxBy(o => o.fitness));
            }
            return res;
        }

        private void CrossoverOnePoint(Individual parent1, Individual parent2)
        {
            int s = new Random().Next(2, parent1.chromosomes[0].genes.Count - 2);
            for (int i = 0; i < parent1.chromosomes.Count; i++)
            {
                var gen1 = parent1.chromosomes[i].genes;
                var gen2 = parent2.chromosomes[i].genes;

                var slice1 = gen1.GetRange(s, gen1.Count - s);
                var slice2 = gen2.GetRange(s, gen2.Count - s);

                parent1.chromosomes[i].genes.RemoveRange(s, gen1.Count - s);
                parent1.chromosomes[i].genes.InsertRange(s, slice2);

                parent2.chromosomes[i].genes.RemoveRange(s, gen2.Count - s);
                parent2.chromosomes[i].genes.InsertRange(s, slice1);
            }
        }

        public void Start()
        {
            List<double> fitnessVal = new List<double>();
            foreach (var item in popolation)
            {
                fitnessVal.Add(fitnesFunc(item));
            }

            int generationCounter = 0;
            double oneMaxLenght = 100;
            while (fitnessVal.Max() < oneMaxLenght && generationCounter++ < maxCountGeneration)
            {
                var newGeneration = selectionFunc();

                for (int i = 0; i < populationSize; i+=2)
                {

                }
            }
        }

    }
}
