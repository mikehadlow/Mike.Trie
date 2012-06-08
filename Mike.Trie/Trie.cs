using System.Linq;
using System.Collections.Generic;

namespace Mike.Trie
{
    public class Trie
    {
        private readonly TrieNode rootNode = new TrieNode((char)0);

        public TrieNode RootNode
        {
            get { return rootNode; }
        }

        public void Add(string value)
        {
            rootNode.Add(value);
        }

        public IEnumerable<string> Find(string value)
        {
            return rootNode.Find(value).Select(characterList => new string(characterList.Skip(1).ToArray()));
        }

        public IEnumerable<string> All()
        {
            return rootNode.All().Select(characterList => new string(characterList.Skip(1).ToArray()));
        }
    }
}