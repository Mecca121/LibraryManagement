using Microsoft.AspNetCore.Mvc;

namespace LiberaryManagement.Controllers
{

public class TransactionsController : Controller
    {
        public ActionResult Index()
        {
            var transactions = LibraryData.Transaction.Select(t => new
            {
                t.Id,
                BookTitle = LibraryData.Books.FirstOrDefault(b => b.Id == Convert.ToInt32(t.BookId))?.Title,
                MemberName = LibraryData.Members.FirstOrDefault(m => m.Id == Convert.ToInt32(t.MemberId))?.Name,
                t.BorrowDate,
                t.ReturnDate,
                t.IsReturned
            }).ToList();
            return View(transactions);
        }

        public ActionResult Borrow()
        {
            ViewBag.Books = LibraryData.Books.Where(b => b.IsAvailable).ToList();
            ViewBag.Members = LibraryData.Members;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Borrow(int bookId, int memberId)
        {
            var book = LibraryData.Books.FirstOrDefault(b => b.Id == bookId);
            var member = LibraryData.Members.FirstOrDefault(m => m.Id == memberId);
            if (book != null && member != null && book.IsAvailable)
            {
                book.IsAvailable = false;
                var transaction = new Transaction
                {
                    Id = LibraryData.GetNextTransactionId(),
                    BookId = bookId.ToString(),
                    MemberId = memberId.ToString(),
                    BorrowDate = DateTime.Now
                };
                LibraryData.Transaction.Add(transaction);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Return(int id)
        {
            var transaction = LibraryData.Transaction.FirstOrDefault(t => t.Id == id && !t.IsReturned);
            if (transaction != null)
            {
                transaction.ReturnDate = DateTime.Now;
                transaction.IsReturned = true;
                var book = LibraryData.Books.FirstOrDefault(b => b.Id == Convert.ToInt32(transaction.BookId));
                if (book != null) book.IsAvailable = true;
            }
            return RedirectToAction("Index");
        }
    }
}
