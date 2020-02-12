namespace Kenguru_four_
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("kengu.goods")]
    public partial class goods
    {
        public int id { get; set; }

        [Column("id-seller")]
        public int? id_seller { get; set; }

        [StringLength(50)]
        public string title { get; set; }

        public int? count { get; set; }

        public int? price { get; set; }

        [Column("id-category")]
        public int id_category { get; set; }

        public int? seles { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string description { get; set; }

        [Column("short-discribe", TypeName = "text")]
        [StringLength(65535)]
        public string short_discribe { get; set; }
    }
}
