using System;
using System.ComponentModel.DataAnnotations;

namespace MyHandbookSite.Domain.Entities
{
    public class Item
    {
        [Required]
        [Key]
        public Guid Id { set; get; }

        [Display(Name = "Тип")]
        public Guid TypeId { set; get; }

        [Required(ErrorMessage = "Введите название")]
        [Display(Name = "Название")]
        public string Title { set; get; }
             
        [Display(Name = "Изображение")]
        public string ImageSource { set; get; }

        [Required(ErrorMessage = "Введите описание")]
        [Display(Name = "Описание")]
        public string Description { set; get; }

    }
}