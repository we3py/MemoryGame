using System;
using System.Linq;


namespace MemoryGame
{
    public class Board
    {
        public BoardLook boardLook = new BoardLook();
        const int ColGap = 10;
        const int RowGap = 5;
        public void DrawBoard(Difficulty difficulty)
        {
            var slogansBoard = difficulty.GetSlogans();
            var markers = difficulty.GetMarkers();
            var longestSlogan = LongestSlogan(difficulty.GameFile.WordsArray());
            var bufferHeight = slogansBoard.GetLength(0) * (ColGap + longestSlogan);
            SetBufferSize(bufferHeight, Console.BufferHeight);
            

            for (int i = 0; i < slogansBoard.GetLength(1); i++)
            {
                SetRowSign(i + 1);
                Console.WriteLine((BoardLook.Rows)i);

                for (int j = 0; j < slogansBoard.GetLength(0); j++)
                {
                    SetCursorCol(longestSlogan, j + 1);
                    Console.WriteLine(j + 1);

                    if (markers[j, 0])
                    {
                        SetRowSign(5);
                        SetCursorSlogan(slogansBoard[j, 0], longestSlogan, j + 1, 1);
                        Console.WriteLine(slogansBoard[j, 0]);
                    }
                }
                
                
            }

            

        }

        // Sets cursor posistion to write column signs depending on the longest word in array which player need to guess
        private void SetCursorCol(string[,] slogansBoard, int col)
        {
            int wordLength = LongestSlogan(slogansBoard);
            int x = ColGap * col + wordLength / 2 * col;
           
            Console.SetCursorPosition(0, 0);
            Console.SetCursorPosition(x, 0);
            
        }

        // Sets cursor position to write column signs depending on given length 
        private void SetCursorCol(int length, int col)
        {
            int x = ColGap * col + length / 2 * col;

            Console.SetCursorPosition(0, 0);
            Console.SetCursorPosition(x, 0);

        }

        // Sets cursor posistion to write row signs
        private void SetRowSign(int row)
        {
            int y = RowGap * row;
            Console.SetCursorPosition(0, y);
        }

        // Sets cursor position to write slogans in correct spot
        private void SetCursorSlogan(string slogan, int length, int col, int row)
        {
            SetCursorCol(length, col);
            int x = Console.CursorLeft - slogan.Length / 2;
            SetRowSign(row);
            Console.SetCursorPosition(x, Console.CursorTop);
            
        }

        private void SetBufferSize(int height, int width)
        {
            Console.BufferHeight = height;
            Console.BufferWidth = width;
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
