using System.IO;

namespace FairyField.DrumActions
{
    public class BankruptAction : IDrumAction
    {
        private readonly TextWriter output;

        public BankruptAction(TextWriter output)
        {
            this.output = output;
        }

        public void Act(GameState gameState)
        {
            output.WriteLine("Вы теряете все свои очки!");
            gameState.Scores = 0;
        }

        public override string ToString()
        {
            return "Банкрот!";
        }
    }
}