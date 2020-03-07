
namespace Kenguru_four_.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    [Table("kengu.admins")]
    public class Admin
    {
        public int id { get; set; }

        [StringLength(100)]
        public string login { get; set; }

        [StringLength(100)]
        public string password { get; set; }

        public int permitions{ get; set; }
    }

}