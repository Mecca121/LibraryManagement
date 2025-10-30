
using LiberaryManagement.Interfaces;
using LiberaryManagement.Models;

namespace LiberaryManagement.Repositories
{
    public class BookService : IBookService
    {
        List<Book> books = new List<Book>
        {
            new Book{Id =1, Author ="John Doe", ISBN = "54624", Title = "Legend" },
            new Book{Id =2, Author ="kolawole  opeyemi", ISBN = "54623", Title = "Ali Goes to School" },
            new Book{Id =3, Author ="Lawal opeyemi Abdulmajeed", ISBN = "54622", Title = "Legend of the seeker" },
            new Book{Id =4, Author ="Jimoh Lawal", ISBN = "54621", Title = "Game of throne" }
        };

        public void AddBook(Book book)
        {
            throw new NotImplementedException();
        }

        public void DeleteBook(int id)
        {
            throw new NotImplementedException();
        }

        public Book GetBookById(int id)
        {
            var book = books.FirstOrDefault(x => x.Id == id);
            return book;
        }

        public bool SetBookStatus(int bookId, bool isBorrowed)
        {
            throw new NotImplementedException();
        }

        public void UpdateBook(Book book)
        {
            throw new NotImplementedException();
        }

        internal IEnumerable<Book>? GetAllBooks()
        {
            return books;
        }

        IEnumerable<Book> IBookService.GetAllBooks()
        {
            throw new NotImplementedException();
        }
    }
}
