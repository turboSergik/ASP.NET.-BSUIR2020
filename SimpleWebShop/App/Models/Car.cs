using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebShop.App.Models
{
    public class Car
    {
        public int id { get; set; }

        [Display(Name = "Name")]
        [StringLength(40)]
        [Required(ErrorMessage = "Обязательное поле")]
        public string name { get; set; }

        [Display(Name = "Short descr.")]
        [StringLength(40)]
        [Required(ErrorMessage = "Обязательное поле")]
        public string shortDescription { get; set; }

        [Display(Name = "Full description")]
        [StringLength(40)]
        [Required(ErrorMessage = "Обязательное поле")]
        public string description { get; set; }

        [Display(Name = "Image url")]
        [StringLength(40)]
        [Required(ErrorMessage = "Обязательное поле")]
        public string image { get; set; }

        [Display(Name = "Price")]
        [StringLength(40)]
        [Required(ErrorMessage = "Обязательное поле")]
        public int price { get; set; }

        public bool isFavorite { get; set; }
        public int avaliable { get; set; }
        public int categoryID { get; set; }
        public virtual Category Category { get; set; }
    }
}
