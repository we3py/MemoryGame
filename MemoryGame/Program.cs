using System;
using System.Text.RegularExpressions;

namespace MemoryGame
{
    public class Program
    {
        
        static void Main(string[] args)
        {
            Regex regexCommand = new Regex("^[0-3]");
            Regex difficultyRegex = new Regex("^[0-1]");
            bool isPlaying = true;
            Game newGame = new Game(0);

            while (isPlaying)
            {
                Console.WriteLine(BoardLook.GetLogo());
                Console.WriteLine(BoardLook.GetDescription());
                Console.WriteLine(BoardLook.GetMenu());
                

                string command = Console.ReadLine().Trim();
                if (!regexCommand.IsMatch(command) || String.IsNullOrEmpty(command) || command.Length > 1)
                {
                    Console.Clear();
                    continue;
                }


                switch (Int32.Parse(command))
                {
                    case 0:

                        Console.Clear();
                        Console.WriteLine(BoardLook.GetDifficultyQuestion());
                        string level = Console.ReadLine();
                        Console.Clear();

                        while (true)
                        {    
                            if (!difficultyRegex.IsMatch(level) || String.IsNullOrEmpty(level) || level.Length > 1)
                            {
                                Console.WriteLine("Choose level");
                                level = Console.ReadLine();
                                Console.Clear();                               
                                continue;
                            } else
                                break;
                        }
                        

                        newGame = new Game(Int32.Parse(level));
                        Console.Clear();
                        newGame.Run();
                        Console.WriteLine("If u want start a new game, press ENTER");
                        Console.ReadLine();
                        Console.Clear();
                        continue;
                    case 1:
                        Console.Clear();
                        newGame.Highscore.LoadHighScore();
                        Console.WriteLine("Press ENTER to back");
                        Console.ReadLine();
                        Console.Clear();
                        continue; 
                    case 2:
                        Console.Clear();
                        newGame.Highscore.ClearHighscore();
                        Console.WriteLine("Highscore cleared");
                        Console.WriteLine("Press ENTER to back");
                        Console.ReadLine();
                        Console.Clear();
                        continue;
                    case 3:
                        isPlaying = false;
                        break;                                             
                }

                break;               
            }








        
        
           
            
            
            



        }
        

    }
}
