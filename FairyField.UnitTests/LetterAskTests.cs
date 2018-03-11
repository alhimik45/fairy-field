using System.IO;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace FairyField.UnitTests
{
    [TestFixture]
    public class LetterAskTests
    {
        private TextReader input;
        private TextWriter output;
        private GameState state;

        [SetUp]
        public void SetUp()
        {
            input = Substitute.For<TextReader>();
            output = Substitute.For<TextWriter>();
            input.ReadLine().Returns("", "a");
            state = new GameState(new Word("a"));
        }

        [Test]
        public void LetterAsk_ReadsAgain_IfEmptyStringGiven()
        {
            var letterAsk = new LetterAsk(input, output);
            letterAsk.Ask(state);
            input.Received(2).ReadLine();
            output.Received().WriteLine(Arg.Any<string>());
        }

        [Test]
        public void LetterAsk_ReturnsTrue_IfWordHasLetter()
        {
            var letterAsk = new LetterAsk(input, output);
            letterAsk.Ask(state).Should().BeTrue();
        }

        [Test]
        public void LetterAsk_ReturnsFalse_IfWordHasNoLetter()
        {
            input.ReadLine().Returns("b");
            var letterAsk = new LetterAsk(input, output);
            letterAsk.Ask(state).Should().BeFalse();
        }
    }
}