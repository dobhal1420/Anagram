using Anagram.Service;
using NUnit.Framework;
using System.IO;

namespace AnagramTest
{
    public class AnagramTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void shouldReturnFalseIfWordLengthisLessThan2()
        {
            var wordsProcessor = new WordProcessor("Best-Secret@#$%", 2);

            bool isProcessed = wordsProcessor.ProcessWord("Be");

            Assert.IsFalse(isProcessed);
        }

        [Test]
        public void ShouldReturnFalseAsCannotBeAnagram()
        {
            var wordsProcessor = new WordProcessor("Best-Secret@#$%",2);
            
            bool isProcessed = wordsProcessor.ProcessWord("beetl");

            Assert.IsFalse(isProcessed);
        }

        [Test]
        public void ShouldReturnTrueAsItisPotentialAnagram()
        {
            var wordsProcessor = new WordProcessor("Best-Secret@#$%", 2);

            bool isProcessed = wordsProcessor.ProcessWord("beet");

            Assert.IsTrue(isProcessed);
        }

        [Test]
        public void ShouldReturnFalseAsOnly2UnmatchedCharactersPresent()
        {
            var wordsProcessor = new WordProcessor("Best-Secret@#$%", 2);

            bool isProcessed = wordsProcessor.ProcessWord("bestsecr");

            Assert.IsFalse(isProcessed);
        }


        [Test]
        public void ShouldGetOneMatchingAnagram()
        {
            var wordsProcessor = new WordProcessor("Best-Secret@#$%", 2);

            wordsProcessor.ProcessWord("bet");
            wordsProcessor.ProcessWord("erst");
            wordsProcessor.ProcessWord("sec");

            var allAnagrams = wordsProcessor.GetAllAnagrams();

            Assert.That(allAnagrams[0], Is.EqualTo("bet erst sec"));
        }

        [Test]
        public void ShouldHave2AnagramsWord()
        {
            var wordsProcessor = new WordProcessor("Best-Secret@#$%", 2);

            wordsProcessor.ProcessWord("best");
            wordsProcessor.ProcessWord("erects");
            wordsProcessor.ProcessWord("secret");

            var allAnagrams = wordsProcessor.GetAllAnagrams();

            Assert.That(allAnagrams[0], Is.EqualTo("best erects"));
            Assert.That(allAnagrams[1], Is.EqualTo("best secret"));
 

        }

        [Test]
        public void ShouldHave3AnagramsWord()
        {
            var wordsProcessor = new WordProcessor("Best-Secret@#$%", 2);
            wordsProcessor.ProcessWord("beet");
            wordsProcessor.ProcessWord("best");
            wordsProcessor.ProcessWord("crest");
            wordsProcessor.ProcessWord("crests");
            wordsProcessor.ProcessWord("erects");
            wordsProcessor.ProcessWord("secret");


            var allAnagrams = wordsProcessor.GetAllAnagrams();

            Assert.That(allAnagrams[0], Is.EqualTo("beet crests"));
            Assert.That(allAnagrams[1], Is.EqualTo("best erects"));
            Assert.That(allAnagrams[2], Is.EqualTo("best secret"));

        }


        [Test]
        public void ShouldHaveAllAnagramsWord()
        {
            var wordsProcessor = new WordProcessor("Best-Secret@#$%", 2);

            wordsProcessor.ProcessWord("beet");
            wordsProcessor.ProcessWord("beets");
            wordsProcessor.ProcessWord("beret");
            wordsProcessor.ProcessWord("berets");
            wordsProcessor.ProcessWord("beset");
            wordsProcessor.ProcessWord("best");
            wordsProcessor.ProcessWord("bests");
            wordsProcessor.ProcessWord("bet");
            wordsProcessor.ProcessWord("bets");
            wordsProcessor.ProcessWord("better");
            wordsProcessor.ProcessWord("betters");
            wordsProcessor.ProcessWord("cess");
            wordsProcessor.ProcessWord("crest");
            wordsProcessor.ProcessWord("crests");
            wordsProcessor.ProcessWord("crete");
            wordsProcessor.ProcessWord("erect");
            wordsProcessor.ProcessWord("erects");
            wordsProcessor.ProcessWord("erst");
            wordsProcessor.ProcessWord("rest");
            wordsProcessor.ProcessWord("sec");
            wordsProcessor.ProcessWord("secret");
            wordsProcessor.ProcessWord("secrets");
            wordsProcessor.ProcessWord("sect");
            wordsProcessor.ProcessWord("sects");

            var allAnagrams = wordsProcessor.GetAllAnagrams();

        }
    }
}