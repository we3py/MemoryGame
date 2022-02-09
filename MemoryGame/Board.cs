using System;


namespace MemoryGame
{
    public class Board
    {
        const int ColGap = 12;
        const int RowGap = 5;
        private BoardLook _boardLook;
        private HighScore _highscore;
        private string[,] _array;
        private bool[,] _markers;
        
        public Board(BoardLook boardlook, HighScore highScore)
        {
            _boardLook = boardlook;
            _array = _boardLook.GetDifficulty.AssignSlogans();
            _markers = _boardLook.GetDifficulty.GetMarkers();
            _highscore = highScore;
            Console.SetWindowSize(170, 30);
        }

        public void DrawBoard(Difficulty difficulty)
        {
            var cellHeight = _boardLook.CellHeight();
            var cellWidth = _boardLook.CellWidth();
            Console.Clear();
            Console.WriteLine("Your points: " + _highscore.LifePoints);
            Console.WriteLine("Level: " + (Difficulty.difficultyType) _highscore.DifficultyType);
            Console.SetCursorPosition(0, 5);

            for (int i = 0; i < _array.GetLength(1); i++)
            {
                
                SetRowSign(i + 1);
                Console.WriteLine((BoardLook.Rows)i);

                for (int j = 0; j < _array.GetLength(0); j++)
                {
                    SetCursorCol(cellWidth, j + 1);
                    Console.WriteLine(j + 1);
                    var slogan = _boardLook.PrintSlogan(_array, j, i);


                    if (_markers[j, i])
                    {                       
                        SetCursorSlogan(slogan.Length, cellWidth, j + 1, i + 1);
                        Console.WriteLine(_boardLook.PrintSlogan(_array, j, i));
                    }
                    else
                    {
                        slogan = _boardLook.GameField;
                        SetCursorSlogan(slogan.Length, cellWidth, j + 1, i + 1);
                        Console.WriteLine(slogan);
                    }
                    
                    Console.WriteLine();

                }               
            }           
        }


        
        // Sets cursor position to write column signs depending on given length 
        private void SetCursorCol(int length, int col)
        {
            int x = ColGap * col + length / 2 * col;

            Console.SetCursorPosition(0, 0);
            Console.SetCursorPosition(x, RowGap);
        }

        
        // Sets cursor position to write slogans in correct spot
        private void SetCursorSlogan(string slogan, int length, int col, int row)
        {
            SetCursorCol(length, col);
            int x = Console.CursorLeft - slogan.Length / 2;
            SetRowSign(row);
            Console.SetCursorPosition(x, Console.CursorTop);           
        }

        // 
        private void SetCursorSlogan(int cellLength, int length, int col, int row)
        {
            SetCursorCol(length, col);
            int x = Console.CursorLeft - cellLength / 2;
            SetRowSign(row);
            Console.SetCursorPosition(x, Console.CursorTop);
        }

        // Sets cursor posistion to write row signs
        private void SetRowSign(int row)
        {
            int y = RowGap * row;
            Console.SetCursorPosition(0, y + RowGap);
        }

        private void SetWindowSize(int height, int width)
        {
            Console.WindowHeight = height;
            Console.WindowWidth = width;    
            Console.BufferHeight = height;
            Console.BufferWidth = width;
        }


        

        private int LongestSlogan(string[,] slogansBoard)
        {
            int max = slogansBoard[0, 0].Length;
            for (int i = 0; i < slogansBoard.GetLength(1); i++)
            {
                for (int j = 0; j < slogansBoard.GetLength(0); j++)
                {
                    if (slogansBoard[j, i].Length > max)
                    {
                        max = slogansBoard[j, i].Length;
                    }
                }
            }

            return max;
        }
    }
}
