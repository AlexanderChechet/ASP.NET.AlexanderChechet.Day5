using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Task1
{
    public sealed class BinaryFileSerializer : IBookStorage
    {
        private string path;

        public BinaryFileSerializer(string path)
        {
            this.path = path;
        }

        public List<Book> Load()
        {
            List<Book> result;
            if (string.IsNullOrEmpty(path))
                throw new ArgumentException();
            BinaryFormatter bf = new BinaryFormatter();
            using (var fs = new FileStream(path, FileMode.Open))
            {
                result = (List<Book>) bf.Deserialize(fs);
            }
            return result;
        }

        public void Save(IEnumerable<Book> books)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentException();
            BinaryFormatter bf = new BinaryFormatter();
            using (var fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                bf.Serialize(fs, books);
            }
        }
    }
}
