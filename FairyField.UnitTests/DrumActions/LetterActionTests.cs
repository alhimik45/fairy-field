using System.IO;
using FairyField.DrumActions;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace FairyField.UnitTests.DrumActions
{
    [TestFixture]
    public class LetterActionTests
    {
        [Test]
        public void LetterAction_OpensLetter()
        {
            var state = new GameState(new Word("a"));
            var input = Substitute.For<TextReader>();
            input.ReadLine().Returns("1");
            var letterAction = new LetterAction(input, Substitute.For<TextWriter>());
            letterAction.Act(state);
            state.CurrentWord.View.Should().Be("a");
        }

        [Test]
        public void LetterAction_WaitsCorrectLetterIndex()
        {
            var state = new GameState(new Word("a"));
            var input = Substitute.For<TextReader>();
            input.ReadLine().Returns("0", "-13", "445", "sdsd", "1");
            var letterAction = new LetterAction(input, Substitute.For<TextWriter>());
            letterAction.Act(state);
            state.CurrentWord.View.Should().Be("a");
            input.Received(5).ReadLine();
        }
    }
}