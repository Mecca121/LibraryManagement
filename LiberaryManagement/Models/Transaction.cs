namespace LiberaryManagement.Models
{
    public class Transaction
        {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int MemberId { get; set; }
        public DateTime DateBorrowed { get; set; }
        public DateTime? DateReturned { get; set; }
        public string Type { get; set; } 
    }
}