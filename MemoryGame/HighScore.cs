using System;
using System.IO;

namespace MemoryGame
{
    public class HighScore
    {
        private int _totalAttempts;
        private string _name;
        private int _lifePoints;
        private DateTime _time;
        private int _difficultyType;
        private TxtReader _reader;
        public int DifficultyType { get => _difficultyType; }
        public int LifePoints { get => _lifePoints; set => _lifePoints = value; }
        public string Name { get => _name; set => _name = value; }
        public int TotalAttempts { get => _totalAttempts; set => _totalAttempts = value; }

        public HighScore(Difficulty difficulty, string fileName)
        {
            _reader = new TxtReader(fileName);
            _time = DateTime.Now;
            _difficultyType = difficulty.GetDifficultyType;

            if (_difficultyType == 0)
            {
                _lifePoints = 10;
            }
            else if (_difficultyType == 1)
            {
                _lifePoints = 15;
            }
        }

        public int GetGameTime()
        {
            return (int)(DateTime.Now - _time).TotalSeconds;
        }

        public string finalScore(int time)
        {
            string finalScore = _name + " | " + _time + " | " + time + " seconds | " + _totalAttempts + " attempts | ";
            return finalScore;
        }

        public void SaveScoreToFile(string score)
        {
            string highscoreDir = _reader.GetCurrentDir(@"Highscore.txt");
            File.AppendAllText(highscoreDir, score + "\n");
        }

        public void LoadHighScore()
        {
            string highscoreDir = _reader.GetCurrentDir(@"Highscore.txt");
            var highScore = File.ReadAllLines(highscoreDir);
            int i = 0;
            while (i == 10 || i < highScore.Length)
            {
                Console.WriteLine(highScore[i]);
                i++;
            }
        }
       
        public void ClearHighscore()
        {
            string highscoreDir = _reader.GetCurrentDir(@"Highscore.txt");
            File.WriteAllText(highscoreDir, "");
        }


    }
}
