using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsStringSentence
{
    internal class Sentance
    {
        /// <summary>
        /// Header word.
        /// </summary>
        public Word Header { get; set; }
        
        /// <summary>
        /// List of words in a sentance exept first and last word.
        /// </summary>
        public List <Word> Words { get; set; }

        /// <summary>
        /// Sentance ending word.
        /// </summary>
        public Word End { get; set; }

        /// <summary>
        /// Count of all words in a sentance.
        /// </summary>
        public int AllWordsCount { get; set; }

        /// <summary>
        /// Constructor of Sentance Class. Sets all sentance parameters.
        /// </summary>
        /// <param name="newSentance">String with a sentance.</param>
        public Sentance(string newSentance)
        {
            var words = newSentance.Split(' ', StringSplitOptions.RemoveEmptyEntries);  // splitting string on spaces

            AllWordsCount = words.Length;
            Header = new Word(words[0]);  // Header is the first word
            End = new Word(words[^1]);  // End is the last one
            Words = new List<Word>();
            for (int i = 1; i < words.Length - 1; i++)
            {
                Words.Add(new Word(words[i]));
            }
        }

        /// <summary>
        /// Checks if a sentance is Ok (Checks each word separately).
        /// </summary>
        /// <returns>True if the sentance is Ok, otherwise false.</returns>
        public bool IsSentanceOk()
        {
            if (AllWordsCount == 1)  // if sentance consists of one word
            {
                if (End!.IsEndOk())
                {
                    return true;
                }
                else { return false; }
            }

            int okCounter = 0;
            if (Header.IsHeaderOk() && End.IsEndOk())  // if both Header and End are ok
            {
                Words.Where(word => word.IsWordOk()).ToList().ForEach(word => { okCounter++; });  // we check each word in Words and increment okCounter
                if (okCounter == Words.Count)  // if okCounter is equal to the number of words (excluding Header and End) sentance is OK
                {
                    return true;
                }
            }
            return false;
        }
    }
}
