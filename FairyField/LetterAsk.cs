using System.IO;

namespace FairyField
{
    public class LetterAsk : ILetterAsk
    {
        private readonly GameState gameState;
        private readonly TextReader input;
        private readonly TextWriter output;

        public LetterAsk(GameState gameState, TextReader input, TextWriter output)
        {
            this.gameState = gameState;
            this.input = input;
            this.output = output;
        }

        public bool Ask()
        {
            var s = "";
            while (s.Length == 0)
            {
                output.WriteLine("Ваша буква?");
                s = input.ReadLine();
            }

            var letter = s[0];
            var result = gameState.CurrentWord.Open(letter);
            output.WriteLine(result ? "Есть такая буква!" : "Уууу :(");
            return result;
        }
    }
}