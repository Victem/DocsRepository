using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DocsRepository.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage= "Введите имя")]
        [StringLength(50, MinimumLength=2, ErrorMessage="Имя должно содержать минимум 2 буквы")]
        [Remote("ValidateName", "Account", HttpMethod="GET", ErrorMessage="Такой пользователь уже существует")]
        [Display(Name="Имя" )]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength=6, ErrorMessage="Пароль не должен содержать минимум 6 символов")]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Пароль не должен содержать минимум 6 символов")]
        [Display(Name = "Подтверждение пароля")]
        public string ConfirmPassword { get; set; }
       
    }
}