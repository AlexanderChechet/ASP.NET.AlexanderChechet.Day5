using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public interface IBookSerializable
    {
        object Read();
        void Write(object bookList);
    }
}
