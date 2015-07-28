using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;

namespace Task1
{
    public class BinaryReaderWriter : IBookStorage
    {
        private string path;

        public BinaryReaderWriter(string path)
        {
            this.path = path;
        }

        public List<Book> Load()
        {
            List<Book> books = new List<Book>();
            using (BinaryReader br = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                uint count = br.ReadUInt32();
                for (int i = 0; i < count; i++)
                    books.Add(new Book(br.ReadString(), br.ReadString(), br.ReadString(), br.ReadString(), br.ReadInt32()));
            }
            return books;
        }

        public void Save(IEnumerable<Book> books)
        {
            if (books == null)
                throw new SerializationException();
            using (BinaryWriter bw = new BinaryWriter(File.Open(path, FileMode.Create)))
            {
                bw.Write(books.Count());
                foreach(var book in books)
                {
                    bw.Write(book.Author);
                    bw.Write(book.Title);
                    bw.Write(book.Genre ?? String.Empty);
                    bw.Write(book.PublishingHouse ?? String.Empty);
                    bw.Write(book.Pages);
                }
            }
        }
    }
}
