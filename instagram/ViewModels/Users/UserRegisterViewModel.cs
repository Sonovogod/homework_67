using System.ComponentModel.DataAnnotations;
using instagram.Enums.User;
using Microsoft.AspNetCore.Mvc;

namespace instagram.ViewModels.Users;

public class UserRegisterViewModel
{
    [Display(Name = "Логин")]
    [StringLength(30, MinimumLength = 1, ErrorMessage = "LoginEmailLenghtError")]
    [Required(ErrorMessage = "NotNull")]
    [RegularExpression(@"^[^@А-Яа-я]*$", ErrorMessage = "CirillicError")]
    [Remote("CheckUniqueName", "AccountValidation", ErrorMessage = "NonUnic", AdditionalFields = "UserName")]
    public string UserName { get; set; }
    
    [Display(Name = "Эл. почта")]
    [Required(ErrorMessage = "NotNull")]
    [EmailAddress (ErrorMessage = "EmailError")]
    [RegularExpression(@"^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$", ErrorMessage = "FormatError")]
    [Remote("CheckUniqueEmail", "AccountValidation", ErrorMessage = "EmailNonUnic", AdditionalFields = "Email")]
    public string Email { get; set; }
    
    [Display(Name = "Фото профиля")]
    public string? Avatar { get; set; }
    
    [Display(Name = "Пароль")]
    [Required(ErrorMessage = "NotNull")]
    [MinLength(5, ErrorMessage = "MinPassLenghtError")]
    public string Password { get; set; }
    
    [Display(Name = "Подтверждение пароля")]
    [Required(ErrorMessage = "NotNull")]
    [Compare(nameof(Password), ErrorMessage = "PassNotCompare")]
    public string ConfirmPassword { get; set; }
    
    [Display(Name = "Ваше имя (необязательно)")]
    [StringLength(30, ErrorMessage = "NameMaxLenght")]
    public string? Name { get; set; }
    
    [Display(Name = "Информация о пользователе")]
    [StringLength(30, ErrorMessage = "NameMaxLenght")]
    public string? UserInfo { get; set; }
    
    [Display(Name = "Номер телефона")]
    [StringLength(16, ErrorMessage = "MaxPhoneLenght")]
    [RegularExpression(@"^[+]?[0-9]*$", ErrorMessage = "FormatError")]
    public string? PhoneNumber { get; set; }
    
    [Display(Name = "Пол")]
    public Gender? Gender { get; set; }
    public string? ReturnUrl { get; set; }
}