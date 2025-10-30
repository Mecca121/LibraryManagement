using LiberaryManagement.Models;

namespace LiberaryManagement.Interfaces
{
    // IBookService.cs
    public interface IBookService
    {
        IEnumerable<Book> GetAllBooks();
        Book GetBookById(int id);
        void AddBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(int id);
        bool SetBookStatus(int bookId, bool isBorrowed);
    }

    // IMemberService.cs
    public interface IMemberService
    {
        IEnumerable<Member> GetAllMembers();
        Member GetMemberById(int id);
        void AddMember(Member member);
    }

    // IBorrowingService.cs (Handles the transaction logic)
    public interface IBorrowingService
    {
        bool BorrowBook(int bookId, int memberId);
        bool ReturnBook(int bookId, int memberId);
        IEnumerable<Transaction> GetTransactionHistory();
    }
}
