﻿using System;
using Task1;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var temp = new Book("one", "One");
            var first = new Book("Роулинг Джоанн", "Гарри Поттер и философский камень", "Фантастика", "РОСМЭН-Издат",
                300);
            var seventh = new Book("J.K.Rouling", "Harry Potter and the deathly Hallows");
            var bookList = new BookListService();
            bookList.AddBook(first);
            bookList.AddBook(seventh);
            bookList.AddBook(temp);
            try { bookList.AddBook(null); } catch (ArgumentNullException) { }
            try { bookList.AddBook(new Book("one", "One")); } catch (ArgumentException) { }
            try { bookList.RemoveBook(null); } catch (ArgumentNullException) { }
            try { bookList.RemoveBook(new Book("two", "Two")); } catch (ArgumentException) { }
            Console.WriteLine("BookListService");
            var brw = new BinaryReaderWriter("books_new.bin");
            bookList.SaveBooks(brw);
            bookList.PrintBooks();
            Console.WriteLine();
            bookList.SortBooksByAuthor();
            bookList.PrintBooks();
            Console.WriteLine();
            bookList.SortBooksByTitle();
            bookList.PrintBooks();
            Console.WriteLine();
            var newList = new BookListService();
            newList.LoadBooks(brw);
            newList.PrintBooks();
            Console.ReadLine();
        }
    }
}
