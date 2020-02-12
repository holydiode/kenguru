namespace Kenguru_four_
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("kengu.sellers")]
    public partial class sellers
    {
        public int id { get; set; }

        [StringLength(30)]
        public string email { get; set; }

        [StringLength(30)]
        public string username { get; set; }

        [StringLength(100)]
        public string name { get; set; }

        [StringLength(100)]
        public string pasword { get; set; }

        [StringLength(15)]
        public string phone { get; set; }

        [StringLength(200)]
        public string adress { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string description { get; set; }
    }
}
