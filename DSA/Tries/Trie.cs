using System;
namespace DSA.Tries
{
	/// <summary>
	/// 
	/// </summary>
	public class TrieNode
	{
		protected Dictionary<char, TrieNode> Children { get; set; }

		public bool IsEndOfWord { get; set; }

		public TrieNode()
		{
			Children = new Dictionary<char, TrieNode>();
			IsEndOfWord = false;
		}

		public bool ContainsChild(char c)
		{
			return Children.ContainsKey(c);
		}

		public void AddChild(char c)
		{
			Children[c] = new TrieNode();
		}

		public TrieNode GetChild(char c)
		{
			return Children[c];
		}
	}

    /// <summary>
    /// Type of k-ary search tree, a tree data structure used for locating specific keys from within a set.
    /// </summary>
    public class Trie
	{
		public TrieNode Root { get; }

		public Trie()
		{
			Root = new TrieNode();
		}

		/// <summary>
		/// Inserts the word into the <c>Trie</c>
		/// </summary>
		/// <param name="word">The word to insert into the <cref>Trie</cref></param>
		public void Insert(string word)
		{
			var cur = Root;

			foreach(var c in word)
			{
				if(!cur.ContainsChild(c))
				{
					cur.AddChild(c);
				}

				cur = cur.GetChild(c);
			}

			cur.IsEndOfWord = true;
		}

		public bool Search(string word)
		{
			var cur = Root;

			foreach(var c in word)
			{
				if (!cur.ContainsChild(c)) return false;

				cur = cur.GetChild(c);
			}

			return cur.IsEndOfWord;
		}

		public bool StartsWith(string prefix)
		{
			var cur = Root;

			foreach(var c in prefix)
			{
				if (!cur.ContainsChild(c)) return false;

				cur = cur.GetChild(c);
			}

			return true;
		}
	}
}

