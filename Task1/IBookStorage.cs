using System.Collections.Generic;

namespace Task1
{
    public interface IBookStorage
    {
        List<Book> Load();
        void Save(IEnumerable<Book> books);
    }
}
