using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Runtime.Serialization;
using NLog;

namespace Task1
{
    public class BookListService
    {
        #region Private fields
    
        private List<Book> books;
        private LogAdapter logger;

        #endregion

        #region Ctor

        public BookListService()
        {
            books = new List<Book>();
            logger = new LogAdapter(new NLogger());
            logger.Initialize();
        }
        #endregion

        #region Properties

        public Book this[int index]
        {
            get
            {
                if (index < 0 || index > books.Count)
                    throw new ArgumentException();
                return books[index];
            }
        }
        #endregion

        #region Public methods

        public void LoadBooks(IBookSerializable bs)
        {
            try
            {
                books = (List<Book>) bs.Read();
            }
            catch (SerializationException e)
            {
                logger.Error("Can't load books." + e.Message);
                throw;
            }
        }

        public void SaveBooks(IBookSerializable bs)
        {
            try
            {
                bs.Write(books);
            }
            catch (SerializationException e)
            {
                logger.Error("Can't save books." + e.Message);
                throw;
            }
            
        }

        public void AddBook(Book book)
        {
            if (book == null)
            {
                logger.Warn("Can't add book. Null argument.");
                throw new ArgumentNullException();
            }
            if (books.Contains(book))
            {
                logger.Warn("Can't add book. Book is already exist.");
                throw new ArgumentException();
            }
            books.Add(book);
            logger.Info("Book added.");
        }

        public void RemoveBook(Book book)
        {
            if (book == null)
            {
                logger.Warn("Can't remmove book. Null argument.");
                throw new ArgumentNullException();
            }
            if (!books.Contains(book))
            {
                logger.Warn("Can't remove book. Book doesn't exist.");
                throw new ArgumentException();
            }
            books.Remove(book);
            logger.Info("Book removed");
        }

        public List<Book> FindByAuthor(string author)
        {
            List<Book> result = new List<Book>();
            foreach (var book in books)
            {
                if (string.Equals(book.Author, author, StringComparison.InvariantCultureIgnoreCase))
                    result.Add(book);
            }
            logger.Info( String.Format("Found {0} book(s)", result.Count));
            return result;
        }

        public Book FindByTitle(string title)
        {
            Book result = books.First(x => string.Equals(x.Title, title, StringComparison.InvariantCultureIgnoreCase));
            if (ReferenceEquals(result, null))
                logger.Info("Book wasn't found");
            else
                logger.Info("Book found");
            return result;
        }

        public void SortBooksByTitle()
        {
            books.Sort((first, second) => string.Compare(first.Title, second.Title, StringComparison.InvariantCultureIgnoreCase));
        }

        public void SortBooksByAuthor()
        {
            books.Sort((first, second) => string.Compare(first.Author, second.Author, StringComparison.InvariantCultureIgnoreCase));
        }

        public void PrintBooks()
        {
            foreach (var book in books)
            {
                Console.WriteLine(book.ToString());
            }
        }
        #endregion
    }
}
