using System;
using System.IO;

namespace FairyField.DrumActions
{
    public class PrizeAction : IDrumAction
    {
        private readonly TextReader input;
        private readonly TextWriter output;
        private readonly Random random = new Random();

        private string[] prizes =
        {
            "грязные носки",
            "ААААААААААВТОМОБИЛЬ",
            "пожизненную подписку на мурзилку",
            "надувной шарик",
            "ключи от гаража"
        };

        public PrizeAction(TextReader input, TextWriter output)
        {
            this.input = input;
            this.output = output;
        }

        public void Act(GameState gameState)
        {
            var s = GetChoice();

            if (s == "2")
            {
                output.WriteLine("Может всё-таки приз??");
                s = GetChoice();
            }

            if (s == "2")
            {
                output.WriteLine("Таки подумайте, призом может быть автомобиль");
                s = GetChoice();
            }

            if (s == "2")
            {
                output.WriteLine("Или приз?");
                s = GetChoice();
            }

            output.WriteLine(s == "2"
                ? $"Вы получаете {random.Next(10) * 1000} рублей"
                : $"Вы получаете {prizes[random.Next(prizes.Length - 1)]}!!!");
        }

        private string GetChoice()
        {
            var s = "";
            while (s != "1" && s != "2")
            {
                output.WriteLine("ПРИЗ(1) или деньги(2)?");
                s = input.ReadLine();
            }

            return s;
        }

        public override string ToString()
        {
            return "Сектор приз!";
        }
    }
}