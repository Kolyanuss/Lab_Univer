﻿namespace Logic
{
    public class Individual
    {
        public List<Chromosome> chromosomes;
        public double fitness;

        public Individual(int countChromosomes, int lenghtChromosome)
        {
            chromosomes = new List<Chromosome>();
            for (int i = 0; i < countChromosomes; i++)
            {
                chromosomes.Add(new Chromosome(lenghtChromosome));
            }
        }

        public Individual(Individual individual)
        {
            chromosomes = new List<Chromosome>();
            foreach (var item in individual.chromosomes)
            {
                chromosomes.Add(item.Clone());
            }
            fitness = individual.fitness;
        }

        public Individual Clone()
        {
            return new Individual(this);
        }

        public void MutationFlipBit()
        {
            int index = new Random().Next(chromosomes.Count);
            chromosomes[index].MutationFlipBit();
        }
    }
}
