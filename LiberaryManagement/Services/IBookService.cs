using System.Collections.Generic;
using LiberaryManagement;
using LiberaryManagement.Models;

namespace LiberaryManagement.Services
{
    public interface IBookService
    {
        IEnumerable<Book> GetAll();
        Book? GetById(int id);
        void Create(Book book);
        void Update(Book book);
        void Delete(int id);
    }
}