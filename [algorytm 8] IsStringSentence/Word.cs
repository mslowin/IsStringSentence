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

            throw new NotImplementedException();
        }
    }
}
