using System.ComponentModel.DataAnnotations;
namespace instagram.ViewModels.Users;

public class UserLoginViewModel
{
    [Display(Name = "Эл. адрес или логин пользователя")]
    [Required(ErrorMessage = "NotNull")]
    public string EmailOrLogin { get; set; }
    [Display(Name = "Пароль")]
    [Required(ErrorMessage = "NotNull")]
    public string Password { get; set; }
    public string? ReturnUrl { get; set; }
}