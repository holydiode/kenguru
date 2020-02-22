using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Kenguru_four_.Models
{
    public class SellerIVM
    {
        public Seller seller { get; set; }
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Длина пароля должна быть от 8 до 30 символов")]
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]

        public string password { get; set; }
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Длина пароля должна быть от 8 до 30 символов")]
       
        [Compare("password", ErrorMessage = "Пароли не совпадают")]
        [Display(Name = "Повторите пароль")]
        [DataType(DataType.Password)]
        public string secPassword { get; set; }
    }
}