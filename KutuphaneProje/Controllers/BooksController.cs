using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using KutuphaneProje.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KutuphaneProje.Controllers
{
    [AllowAnonymous]
    public class BooksController : Controller
    {
        BooksManager _booksManager = new BooksManager(new EfBooksDal());
        UsersManager _usersManager = new UsersManager(new EfUsersDal());
        private readonly ILogger<BooksController> _logger;
        public BooksController(ILogger<BooksController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            var values = _booksManager.TGetList();
            var books = new List<BookListViewModel>();
            foreach (var item in values)
            {
                var user = _usersManager.TGetList().Where(x => x.BookId == item.BookId).FirstOrDefault();

                BookListViewModel bookList = new BookListViewModel()
                {
                    Bookname = item.BookName,
                    Outhor = item.Outhor,
                    Status = item.StatusId,
                    Id = item.BookId,
                    EndDate = user != null ? user.EndDate.ToShortDateString().ToString() : null,
                    StartDate = user != null ? user.StartDate.ToShortDateString().ToString() : null,
                };
                books.Add(bookList);
            }

           
            books =books.OrderBy(x=> x.Bookname).ToList();    
            return View(books);
        }
        [HttpGet]
        public IActionResult NewBook()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewBook(NewBookModel n)
        {
            try
            {
                if (n.Photo != null)
                {
                    var resource = Directory.GetCurrentDirectory();
                    var extension = Path.GetExtension(n.Photo.FileName);
                    var imageName = Guid.NewGuid() + extension;
                    var saveLocation = resource + "/wwwroot/booksimages/" + imageName;
                    var stream = new FileStream(saveLocation, FileMode.Create);
                    n.Photo.CopyToAsync(stream);
                    n.PhotoUrl = imageName;
                }

                Books newBooks = new Books()
                {
                    BookName = n.BookName,
                    Outhor = n.Outhor,
                    StatusId = 2,
                    Photo = n.PhotoUrl
                };
                _booksManager.TInsert(newBooks);
            }
            catch (Exception ex)
            {

                _logger.LogError("Ekleme işleminde hata oluştu", ex.ToString());
            }

            return RedirectToAction("Index", "Books");
        }
        [HttpGet]
        public IActionResult BooksStatusUpdate(int id)
        {
            BookStatusViewModel books = new BookStatusViewModel()
            {
                BookId = id
            };

            return View(books);
        }
        [HttpPost]
        public IActionResult BooksStatusUpdate(BookStatusViewModel b)
        {
            var book = _booksManager.TGetById(b.BookId);
            book.StatusId = 1;
            _booksManager.TUpdate(book);
            Users users = new Users()
            {
                UserName = b.UserName,
                UserSurname = b.UserSurname,
                StartDate = DateTime.Now,
                EndDate = b.EndDate,
                BookId = b.BookId
            };
            _usersManager.TInsert(users);

            return RedirectToAction("Index", "Books");
        }
    }
}
