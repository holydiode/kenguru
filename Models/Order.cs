namespace Kenguru_four_
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("kengu.orders")]
    public partial class Order
    {
        public int id { get; set; }

        [Column("id-goods")]
        public int? goodID { get; set; }

        public virtual Good good { get; set; }

        public int? count { get; set; }

        public int? price { get; set; }

        public int? status { get; set; }

        [StringLength(10)]
        public string track { get; set; }

        [StringLength(200)]
        public string adress { get; set; }

        public string time { get; set; }

        [NotMapped]
        public DateTime Time { get =>  Convert.ToDateTime(time); set => time = value.ToString(); }

        [StringLength(15)]
        public string phone { get; set; }

        [StringLength(30)]
        public string email { get; set; }

    }
}
