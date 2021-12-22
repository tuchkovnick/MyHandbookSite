﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyHandbookSite.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Логин:")]
        public string UserName { get; set; }

        [Required]
        [UIHint("Пароль:")]
        [Display(Name = "Пароль:")]
        public string Password { get; set; }

        [Display(Name = "Запомнить меня")]
        public bool RememberMe { get; set; }
    }
}
