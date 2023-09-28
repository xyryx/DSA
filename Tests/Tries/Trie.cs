using System;
using DSA.Tries;

namespace Tests.Tries
{
    public class TrieTests
	{
        readonly Trie trie;

		public TrieTests()
		{
			trie = new Trie();
		}

        [Theory]
		[InlineData("apple")]
		[InlineData("banana")]
		[InlineData("bat")]
		public void InsertWord(string word)
		{
			trie.Insert(word);
            Assert.True(trie.Search(word));
        }

		[Fact]
		public void StartsWith()
		{
			trie.Insert("apple");
			Assert.True(trie.StartsWith("app"));

            trie.Insert("banana");
            Assert.True(trie.StartsWith("ban"));

			Assert.False(trie.StartsWith("band"));
			Assert.False(trie.StartsWith("applet"));
        }
	}
}

