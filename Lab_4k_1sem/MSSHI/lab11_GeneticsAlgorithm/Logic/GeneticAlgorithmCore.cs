﻿namespace Logic
{
    public class GeneticAlgorithmCore
    {
        public readonly int lenghtChromosome = 100;
        public readonly int countChromosomes = 1;
        public readonly int populationSize = 200;
        public double probabilityCrossover = 1;
        public double probabilityMutation = 0.1;
        public int maxCountGeneration = 50;
        private List<Individual> popolation;

        private readonly Random rnd;

        private readonly Func<Individual, double> fitnesFunc;
        private readonly Func<List<Individual>> selectionFunc;
        private readonly Action<Individual, Individual> crossoverFunc;

        public GeneticAlgorithmCore()
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
            var newGeneration = new List<Individual>();
            for (int i = 0; i < popolation.Count; i++)
            {
                int x = 0, y = 0, z = 0;
                while (x == y || x == z || y == z)
                {
                    x = rnd.Next(populationSize);
                    y = rnd.Next(populationSize);
                    z = rnd.Next(populationSize);
                }
                Individual individualCopy = new Individual(
                    new List<Individual>() { popolation[x], popolation[y], popolation[z] }.MaxBy(o => o.fitness));
                newGeneration.Add(individualCopy);
            }

            return newGeneration;
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

        private List<double> UpdateFitnes()
        {
            List<double> fitnessVal = new List<double>();
            foreach (var item in popolation)
            {
                fitnessVal.Add(fitnesFunc(item));
            }
            return fitnessVal;
        }

        public List<double> Start()
        {
            List<double> fitnessVal = UpdateFitnes();
            List<double> listMaxFitnes = new List<double>();

            int generationCounter = 0;
            double oneMaxLenght = popolation[0].chromosomes.Count * popolation[0].chromosomes[0].genes.Count;
            while (fitnessVal.Max() < oneMaxLenght && generationCounter++ < maxCountGeneration)
            {
                listMaxFitnes.Add(fitnessVal.Max());

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

                popolation = newGeneration;
                fitnessVal = UpdateFitnes();
            }
            return listMaxFitnes;
        }
    }
}
