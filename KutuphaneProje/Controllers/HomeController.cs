using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using KutuphaneProje.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KutuphaneProje.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        UsersManager _usersManager = new UsersManager(new EfUsersDal());
        BooksManager _booksManager = new BooksManager(new EfBooksDal());
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        
        public IActionResult Index()
        {
            var values = _booksManager.TGetList();
            var books = new List<BooksIndexViewModel>();
            foreach (var item in values)
            {
                var user = _usersManager.TGetList().Where(x => x.BookId == item.BookId).FirstOrDefault();

                BooksIndexViewModel bookList = new BooksIndexViewModel()
                {
                    Bookname = item.BookName,
                    Outhor = item.Outhor,
                    Status = item.StatusId == 1 ? "Dışarıda" : "Kütüphanede",
                    Id = item.BookId,
                    Name = user == null ? "" : user.UserName,
                    Surname =user == null ? "":user.UserSurname,
                    EndDate = user != null ? user.EndDate.ToShortDateString().ToString() : null,
                    StartDate = user != null ? user.EndDate.ToShortDateString().ToString() : null,
                };
                books.Add(bookList);
            }


            books = books.OrderBy(x => x.Bookname).ToList();
            return View(books);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}