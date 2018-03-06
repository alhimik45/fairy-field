using System;
using System.Collections.Generic;
using System.Linq;

namespace FairyField
{
    public class Word
    {
        private readonly string word;
        private readonly IList<bool> closedLetters;

        public bool HaveClosedLetters => closedLetters.Any(x => x);

        public string View => string.Join("", word
            .Zip(Enumerable.Range(0, word.Length), (c, i) => new {c, i})
            .Select(ci => closedLetters[ci.i] ? '*' : ci.c));

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

            this.word = word;
            closedLetters = word.Select(_ => true).ToList();
        }

        public void Open(char openedLetter)
        {
            var i = 0;
            foreach (var letter in word)
            {
                if (openedLetter == letter)
                {
                    closedLetters[i] = false;
                }

                ++i;
            }
        }
    }
}