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
                neirons[i].LearnBySeveralExample(data);
            }
        }

        public string Guess_letter(int[] arrWithState)
        {
            for (int i = 0; i < neirons.Length; i++)
            {
                var x = neirons[i].GetAnswerWithPercent(arrWithState);
                if (x != null)
                {
                    return "Це " + x;
                }
            }
            return "Не вдається впізнати літеру!";
        }
    }
}
