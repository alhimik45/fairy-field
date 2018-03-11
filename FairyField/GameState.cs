namespace FairyField
{
    public class GameState
    {
        public Word CurrentWord { get; set; }
        public int Scores { get; set; } = 0;

        public GameState(Word currentWord)
        {
            CurrentWord = currentWord;
        }
    }
}