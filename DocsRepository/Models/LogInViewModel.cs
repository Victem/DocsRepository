using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DocsRepository.Models
{
    public class LogInViewModel
    {
        
        [Required(ErrorMessage = "Введите имя")]
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name="Пароль")]
        public string Password { get; set; }
    }
}