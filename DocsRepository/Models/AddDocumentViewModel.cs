using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DocsRepository.Models
{
    public class AddDocumentViewModel
    {
        [Required]
        [Display(Name="Название документа")]
        [Remote("ValidateName", "Documents", HttpMethod="GET", ErrorMessage="Такой документ уже существует")]
        public string Name { get; set; }
        
        [Required]
        [Display(Name="Дата")]
        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }

        [Display(Name="Метки")]
        [Required]
        public string[] Tags { get; set; }

        [Required]
        [Display(Name="Документ")]
        [DataType(DataType.Upload)]
        public byte[] Document { get; set; }
    }
}