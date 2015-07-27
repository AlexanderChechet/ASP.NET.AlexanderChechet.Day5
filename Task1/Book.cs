using System;
using System.CodeDom;
using System.Collections.Generic;

namespace Task1
{
    [Serializable]
    public sealed class Book : IEquatable<Book>, IComparable<Book>, IComparer<Book>
    {
        #region Ctors
        public Book(string author, string title)
        {
            Author = author;
            Title = title;
        }

        public Book(string author, string title, string genre, string publishingHouse, int pages)
        {
            Author = author;
            Title = title;
            Genre = genre;
            PublishingHouse = publishingHouse;
            Pages = pages;
        }
        #endregion

        #region Properties
        public string Author { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string PublishingHouse { get; set; }
        public int Pages { get; set; }
        #endregion

        #region Interface and override methods
        public bool Equals(Book other)
        {
            if (ReferenceEquals(other, null))
                return false;
            if (Author == other.Author &&
                Title == other.Title &&
                Genre == other.Genre &&
                PublishingHouse == other.PublishingHouse &&
                Pages == other.Pages)
                return true;
            return false;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            return obj is Book && Equals((Book)obj);
        }

        public override int GetHashCode()
        {
            return Author.Length * 3 + Title.Length * 5 + Genre.Length * 7 + PublishingHouse.Length * 11 + Pages;
        }

        public int CompareTo(Book other)
        {
            if (ReferenceEquals(other, null))
                throw new ArgumentNullException();
            return String.Compare(Title, other.Title, StringComparison.InvariantCultureIgnoreCase);
        }

        public int Compare(Book first, Book second)
        {
            if (first == null || second == null)
                throw new ArgumentNullException();
            return String.Compare(first.Title, second.Title, StringComparison.InvariantCultureIgnoreCase);
        }

        public override string ToString()
        {
            string result = string.Format("Book [Title: {0}, Author: {1}, Number of pages: {2}, Genre: {3}, " +
                                          "Publishing house: {4}]", Title, Author, Pages, Genre, PublishingHouse);
            return result;
        }

        #endregion

        #region Override operators

        public static bool operator ==(Book left, Book right)
        {
            if (ReferenceEquals(null, left))
                throw new ArgumentNullException();
            return left.Equals(right);
        }

        public static bool operator !=(Book left, Book right)
        {
            return !(left == right);
        }

        #endregion
    }

}
