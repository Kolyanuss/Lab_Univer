namespace Logic
{
    public class Individual
    {
        public List<Chromosome> chromosomes;

        public Individual(int countChromosomes, int lenghtChromosome)
        {
            chromosomes = new List<Chromosome>();
            for (int i = 0; i < countChromosomes; i++)
            {
                chromosomes.Add(new Chromosome(lenghtChromosome));
            }
        }
    }
}
