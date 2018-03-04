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
    }
}