namespace Logic
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
            chromosomes = individual.chromosomes.ToList();
            fitness = individual.fitness;
        }

        public Individual Clone()
        {
            return new Individual(this);
        }


    }
}
