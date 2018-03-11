using System;
using System.IO;
using FairyField.DrumActions;

namespace FairyField
{
    public class Drum
    {
        private readonly Random random = new Random();
        private readonly WeightedChooser<IDrumAction> chooser;

        public Drum(ILetterAsk letterAsk, TextReader input, TextWriter output)
        {
            chooser = new WeightedChooser<IDrumAction>(new (IDrumAction, int)[]
            {
                (new BankruptAction(output), 1),
                (new DoubleAction(output), 2),
                (new LetterAction(input, output), 3),
                (new PrizeAction(input, output), 4),
                (new ScoreAction(100, letterAsk, output), 4),
                (new ScoreAction(300, letterAsk, output), 3),
                (new ScoreAction(500, letterAsk, output), 2),
                (new ScoreAction(1000, letterAsk, output), 1),
                (new ScoreAction(1500, letterAsk, output), 1)
            });
        }

        public IDrumAction Roll()
        {
            return chooser.GetByOffset(random.Next(0, 10 * chooser.Max()));
        }
    }
}