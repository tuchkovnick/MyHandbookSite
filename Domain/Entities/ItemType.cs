using System;
using System.ComponentModel.DataAnnotations;

namespace MyHandbookSite.Domain.Entities
{
    public class ItemType
    {
        [Key]
        [Required]
        public Guid Id { set; get; }

        [Required(ErrorMessage = "Введите название")]
        [Display(Name = "Название")]
        public string Title { set; get; }
    }
}