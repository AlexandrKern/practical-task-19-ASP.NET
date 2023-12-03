using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace practical_task_19_ASP.NET.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Логин")]
        public string Login { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
        [Display(Name = "Запомнить?")]
        public string? ReturnUrl { get; set; }
    }
}
