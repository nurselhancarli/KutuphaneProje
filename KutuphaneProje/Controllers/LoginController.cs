using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using KutuphaneProje.Models;
using Microsoft.AspNetCore.Mvc;

namespace KutuphaneProje.Controllers
{
    public class LoginController : Controller

    {
        PersonnelManager _personnelManager = new PersonnelManager(new EfPersonnelDal());
        private readonly ILogger<LoginController> _logger;
        public LoginController(ILogger<LoginController> logger)
        {
                _logger = logger;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(UserViewModel p)
        {
            try
            {
                var result = _personnelManager.TGetList().Where(x => x.PersonnelUsername.Equals(p.Username) &&
                x.PersonnelPassword.Equals(p.Password)).FirstOrDefault();
                if (result != null)
                {
                    return RedirectToAction("Index", "Books");
                }
                else
                {
                    _logger.LogInformation("Böyle bir personel bulunamadı");
                    return RedirectToAction("Index", "Login");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
           

            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        
        [HttpPost]
        public IActionResult Register(UserRegisterViewModel p)
        {
            try
            {
                Personnel personnel = new Personnel()
                {
                    PersonnelName = p.PersonnelName,
                    PersonnelSurname = p.PersonnelSurname,
                    PersonnelMail = p.PersonnelMail,
                    PersonnelUsername = p.PersonnelUsername,
                    PersonnelPassword = p.PersonnelPassword
                };
                _personnelManager.TInsert(personnel);
            }
            catch (Exception ex)
            {
                _logger.LogError("Herhangi bir alanı eksik girdiniz", ex.ToString());
                return RedirectToAction("Register");


            }
            return RedirectToAction("Index","Login");
        }


    }
}
