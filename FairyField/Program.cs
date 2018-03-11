using System;

namespace FairyField
{
    class Program
    {
        private static (string, string)[] words =
        {
            ("ислам", "Религия"),
            ("христианство", "Религия"),
            ("индуизм", "Религия"),
            ("барнаул", "Город"),
            ("москва", "Город"),
            ("челябинск", "Город"),
            ("новгород", "Город")
        };

        static void Main(string[] args)
        {
            var random = new Random();
            Console.WriteLine("Мы начинаем КВН!");
            var letterAsk = new LetterAsk(Console.In, Console.Out);
            var drum = new Drum(letterAsk, Console.In, Console.Out);
            while (true)
            {
                var w = words[random.Next(words.Length - 1)];
                Console.WriteLine("Игра началась!");
                Console.WriteLine("Тема этого раунда: " + w.Item2);
                Console.WriteLine();
                var state = new GameState(new Word(w.Item1));
                while (state.CurrentWord.HaveClosedLetters)
                {
                    Console.WriteLine($"Ваши очки: {state.Scores}. Текущее слово: {state.CurrentWord.View}");
                    Console.WriteLine("Вращайте барабан!");
                    Console.ReadLine();
                    var act = drum.Roll();
                    if (act != null)
                    {
                        Console.WriteLine(act);
                        Console.WriteLine();
                        act.Act(state);
                    }

                    Console.WriteLine();
                }

                Console.WriteLine("Вы выиграли!");
                Console.WriteLine("Получено очков: " + state.Scores);
                Console.WriteLine("Слово: " + state.CurrentWord.View);
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}