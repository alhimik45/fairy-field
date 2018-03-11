using System.IO;
using FairyField.DrumActions;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace FairyField.UnitTests.DrumActions
{
    [TestFixture]
    public class BankruptTests
    {
        [Test]
        public void BankruptAction_SetsScoresToZero()
        {
            var state = new GameState(new Word("a")) {Scores = 42};
            var bankruptAction = new BankruptAction(Substitute.For<TextWriter>());
            bankruptAction.Act(state);
            state.Scores.Should().Be(0);
        }
    }
}