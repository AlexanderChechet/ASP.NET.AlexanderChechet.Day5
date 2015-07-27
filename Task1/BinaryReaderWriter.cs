using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

namespace Task1
{
    public class BinaryReaderWriter : IBookSerializable
    {
        private string path;

        public BinaryReaderWriter(string path)
        {
            this.path = path;
        }

        public object Read()
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

        public void Write(object bookList)
        {
            List<Book> books = bookList as List<Book>;
            if (books == null)
                throw new SerializationException();
            using (BinaryWriter bw = new BinaryWriter(File.Open(path, FileMode.Create)))
            {
                bw.Write(books.Count);
                for (int i = 0; i < books.Count; i++)
                {
                    bw.Write(books[i].Author);
                    bw.Write(books[i].Title);
                    bw.Write(books[i].Genre ?? String.Empty);
                    bw.Write(books[i].PublishingHouse ?? String.Empty);
                    bw.Write(books[i].Pages);
                }
            }
        }
    }
}
