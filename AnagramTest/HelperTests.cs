using Anagram.Helper;
using Anagram.Service;
using NUnit.Framework;

namespace AnagramTest
{
    public class HelperTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ShouldIgnoreSpecialCharacters()
        {
            string proccessedString = StringHelper.RemoveSpecialCharacters("Best-Secret@#$%^&*()_+=|}{?/><,.`~!';:'");
            var expected = "BestSecret";

            Assert.That(proccessedString, Is.EqualTo(expected));
        }
    }
}