namespace LiberaryManagement.Repositories
{
    public interface IBorrowingService
    {
        bool BorrowBook(int bookId, int memberId);
    }
}
