namespace Logic
{
    public class GeneticAlgorithmCore
    {
        public readonly int lenghtChromosome = 10;
        public readonly int countChromosomes = 1;
        public readonly int populationSize = 10;
        public double probabilityCrossover = 1;
        public double probabilityMutation = 0.05;
        public int maxCountGeneration = 100;
        private List<Individual> population;
        private double maxResult;
        private readonly Random rnd;

        private readonly Func<Individual, double> fitnesFunc;
        private readonly Func<List<double>, bool> isMaxFitnesValFunc;
        private readonly Func<List<Individual>> selectionFunc;
        private readonly Action<Individual, Individual> crossoverFunc;

        public GeneticAlgorithmCore()
        {
            population = new List<Individual>();
            for (int i = 0; i < populationSize; i++)
            {
                population.Add(new Individual(countChromosomes, lenghtChromosome));
            }
            fitnesFunc = FxFitness;
            isMaxFitnesValFunc = IsMaxFitnesVal;
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

        private bool IsMaxFitnesValOneMax(List<double> fitnessVal)
        {
            maxResult = population[0].chromosomes.Count * population[0].chromosomes[0].genes.Count;
            return fitnessVal.Max() == maxResult;
        }

        private double FxFitness(Individual individual)
        {
            var str = string.Join("", individual.chromosomes[0].genes.ToArray());
            var x = Convert.ToInt32(str, 2);
            individual.fitness = 2 * x * x + 1;
            return individual.fitness;
        }

        private bool IsMaxFitnesVal(List<double> fitnessVal)
        {
            maxResult = double.MaxValue;
            return fitnessVal.Max() == maxResult;
        }

        private List<Individual> SelectionTournament()
        {
            var newGeneration = new List<Individual>();
            for (int i = 0; i < populationSize; i++)
            {
                int x = 0, y = 0, z = 0;
                while (x == y || x == z || y == z)
                {
                    x = rnd.Next(populationSize);
                    y = rnd.Next(populationSize);
                    z = rnd.Next(populationSize);
                }
                List<Individual> listOfThreeIndivid = new() { population[x], population[y], population[z] };
                var bestIndivid = listOfThreeIndivid.MaxBy(individ => individ.fitness).Clone();
                newGeneration.Add(bestIndivid);
            }
            return newGeneration;
        }

        private void CrossoverOnePoint(Individual parent1, Individual parent2)
        {
            if (parent1.chromosomes[0].genes.Count < 3)
            {
                throw new ArgumentException("неможливо проводити схрещування із малою кількість генів");
            }
            int s = new Random().Next(1, parent1.chromosomes[0].genes.Count - 1);

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

        private List<double> UpdateFitnes()
        {
            var fitnessVal = new List<double>();
            foreach (var item in population)
            {
                fitnessVal.Add(fitnesFunc(item));
            }
            return fitnessVal;
        }

        public Individual Start(List<double> listMaxFitnes, List<double> listMeanFitnes)
        {
            List<double> fitnessVal = UpdateFitnes();
            listMaxFitnes.Add(fitnessVal.Max());
            listMeanFitnes.Add(fitnessVal.Average());

            int generationCounter = 0;

            while (!isMaxFitnesValFunc(fitnessVal) && generationCounter++ < maxCountGeneration)
            {
                var newGeneration = selectionFunc();

                for (int i = 0; i < populationSize - 1; i += 2)
                {
                    if (rnd.NextDouble() < probabilityCrossover)
                    {
                        crossoverFunc(newGeneration[i], newGeneration[i + 1]);
                    }
                }

                foreach (var item in newGeneration)
                {
                    if (rnd.NextDouble() < probabilityMutation)
                    {
                        item.MutationFlipBit();
                    }
                }

                population = newGeneration;
                fitnessVal = UpdateFitnes();

                listMaxFitnes.Add(fitnessVal.Max());
                listMeanFitnes.Add(fitnessVal.Average());
            }
            foreach (var item in population)
            {
                if (item.fitness == maxResult)
                {
                    return item;
                }
            }
            return population.MaxBy(idivid => idivid.fitness);
        }
    }
}
