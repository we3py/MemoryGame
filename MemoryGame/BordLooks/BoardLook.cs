namespace MemoryGame
{
    public class BoardLook
    {
        private Difficulty _difficulty;
        private string _gameField = @"<<| ╬ |>>";
        public string GameField { get => _gameField; }
        public Difficulty GetDifficulty { get => _difficulty; }

        public BoardLook(Difficulty difficulty)
        {
            _difficulty = difficulty;
        }

        public int CellWidth()
        {
            return LongestSlogan(GetDifficulty.GameFile.WordsArray());
        }

        public int CellHeight()
        {
            return 0;
        }

        public string PrintSlogan(string [,] slogans, int indexOne, int indexTwo)
        {
            string toPrint = "<< " + slogans[indexOne, indexTwo] + " >>"; 
            return toPrint;
        }

        private int LongestSlogan(string[] slogansFile)
        {
            int max = slogansFile[0].Length;
            for (int i = 0; i < slogansFile.Length; i++)
            {
                if (slogansFile[i].Length > max)
                {
                    max = slogansFile[i].Length;
                }
            }

            return max;
        }
        public enum Rows
        {
            A = 0,
            B = 1
        }

        public static string GetLogo()
        {
            return @"                                            
                                            ___                     
  /\/\   ___ _ __ ___   ___  _ __ _   _    / _ \__ _ _ __ ___   ___ 
 /    \ / _ \ '_ ` _ \ / _ \| '__| | | |  / /_\/ _` | '_ ` _ \ / _ \
/ /\/\ \  __/ | | | | | (_) | |  | |_| | / /_\\ (_| | | | | | |  __/
\/    \/\___|_| |_| |_|\___/|_|   \__, | \____/\__,_|_| |_| |_|\___|
                                  |___/                             ";
        }

        public static string GetDescription()
        {
            return @"
Welcome to Memory Game. This is a simple game about founding pair of 
the same words. By typing the coordinates (e.g. |A1| or |B4|). On the
beginning you can choose between two difficulties: EASY and HARD.
EASY: 4 pairs of words, 10 chances
HARD: 8 pairs of words, 15 chances

GOOD LUCK BUDDY!";



        }

        public static string GetMenu()
        {
            return @"
+-+-+-+-+ +-+-+-+-+-+-+ +-+ +-+-+ +-+-+-+-+
|T|Y|P|E| |N|U|M|B|E|R| |0| |t|o| |P|L|A|Y|
+-+-+-+-+ +-+-+-+-+-+-+ +-+ +-+-+ +-+-+-+-+

+-+-+-+-+ +-+-+-+-+-+-+ +-+ +-+-+ +-+-+-+-+ +-+-+-+-+-+-+-+-+-+
|T|Y|P|E| |N|U|M|B|E|R| |1| |t|o| |O|P|E|N| |H|I|G|H|S|C|O|R|E|
+-+-+-+-+ +-+-+-+-+-+-+ +-+ +-+-+ +-+-+-+-+ +-+-+-+-+-+-+-+-+-+

+-+-+-+-+ +-+-+-+-+-+-+ +-+ +-+-+ +-+-+-+-+-+ +-+-+-+-+-+-+-+-+-+
|T|Y|P|E| |N|U|M|B|E|R| |2| |t|o| |C|L|E|A|R| |H|I|G|H|S|C|O|R|E|
+-+-+-+-+ +-+-+-+-+-+-+ +-+ +-+-+ +-+-+-+-+-+ +-+-+-+-+-+-+-+-+-+

+-+-+-+-+ +-+-+-+-+-+-+ +-+ +-+-+ +-+-+-+-+
|T|Y|P|E| |N|U|M|B|E|R| |3| |t|o| |E|X|I|T|
+-+-+-+-+ +-+-+-+-+-+-+ +-+ +-+-+ +-+-+-+-+
";
        }

        public static string GetDifficultyQuestion()
        {
            return @"
+-+-+-+-+-+-+ +-+-+-+-+-+-+-+-+-+-+
|C|H|O|O|S|E| |D|I|F|F|I|C|U|L|T|Y| 
+-+-+-+-+-+-+ +-+-+-+-+-+-+-+-+-+-+

0 - EASY
1 - HARD";

        }
    }
}
