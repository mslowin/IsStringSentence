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
        public Word? Header { get; set; }
        
        /// <summary>
        /// List of words in a sentance exept first and last word.
        /// </summary>
        public List <Word>? Words { get; set; }

        /// <summary>
        /// Sentance ending word.
        /// </summary>
        public Word? End { get; set; }

        /// <summary>
        /// Constructor of Sentance Class. Sets all sentance parameters.
        /// </summary>
        /// <param name="newSentance">String with a sentance.</param>
        public Sentance(string newSentance)
        {
            var words = newSentance.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Header = new Word(words[0]);
            End = new Word(words[^1]);

            Words = new List<Word>();
            for (int i = 1; i < words.Length - 1; i++)
            {
                Words.Add(new Word(words[i]));
            }
        }

        public bool IsSentanceOk()
        {
            int okCounter = 0;
            if (Header!.IsHeaderOk() && End!.IsEndOk())
            {
                Words!.Where(word => word.IsWordOk()).ToList().ForEach(word => { okCounter++; });
                if (okCounter == Words!.Count)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
