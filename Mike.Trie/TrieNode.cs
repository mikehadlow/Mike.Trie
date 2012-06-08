using System.Collections.Generic;
using System.Linq;

namespace Mike.Trie
{
    public class TrieNode
    {
        private readonly char character;
        private readonly List<TrieNode> childNodes = new List<TrieNode>();

        public char Character
        {
            get { return character; }
        }

        public IEnumerable<TrieNode> ChildNodes
        {
            get { return childNodes; }
        }

        public TrieNode(char character)
        {
            this.character = character;
        }

        public void Add(string value)
        {
            if (value.Length == 0) return;
            var nextChar = value[0];

            var childNode = childNodes.SingleOrDefault(x => x.Character == nextChar);
            if (childNode == null)
            {
                childNode = new TrieNode(nextChar);
                childNodes.Add(childNode);
            }
            childNode.Add(value.Substring(1));
        }

        public IEnumerable<IEnumerable<char>> All()
        {
            if(childNodes.Count == 0)
            {
                return JustMyChar();
            }

            return 
                from childNode in ChildNodes 
                from substring in childNode.All() 
                select AppendMyChar(substring);
        }

        public IEnumerable<IEnumerable<char>> Find(string value)
        {
            if (value.Length == 0) return All();

            var matchNode = childNodes.SingleOrDefault(x => x.Character == value[0]);
            if (matchNode == null) return Enumerable.Empty<IEnumerable<char>>();

            return
                from substring in matchNode.Find(value.Substring(1)) 
                select AppendMyChar(substring);
        } 

        private IEnumerable<IEnumerable<char>> JustMyChar()
        {
            yield return AppendMyChar(Enumerable.Empty<char>());
        } 

        private IEnumerable<char> AppendMyChar(IEnumerable<char> substring)
        {
            yield return character;
            foreach (var substringChar in substring)
            {
                yield return substringChar;
            }
        } 
    }
}