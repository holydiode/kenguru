namespace Kenguru_four_
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("kengu.catigories")]
    public partial class catigories
    {
        public int id { get; set; }

        [Column("parent-id")]
        public int? parent_id { get; set; }

        [StringLength(20)]
        public string name { get; set; }
    }
}
