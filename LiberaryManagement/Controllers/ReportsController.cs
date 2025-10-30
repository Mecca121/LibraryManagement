using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using LiberaryManagement.Services;

namespace LiberaryManagement.Controllers
{
    public class ReportsController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IMemberService _memberService;

        public ReportsController(IBookService bookService, IMemberService memberService)
        {
            _bookService = bookService ?? throw new ArgumentNullException(nameof(bookService));
            _memberService = memberService ?? throw new ArgumentNullException(nameof(memberService));
        }

        public IActionResult BorrowedBooks()
        {
            var borrowed = _bookService.GetAll()
                                       .Where(b => b != null && !b.IsAvailable)
                                       .ToList();

            return View(borrowed);
        }

        public IActionResult MemberSummary()
        {
            var members = _memberService.GetAllMembers() ?? Enumerable.Empty<Member>();

            var summary = members.Select(m => new MemberSummaryVM
            {
                Name = m.Name,
                Email = m.Email,
                BorrowedBooks = (m.BorrowedBookIds ?? Enumerable.Empty<int>())
                    .Select(id => _bookService.GetById(id))
                    .Where(b => b != null)
                    .ToList()
            }).ToList();

            return View(summary);
        }
    }

    
    public class MemberSummaryVM
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<Models.Book> BorrowedBooks { get; set; } = new List<Models.Book>();
    }

    
    public interface IMemberService
    {
        IEnumerable<Member> GetAllMembers();
        Member? GetMemberById(int id);
    }

    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<int> BorrowedBookIds { get; set; } = new List<int>();
    }
}
