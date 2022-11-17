namespace Logic
{
    public class Chromosome
    {
        public List<bool> genes;

        public Chromosome(int lenghtChromosome)
        {
            genes = new List<bool>();
            var rnd = new Random();
            for (int i = 0; i < lenghtChromosome; i++)
            {
                bool x = (rnd.NextDouble() < 0.5) ? false : true;
                genes.Add(x);
            }
        }
    }
}
