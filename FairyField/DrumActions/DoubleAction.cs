using System.IO;

namespace FairyField.DrumActions
{
    public class DoubleAction : IDrumAction
    {
        private readonly TextWriter output;

        public DoubleAction(TextWriter output)
        {
            this.output = output;
        }

        public void Act(GameState gameState)
        {
            output.WriteLine("Вы удваиваете свои очки!");
            gameState.Scores *= 2;
        }

        public override string ToString()
        {
            return "Удвоение очков!";
        }
    }
}