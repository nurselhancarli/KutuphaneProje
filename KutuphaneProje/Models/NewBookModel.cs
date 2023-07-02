using System.ComponentModel.DataAnnotations;

namespace KutuphaneProje.Models
{
    public class NewBookModel
    {
        [Required(ErrorMessage = "Lütfen kitabın adını giriniz")]
        public string BookName { get; set; }
        [Required(ErrorMessage = "Lütfen kitabın yazarını giriniz")]
        public string Outhor { get; set; }
        //[Required(ErrorMessage = "Lütfen kitabın resmini giriniz")]
        public IFormFile Photo { get; set; }
        public string PhotoUrl { get; set; }

    }
}
