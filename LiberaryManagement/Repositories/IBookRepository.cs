using System.Collections.Generic;
using LiberaryManagement;

namespace LiberaryManagement.Repositories
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAll();
        Book? GetById(int id);
        void Add(Book book);
        void Update(Book book);
        void Remove(int id);
        int GetNextId();
    }
}