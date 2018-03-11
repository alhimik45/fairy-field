using System.IO;

namespace FairyField.DrumActions
{
    public class LetterAction : IDrumAction
    {
        private readonly TextReader input;
        private readonly TextWriter output;

        public LetterAction(TextReader input, TextWriter output)
        {
            this.input = input;
            this.output = output;
        }

        public void Act(GameState gameState)
        {
            var opened = false;
            int? num = null;
            while (!opened || num == null)
            {
                output.WriteLine("Скажите номер буквы");
                num = int.TryParse(input.ReadLine(), out var v) ? v : (int?) null;
                if (num != null)
                {
                    opened = gameState.CurrentWord.Open(num.Value - 1);
                }
            }
        }

        public override string ToString()
        {
            return "Открывайте любую букву!";
        }
    }
}