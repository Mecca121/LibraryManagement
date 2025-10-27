namespace LiberaryManagement
{
    public class Transaction
    {
        public int Id { get; set; }
        public string BookId { get; set; }
        public string MemberId { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public bool IsReturned { get; set; } = false;
    }
}
