using System;

namespace FairyField
{
    public class Word
    {
        public bool HaveClosedLetters => true;

        public Word(string word)
        {
            if(word == null)
            {
                throw new ArgumentException();
            }
        }
    }
}