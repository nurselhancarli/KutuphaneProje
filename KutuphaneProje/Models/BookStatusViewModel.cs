using EntityLayer.Concrete;
using System.ComponentModel.DataAnnotations;

namespace KutuphaneProje.Models
{
    public class BookStatusViewModel
    {
        [Required(ErrorMessage = "Lütfen adınızı Giriniz")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Lütfen soyadınzı Giriniz")]
        public string UserSurname { get; set; }
        [Required(ErrorMessage = "Lütfen kitabı getireceğini tarihi giriniz")]
        public DateTime EndDate { get; set; }
        public int BookId { get; set; }
        public Books Book { get; set; }
    }
}
