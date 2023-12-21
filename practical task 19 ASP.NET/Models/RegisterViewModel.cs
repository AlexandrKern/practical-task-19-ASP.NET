using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace practical_task_19_ASP.NET.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Введите имя")]
        [MaxLength(20, ErrorMessage = "Имя должно иметь менее 20 символов")]
        [MinLength(1, ErrorMessage = "Имя должно иметь более 1 символа")]
        [DisplayName(displayName: "Имя")]
        public string Name { get; set; }
        [DisplayName(displayName: "Пароль")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Введите пароль")]
        [MinLength(5, ErrorMessage = "Пароль должен иметь более 6 или более символа")]
        public string Password { get; set; }
        [DisplayName(displayName: "Подтвердите пароль")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Подтвердите пароль")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string PasswordConfirm { get; set; }
        [DisplayName(displayName: "Логин")]
        [Required(ErrorMessage = "Введите логин")]
        [MaxLength(20, ErrorMessage = "Логин должен иметь менее 20 символов")]
        [MinLength(6, ErrorMessage = "Догин должен иметь более 6 символа")]
        public string Login { get; set; }
        public int Role { get; set; }
    }
}
