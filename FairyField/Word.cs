using System;

namespace FairyField
{
    public class Word
    {
        public bool HaveClosedLetters => true;

        public Word(string word)
        {
            if(string.IsNullOrEmpty(word))
            {
                throw new ArgumentException("null or empty", nameof(word));
            }
        }
    }
}