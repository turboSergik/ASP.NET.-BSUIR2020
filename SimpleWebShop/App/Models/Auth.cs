using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebShop.App.Models
{
    public class LoginModel
    {
        [Display(Name = "Введите email")]
        [StringLength(40)]
        [Required(ErrorMessage = "Обязательное поле")]
        public string email { get; set; }

        [Display(Name = "Введите пароль")]
        [StringLength(40)]
        [Required(ErrorMessage = "Обязательное поле")]
        public string password { get; set; }
    }

    public class RegisterModel
    {

        [Display(Name = "Введите имя")]
        [StringLength(40)]
        [Required(ErrorMessage = "Обязательное поле")]
        public string name { get; set; }

        [Display(Name = "Введите email")]
        [StringLength(40)]
        [Required(ErrorMessage = "Обязательное поле")]
        public string email { get; set; }

        [Display(Name = "Введите пароль")]
        [StringLength(40)]
        [Required(ErrorMessage = "Обязательное поле")]
        public string password { get; set; }
    }
}
