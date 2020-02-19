namespace Kenguru_four_
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("kengu.sellers")]
    public partial class sellers 
    {
        public virtual ICollection<goods> good { get;set; } 

        [Key]
        public int id { get; set; }

        [StringLength(30)]
        public string email { get; set; }

        [StringLength(30)]
        public string username { get; set; }

        [StringLength(100)]
        public string name { get; set; }

        [StringLength(100)]
        public string password { get; set; }

        [StringLength(15)]
        public string phone { get; set; }

        [StringLength(200)]
        public string adress { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string description { get; set; }

        public int? reiting { get; set; }

        public sellers()
        {

        }
        public sellers(string email, string pasword)
        {
            this.email = email;
            this.password = pasword;
        }
    }
}
