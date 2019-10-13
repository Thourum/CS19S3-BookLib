using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookLib;
using System;

namespace LibUnitTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void CreateBook()
        {
            var book = new Book("Book Name", "Author", 240, "1234567891011");
            Assert.IsNotNull(book);
            Assert.AreEqual(book.Title, "Book Name");
            Assert.AreEqual(book.Author, "Author");
            Assert.AreEqual(book.Page, 240);
            Assert.AreEqual(book.ISBN13.Length, 13);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateBookWithMoreThen1000Pages()
        {
            var book = new Book("Book Name", "Author", 1240, "1234567891011");
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateBookWithLessThan10Pages()
        {
            var book = new Book("Book Name", "Author", 4, "1234567891011");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateBookNoTitle()
        {
            var book = new Book("", "Author", 240, "1234567891011");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateBookNullName()
        {
            var book = new Book(null, "Author", 240, "1234567891011");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateBookWithISBNShorterThen13()
        {
            var book = new Book("Book Name", "Author", 240, "123456789011");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateBookWithISBNLongerThen13()
        {
            var book = new Book("Book Name", "Author", 240, "123456789011111");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateBookWithNullISBN()
        {
            var book = new Book("Book Name", "Author", 240, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateBookWithNullAuthor()
        {
            var book = new Book("Book Name", null, 240, "1234567891011");
        }
    }
}
