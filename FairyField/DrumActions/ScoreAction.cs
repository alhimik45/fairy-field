using System.IO;

namespace FairyField.DrumActions
{
    public class ScoreAction : IDrumAction
    {
        private readonly int scores;
        private readonly ILetterAsk letterAsk;
        private readonly TextWriter output;

        public ScoreAction(int scores, ILetterAsk letterAsk, TextWriter output)
        {
            this.scores = scores;
            this.letterAsk = letterAsk;
            this.output = output;
        }

        public void Act(GameState gameState)
        {
            if (letterAsk.Ask())
            {
                gameState.Scores += scores;
                output.WriteLine($"Вы получаете {scores} очков");
            }
        }
    }
}