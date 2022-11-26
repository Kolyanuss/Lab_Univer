namespace Logic
{
    public class Chromosome
    {
        public List<int> genes;
        private Random rnd;

        public Chromosome(int lenghtChromosome)
        {
            genes = new List<int>();
            rnd = new Random();
            for (int i = 0; i < lenghtChromosome; i++)
            {
                genes.Add(rnd.Next(2)); // 0 or 1
            }
        }

        public Chromosome(Chromosome chromosome)
        {
            genes = new List<int>(chromosome.genes);
            rnd = chromosome.rnd;
        }

        public Chromosome Clone()
        {
            return new Chromosome(this);
        }

        public void MutationFlipBit()
        {
            double internalProbabilityMutation = 1.0 / genes.Count;
            for (int i = 0; i < genes.Count; i++)
            {
                if (rnd.NextDouble() < internalProbabilityMutation)
                {
                    genes[i] = genes[i] == 0 ? 1 : 0;
                }
            }
        }
    }
}
