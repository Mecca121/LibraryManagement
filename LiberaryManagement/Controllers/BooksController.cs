using LiberaryManagement.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LiberaryManagement.Controllers
{
    public class BooksController : Controller
    {
        private readonly BookService _bookService;

        public BooksController(BookService bookService)
        {
            _bookService = bookService;
        }

        public IActionResult Index()
        {
            var books = _bookService.GetAllBooks();
            return View(books);
        }
    }

    public class BorrowingController : Controller
    {
        private readonly IBorrowingService _borrowingService;

        public BorrowingController(IBorrowingService borrowingService)
        {
            _borrowingService = borrowingService;
        }

        [HttpPost]
        public IActionResult Borrow(int bookId, int memberId)
        {
            if (_borrowingService.BorrowBook(bookId, memberId))
            {
                return RedirectToAction("Index", "Books");
            }
            return BadRequest();
        }
    }
}
