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

        public void MutationFlipBit()
        {
            int index = rnd.Next(genes.Count);
            genes[index] = genes[index] == 0 ? 1 : 0;
        }
    }
}
