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
        private ILetterAsk letterAsk;
        private TextWriter output;
        private GameState state;
        private ScoreAction scoreAction;

        [SetUp]
        public void SetUp()
        {
            state = new GameState(new Word("a"));
            letterAsk = Substitute.For<ILetterAsk>();
            output = Substitute.For<TextWriter>();
            scoreAction = new ScoreAction(10, letterAsk, output);
        }

        [Test]
        public void ScoreAction_AddScoreInState_IfLetterGuessedRight()
        {
            letterAsk.Ask().Returns(true);
            scoreAction.Act(state);
            letterAsk.Received().Ask();
            output.Received().WriteLine(Arg.Any<string>());
            state.Scores.Should().Be(10);
        }

        [Test]
        public void ScoreAction_NotAddScoreInState_IfLetterGuessedWrong()
        {
            letterAsk.Ask().Returns(false);
            scoreAction.Act(state);
            letterAsk.Received().Ask();
            state.Scores.Should().Be(0);
        }
    }
}