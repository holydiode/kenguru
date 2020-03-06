using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Kenguru_four_.Models
{
    public class OrderDetails
    {

        [Display(Name = "Имя")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Укажите имя")]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "Длина поля должна быть от 0 до 50 символов")]
        public string Name { get; set; }


        [Display(Name = "Телефон")]
        [Required(ErrorMessage = "Укажите номер телефона")]
        [DataType(DataType.PhoneNumber)]
      // [StringLength(10, MinimumLength = 10, ErrorMessage = "Длина поля должна быть равна 10 символов")]
        public string phone { get; set; }

     //   [StringLength(30)]
       [Display(Name= "Электронная почта")]
        [Required(ErrorMessage = "Укажите адрес электронной почты")]
       [DataType(DataType.EmailAddress)]

        public string email { get; set; }

        [Display(Name = "Адрес")]
        [DataType(DataType.Text)]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "Длина поля должна быть от 0 до 50 символов")]
        [Required(ErrorMessage = "Укажите адрес доставки")]
            public string Adresss { get; set; }

        [Display(Name = "Город")]
        [DataType(DataType.Text)]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "Длина поля должна быть от 0 до 50 символов")]
        [Required(ErrorMessage = "Укажите город")]
            public string City { get; set; }
        [Display(Name = "Страна")]
        [DataType(DataType.Text)]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "Длина поля должна быть от 0 до 50 символов")]
        [Required(ErrorMessage = "Укажите страну")]
            public string Country { get; set; }

    }
}