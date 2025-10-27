using System.Collections.Generic;
using LiberaryManagement;
using LiberaryManagement.Repositories;

namespace LiberaryManagement.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repo;

        public BookService(IBookRepository repo) => _repo = repo;

        public IEnumerable<Book> GetAll() => _repo.GetAll();

        public Book? GetById(int id) => _repo.GetById(id);

        public void Create(Book book)
        {
            _repo.Add(book);
        }

        public void Update(Book book) => _repo.Update(book);

        public void Delete(int id) => _repo.Remove(id);
    }
}