namespace Perceptrone_logic
{
    public class Perceptron
    {
        private Neiron[] neirons;
        public const int numOfLetter = 33;
        /// <summary>
        /// How many parts will the picture be divided into on the X axis.
        /// На скільки частин буде поділятись картинка по осі Х
        /// </summary>
        public int sizeX { get; } = 6;
        /// <summary>
        /// How many parts will the picture be divided into on the Y axis.
        /// На скільки частин буде поділятись картинка по осі Y
        /// </summary>
        public int sizeY { get; } = 8;
        public int generalSize { get { return sizeX * sizeY; } }

        public Perceptron()
        {
            neirons = new Neiron[numOfLetter];

            char A_letter = Convert.ToChar(1040);
            char[] additionalVal = new char[7] { 'Ґ', 'Є', 'І', 'Ї', 'Ь', 'Ю', 'Я' };

            for (int i = 0; i < neirons.Length - 7; i++)
            {
                neirons[i] = new Neiron(A_letter++);
            }
            for (int i = 0; i < additionalVal.Length; i++)
            {
                neirons[neirons.Length - 7 + i] = new Neiron(additionalVal[i]);
            }
        }

        public Perceptron(int sizeX, int sizeY)
        {
            this.sizeX = sizeX;
            this.sizeY = sizeY;
            neirons = new Neiron[numOfLetter];

            char A_letter = Convert.ToChar(1040);
            char[] additionalVal = new char[7] { 'Ґ', 'Є', 'І', 'Ї', 'Ь', 'Ю', 'Я' };

            for (int i = 0; i < neirons.Length - 7; i++)
            {
                neirons[i] = new Neiron(A_letter++, generalSize);
            }
            for (int i = 0; i < additionalVal.Length; i++)
            {
                neirons[neirons.Length - 7 + i] = new Neiron(additionalVal[i], generalSize);
            }
        }

        public void StartLearn(List<Tuple<int[], char>> data)
        {
            for (int i = 0; i < numOfLetter; i++)
            {
                Teacher.Learn_letter_DerivationOfTheDeltaRule(neirons[i],data);
            }
        }

        public string Guess_letter(int[] arrWithState)
        {
            for (int i = 0; i < neirons.Length; i++)
            {
                var x = neirons[i].GetAnswerWithPercent(arrWithState);
                if (x != null)
                {
                    return "Це " + x.Item1 + " з вірогідністю в " + String.Format("{0:0.0000}", x.Item2 * 100) + "%";
                }
            }
            return "Не вдається впізнати літеру!";
        }

        public List<string> Guess_letter_and_return_all_percent(int[] arrWithState)
        {
            List<string> list = new List<string>();
            for (int i = 0; i < neirons.Length; i++)
            {
                var x = neirons[i].GetAllAnswerWithPercent(arrWithState);
                list.Add("" + x.Item1 + "\t " + String.Format("{0:0.0000}", x.Item2 * 100) + "%");
            }
            return list;
        }

        public Dictionary<char, List<double>> GetWeightToSave()
        {
            var rez = new Dictionary<char, List<double>>();
            foreach (var item in neirons)
            {
                var x = item.GetEntranceWeight();
                rez.Add(x.Item1, x.Item2);
            }
            return rez;
        }

        public void SetWeight(Dictionary<char, List<double>> items)
        {
            for (int i = 0; i < neirons.Length; i++)
            {
                neirons[i].SetEntrancesWeight(items[neirons[i].Name]);
            }
        }
    }
}
