using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsStringSentence
{
    internal class Word
    {
        public string Text { get; set; }

        public Word(string newWord)
        {
            Text = newWord;
        }

        public bool IsHeaderOk()
        {
            // tutaj czy Text jest z dużej litery, jakaś metoda, która sprawdza, czy wyraz jest okej (nie ma przerywników w środku, albo jest z samych liter lub cyfr)
            // TODO: dodać README.md

            throw new NotImplementedException();
        }

        public bool IsWordOk()
        {
            if (int.TryParse(Text[0].ToString(), out _))  // when the string is a number
            {
                return CheckIfNumberOk(Text);
            }
            else
            {
                return CheckIfWordOk(Text);
            }
        }

        private static bool CheckIfWordOk(string word)
        {
            int okCounter = 0;
            for (int i = 0; i < word.Length - 1; i++)
            {
                if (word[i] <= 'Z' && word[i] >= 'A' || word[i] <= 'z' && word[i] >= 'a')
                {
                    okCounter++;
                }
            }
            if (word[word.Length - 1] == ',')  // comma at the end of a word is ok
            {
                okCounter++;
            }
            if (okCounter == word.Length) { return true; }  // the word is ok
            else { return false; }
        }

        private static bool CheckIfNumberOk(string word)
        {
            int okCounter = 0;
            for (int i = 0; i < word.Length - 1; i++)
            {
                if (int.TryParse(word[i].ToString(), out _))
                {
                    okCounter++;
                }
            }
            if (word[word.Length - 1] == ',')  // comma at the end of a word is ok
            {
                okCounter++;
            }
            if (okCounter == word.Length) { return true; }  // the word is ok
            else { return false; }
        }
    }
}
