using System;
using System.Linq;

namespace Mike.Trie
{
    public class UnitTests
    {
        public static void LoadWordsTest()
        {
            foreach (var word in WordLoader.LoadWords())
            {
                Console.WriteLine(word);
            }
        }

        public static void TrieTest()
        {
            var trie = new Trie();

            trie.Add("abc");
            trie.Add("abd");

            Console.WriteLine(trie.RootNode.ChildNodes.First().Character);
            Console.WriteLine(trie.RootNode.ChildNodes.First().ChildNodes.First().Character);
            Console.WriteLine(trie.RootNode.ChildNodes.First().ChildNodes.First().ChildNodes.First().Character);
            Console.WriteLine(trie.RootNode.ChildNodes.First().ChildNodes.First().ChildNodes.Last().Character);
        }

        public void AllTest()
        {
            var trie = new Trie();
            trie.Add("abc");
            trie.Add("abx");
            trie.Add("afc");
            trie.Add("afx");

            foreach (var value in trie.All())
            {
                Console.WriteLine(value);
            }
        }

        public void SingleAllTest()
        {
            var node = new TrieNode('a');

            var all = node.All().First().First();

            Console.WriteLine(all);
        }

        public void FindTest()
        {
            var trie = new Trie();
            trie.Add("abc");
            trie.Add("abx");
            trie.Add("afc");
            trie.Add("afx");

            foreach (var value in trie.Find("ab"))
            {
                Console.WriteLine(value);
            }
        }
    }
}