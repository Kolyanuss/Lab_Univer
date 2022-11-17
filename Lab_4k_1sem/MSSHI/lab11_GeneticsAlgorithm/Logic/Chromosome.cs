namespace Logic
{
    public class Chromosome
    {
        public List<int> genes;

        public Chromosome(int lenghtChromosome)
        {
            genes = new List<int>();
            var rnd = new Random();
            for (int i = 0; i < lenghtChromosome; i++)
            {
                genes.Add(rnd.Next(2)); // 0 or 1
            }
        }
    }
}
