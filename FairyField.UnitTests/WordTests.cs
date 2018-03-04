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

        [Test]
        public void CreateWord_ThrowArgumentException_IfWordIsNull()
        {
            Action act = () => new Word(null);
            act.Should().Throw<ArgumentException>();
        }
    }
}