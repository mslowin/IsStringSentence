using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsStringSentence
{
    internal class Word
    {
        /// <summary>
        /// String which makes the word
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Constructor of Word class.
        /// </summary>
        /// <param name="newWord">String which makes the word.</param>
        public Word(string newWord)
        {
            Text = newWord;
        }
        
        /// <summary>
        /// Checks if header is ok (starts with a capital letter,
        /// consists of only letters or only intigers). May have comma 
        /// at the end.
        /// </summary>
        /// <returns>True if the header is ok, otherwise false.</returns>
        public bool IsHeaderOk()
        {
            if (int.TryParse(Text[0].ToString(), out _))  // when the string is a number
            {
                return CheckIfNumberOk(Text);
            }
            if (Text[0] >= 'A' && Text[0] <= 'Z')  // when the string is a word with first capital letter
            {
                return IsWordOk();
            }
            return false;  // if not number and word with capital letter then false
        }

        /// <summary>
        /// Checks if the sentence ending word is ok (ends with dot, exclamation mark or question mark).
        /// </summary>
        /// <returns>True if the ending word is ok, otherwise false.</returns>
        public bool IsEndOk()
        {
            if (Text[^1] == '.' || Text[^1] == '!' || Text[^1] == '?')  // when the last character is . or ! or ? the end is ok
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks if the word is ok (has only letters or only numbers)
        /// word is ok when comma is at the end.
        /// </summary>
        /// <returns>True it word is ok, otherwise false.</returns>
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

        /// <summary>
        /// Checks if a word consists of only letters
        /// word with comma at the end is ok.
        /// </summary>
        /// <param name="word">Word to check.</param>
        /// <returns>True if word is ok, otherwise false.</returns>
        private static bool CheckIfWordOk(string word)
        {
            int okCounter = 0;
            for (int i = 0; i < word.Length; i++)
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

        /// <summary>
        /// Checks if a word consists of only intigers
        /// word with comma at the end is ok.
        /// </summary>
        /// <param name="word">Word to check.</param>
        /// <returns>True if word is ok, otherwise false.</returns>
        private static bool CheckIfNumberOk(string word)
        {
            int okCounter = 0;
            for (int i = 0; i < word.Length; i++)
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
