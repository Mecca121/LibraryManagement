namespace LiberaryManagement.Models
{
    public class Member
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public List<int> BorrowedBookIds { get; set; } = new List<int>();
        }
    }

