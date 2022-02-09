using System;
using System.IO;

namespace MemoryGame
{
    public class TxtReader
    {
        private static string _path;
        private string _currentDirectory;
        private DirectoryInfo _directoryInfo;       
        private readonly string[] _allWordsTab;

        public static string GetPath { get => _path; }

        public TxtReader(string input)
        {            
            _path = GetCurrentDir(input);
            _allWordsTab = File.ReadAllLines(_path);
        }

        public string[] WordsArray()
        {
            return _allWordsTab;
        }

        public string GetCurrentDir(string fileName)
        {
            _currentDirectory = Environment.CurrentDirectory;
            _directoryInfo = new DirectoryInfo(Path.GetFullPath(Path.Combine(_currentDirectory, @"..\..\files\" + fileName)));
            return _directoryInfo.ToString();
        }       
    }
   
}
