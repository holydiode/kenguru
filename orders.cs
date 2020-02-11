namespace Kenguru_four_
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("kengu.orders")]
    public partial class orders
    {
        public int id { get; set; }

        [Column("id-goods")]
        public int? id_goods { get; set; }

        public int? count { get; set; }

        public int? price { get; set; }

        public int? status { get; set; }

        [StringLength(10)]
        public string track { get; set; }

        [StringLength(200)]
        public string adres { get; set; }

        [StringLength(15)]
        public string phone { get; set; }

        [StringLength(30)]
        public string email { get; set; }
    }
}
