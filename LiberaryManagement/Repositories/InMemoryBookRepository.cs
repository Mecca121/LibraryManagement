using System.Collections.Generic;
using System.Linq;
using LiberaryManagement;

namespace LiberaryManagement.Repositories
{
    public class InMemoryBookRepository : IBookRepository
    {
        public IEnumerable<Book> GetAll() => LibraryData.Books;

        public Book? GetById(int id) => LibraryData.Books.FirstOrDefault(b => b.Id == id);

        public void Add(Book book)
        {
            book.Id = GetNextId();
            LibraryData.Books.Add(book);
        }

        public void Update(Book book)
        {
            var existing = GetById(book.Id);
            if (existing == null) return;
            existing.Title = book.Title;
            existing.Author = book.Author;
            existing.ISBN = book.ISBN;
            existing.IsAvailable = book.IsAvailable;
        }

        public void Remove(int id)
        {
            var book = GetById(id);
            if (book != null) LibraryData.Books.Remove(book);
        }

        public int GetNextId() => LibraryData.GetNextBookId();
    }
}