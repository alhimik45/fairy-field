using FluentAssertions;
using NUnit.Framework;

namespace FairyField.UnitTests
{
    [TestFixture]
    public class GameStateTests
    {
        [Test]
        public void GameState_AfterCreating_HasZeroScore()
        {
            var state = new GameState(new Word("a"));
            state.Scores.Should().Be(0);
        }
    }
}