using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public sealed class BinaryFileSerializer : IBookSerializable
    {
        private string path;

        public BinaryFileSerializer(string path)
        {
            this.path = path;
        }

        public object Read()
        {
            object result;
            if (string.IsNullOrEmpty(path))
                throw new ArgumentException();
            BinaryFormatter bf = new BinaryFormatter();
            using (var fs = new FileStream(path, FileMode.Open))
            {
                result = bf.Deserialize(fs);
            }
            return result;
        }

        public void Write(object bookList)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentException();
            BinaryFormatter bf = new BinaryFormatter();
            using (var fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                bf.Serialize(fs, bookList);
            }
        }
    }
}
