using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Core.Trie
{
    public class Trie
    {
        private class Node
        {
            public Node[] children;
            public bool isEnd = false;
            public Node()
            {
                children = new Node[26];
                isEnd = false;
            }
        }

        private Node rootNode = null;

        public Trie()
        {
            rootNode = new Node();
        }

        public void Insert(string word)
        {
            Node currNode = rootNode;
            for (int i = 0; i < word.Length; i++)
            {
                if (currNode.children[word[i] - 'a'] == null)
                {
                    currNode.children[word[i] - 'a'] = new Node();
                }
                currNode = currNode.children[word[i] - 'a'];
            }
            currNode.isEnd = true;
        }

        public bool Search(string word)
        {
            Node currNode = rootNode;
            for (int i = 0; i < word.Length; i++)
            {
                if (currNode.children[word[i] - 'a'] == null)
                {
                    return false;
                }
                currNode = currNode.children[word[i] - 'a'];
            }
            return currNode.isEnd;
        }

        public bool StartsWith(string prefix)
        {
            Node currNode = rootNode;
            for (int i = 0; i < prefix.Length; i++)
            {
                if (currNode.children[prefix[i] - 'a'] == null)
                {
                    return false;
                }
                currNode = currNode.children[prefix[i] - 'a'];
            }
            return true;
        }

    }
}
