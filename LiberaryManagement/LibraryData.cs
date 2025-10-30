using System.Collections.Generic;
using LiberaryManagement.Models;
namespace LiberaryManagement
{
    public static class LibraryData
    {
        public static List<Book> Books { get; set; } = new List<Book>();
        public static List<Member> Members { get; set; } = new List<Member>();
        public static List<Transaction> Transaction { get; set; } = new List<Transaction>();
        public static IEnumerable<object> Transactions { get; internal set; }

        private static int _nextBookId = 1;
        private static int _nextMemberId = 1;
        private static int _nextTransactionId = 1;
        public static int GetNextBookId() => _nextBookId++;
        public static int GetNextMemberId() => _nextMemberId++;
        public static int GetNextTranscationId() => _nextTransactionId++;

        internal static int GetNextTransactionId()
        {
            throw new NotImplementedException();
        }
    }
}
