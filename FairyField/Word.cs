﻿using System;
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

            this.word = word.ToLower();
            closedLetters = word.Select(_ => true).ToList();
        }

        public bool Open(char openedLetter)
        {
            openedLetter = char.ToLower(openedLetter);
            var i = 0;
            var rightLetter = false;
            foreach (var letter in word)
            {
                if (openedLetter == letter)
                {
                    if (closedLetters[i])
                    {
                        rightLetter = true;
                        closedLetters[i] = false;
                    }
                }

                ++i;
            }

            return rightLetter;
        }

        public bool Open(int letterIndex)
        {
            if (letterIndex >= word.Length || letterIndex < 0)
            {
                return false;
            }

            return Open(word[letterIndex]);
        }
    }
}