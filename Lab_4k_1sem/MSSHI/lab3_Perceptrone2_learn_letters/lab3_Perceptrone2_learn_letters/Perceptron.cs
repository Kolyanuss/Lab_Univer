using DataBlock;
using System;
using System.Collections.Generic;

namespace lab3_Perceptrone2_learn_letters
{
    public class Perceptron
    {
        private Neiron[] neirons;
        public int numOfLetter = 33;

        public Perceptron()
        {
            neirons = new Neiron[numOfLetter];

            char A_letter = Convert.ToChar(1040);
            char[] additionalVal = new char[7] { 'Ґ', 'Є', 'І', 'Ї', 'Ь', 'Ю', 'Я' };

            for (int i = 0; i < neirons.Length - 7; i++)
            {
                //Console.WriteLine(A_letter);
                neirons[i] = new Neiron(A_letter++);
            }
            for (int i = 0; i < additionalVal.Length; i++)
            {
                //Console.WriteLine(additionalVal[i]);
                neirons[neirons.Length - 7 + i] = new Neiron(additionalVal[i]);
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
                var x = neirons[i].GetAnswer(arrWithState);
                if (x != null)
                {
                    return "Це " + x;
                }
            }
            return "Не вдається впізнати літеру!";
        }
    }
}
