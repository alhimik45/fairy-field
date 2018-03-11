using System.IO;
using FairyField.DrumActions;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace FairyField.UnitTests.DrumActions
{
    [TestFixture]
    public class DoubleActionTests
    {
        [Test]
        public void DoubleActionAction_DoublesScores()
        {
            var state = new GameState(new Word("a")) {Scores = 42};
            var doubleAction = new DoubleAction(Substitute.For<TextWriter>());
            doubleAction.Act(state);
            state.Scores.Should().Be(84);
        }
    }
}