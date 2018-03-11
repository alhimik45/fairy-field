using System.IO;
using FairyField.DrumActions;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace FairyField.UnitTests.DrumActions
{
    [TestFixture]
    public class ScoreActionTests
    {
        [Test]
        public void ScoreAction_AddScoreInState_IfLetterGuessedRight()
        {
            var state = new GameState(new Word("a"));
            var letterAsk = Substitute.For<ILetterAsk>();
            letterAsk.Ask().Returns(true);
            var output = Substitute.For<TextWriter>();
            var scoreAction = new ScoreAction(10, letterAsk, output);
            scoreAction.Act(state);
            letterAsk.Received().Ask();
            output.Received().WriteLine(Arg.Any<string>());
            state.Scores.Should().Be(10);
        }
        
        [Test]
        public void ScoreAction_NotAddScoreInState_IfLetterGuessedWrong()
        {
            var state = new GameState(new Word("a"));
            var letterAsk = Substitute.For<ILetterAsk>();
            letterAsk.Ask().Returns(false);
            var output = Substitute.For<TextWriter>();
            var scoreAction = new ScoreAction(10, letterAsk, output);
            scoreAction.Act(state);
            letterAsk.Received().Ask();
            state.Scores.Should().Be(0);
        }
    }
}