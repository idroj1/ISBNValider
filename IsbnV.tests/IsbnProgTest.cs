using NUnit.Framework;

namespace IsbnV.tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
/*
        [Test]
        public void TestISBN10()
        {
            string isbn = IsbnProg.Validator("0-7167-0344-0");
            Assert.IsFalse(IsbnProg.Validator(0, TypeOf(isbn)));
        }

        [Test]
        public void TestISBN13()
        {
            string isbn = IsbnProg.Validator("978-0-7167-0344-0");
            Assert.That(false, Is.EqualTo(isbn));
        }

        [Test]
        public void TestISBNnull()
        {
            Assert.That(() => IsbnProg.Validator(null), Throws.ArgumentNullException);
        }
*/
        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}