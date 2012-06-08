using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Mike.Trie
{
    public class WordLoader
    {
        public static IEnumerable<string> LoadWords()
        {
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Words.txt");
            using(var reader = new StreamReader(path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                    yield return line;
            }
        }
    }
}