using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebShop.App.Models
{
    public class Order
    {
        [BindNever]
        public int id { get; set; }

        [Display(Name="Введите имя")]
        [StringLength(40)]
        [Required(ErrorMessage = "Обязательное поле")]
        public string name { get; set; }

        [Display(Name = "Введите фамилию")]
        [StringLength(40)]
        [Required(ErrorMessage = "Обязательное поле")]
        public string lastName { get; set; }

        [Display(Name = "Введите номер телефона")]
        [StringLength(40)]
        [Required(ErrorMessage = "Обязательное поле")]
        public string phone { get; set; }

        [Display(Name = "Введите email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(40)]
        [Required(ErrorMessage = "Обязательное поле")]
        public string email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime date { get; set; }

        public List<OrderDetail> orderDetails { get; set; }
    }
}
