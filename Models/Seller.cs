namespace Kenguru_four_
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("kengu.sellers")]
    public partial class Seller 
    {
        public virtual ICollection<Good> good { get;set; } 

        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Длина email должна быть от 3 до 30 символов")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Введите почту")]
        public string email { get; set; }

        [StringLength(30)]
        public string username { get; set; }

        [StringLength(100)]
        public string name { get; set; }
 
        public string password { get; set; }


        [StringLength(15)]
        public string phone { get; set; }

        [StringLength(200)]
        public string adress { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string description { get; set; }

        public int? reiting { get; set; }

        public Seller()
        {

        }
        public Seller(string email, string pasword)
        {
            this.email = email;
            this.password = pasword;
        }
    }
}
