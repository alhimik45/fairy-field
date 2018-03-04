using System;

namespace FairyField
{
    public class Word
    {
        public bool HaveClosedLetters { get; set; }

        public Word(string word)
        {
            if (string.IsNullOrEmpty(word))
            {
                throw new ArgumentException("null or empty", nameof(word));
            }

            if (word.Contains(" "))
            {
                throw new ArgumentException("cannot contain spaces", nameof(word));
            }

            HaveClosedLetters = true;
        }
        
        public void Open(char c)
        {
            HaveClosedLetters = false;
        }
    }
}