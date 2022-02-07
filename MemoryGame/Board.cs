using System;

namespace MemoryGame
{
    public class Board
    {
        public BoardLook boardLook = new BoardLook();
        public void drawBoard(string[,] slogansBoard)
        {
            Console.Write(" ");
            for (int i = 1; i <= slogansBoard.GetLength(0) / 2; i++)
            {
                Console.Write(i);
            }
            Console.WriteLine();
            Console.Write((BoardLook.Rows)0);
            for (int i = 0; i < slogansBoard.GetLength(0); i++)
            {
                if (slogansBoard[i,1] != "Y")
                {
                    Console.WriteLine(slogansBoard[i,0]);
                } 
            }
            Console.WriteLine();
            Console.WriteLine((BoardLook.Rows)1);



        }


    }
}
