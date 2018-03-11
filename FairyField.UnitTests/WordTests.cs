using System;
using FluentAssertions;
using NUnit.Framework;

namespace FairyField.UnitTests
{
    [TestFixture]
    public class WordTests
    {
        [Test]
        public void Word_AfterCreating_HasClosedLetters()
        {
            var word = new Word("asd");
            word.HaveClosedLetters.Should().BeTrue();
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        [TestCase("asd fgh")]
        public void CreateWord_ThrowArgumentException_IfWordIsNotSingleNotEmpty(string word)
        {
            Action act = () => new Word(word);
            act.Should().Throw<ArgumentException>();
        }

        [TestCase("a", "a")]
        [TestCase("aa", "a")]
        [TestCase("ab", "ba")]
        public void Word_OpenAllLetters_NotHasClosedLetters(string w, string letters)
        {
            var word = new Word(w);
            foreach (var letter in letters)
            {
                word.HaveClosedLetters.Should().BeTrue();
                word.Open(letter);
            }

            word.HaveClosedLetters.Should().BeFalse();
        }

        [TestCase("hello", "l", "**ll*")]
        [TestCase("hellofdg", "", "********")]
        [TestCase("hello", "loh", "h*llo")]
        [TestCase("hello", "lohe", "hello")]
        [TestCase("hello", "dlasohe", "hello")]
        public void Word_ReturnsViewWithStarsInsteadCLosedLetters(string w, string letters, string output)
        {
            var word = new Word(w);
            foreach (var letter in letters)
            {
                word.Open(letter);
            }

            word.View.Should().Be(output);
        }
        
        [TestCase("hello", 'l', true)]
        [TestCase("hello", 'h', true)]
        [TestCase("hello", 'a', false)]
        [TestCase("hi", 'l', false)]
        public void Word_OpenReturnsTrue_IfLetterPresentInWord(string w, char letter, bool result)
        {
            var word = new Word(w);
            word.Open(letter).Should().Be(result);
        }
    }
}