using System.ComponentModel.DataAnnotations;

namespace KutuphaneProje.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "Lütfen Adınızı Girini")]
        public string PersonnelName { get; set; }
        [Required(ErrorMessage = "Lütfen Soyadınızı Giriniz")]
        public string PersonnelSurname { get; set; }
        [Required(ErrorMessage = "Lütfen Mail Giriniz")]
        public string PersonnelMail { get; set; }
        [Required(ErrorMessage = "Lütfen Kullanıcı Adı Giriniz")]
        public string PersonnelUsername { get; set; }
        [Required(ErrorMessage = "Lütfen Şifrenizi Giriniz")]
        public string PersonnelPassword { get; set; }
    }
}
