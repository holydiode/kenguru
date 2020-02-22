namespace Kenguru_four_
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("kengu.categories")]
    public partial class Category
    {
        public int id { get; set; }

        [Column("parent-id")]
        public int? parentID { get; set; }

        public virtual Category parent { get; set; }

        [StringLength(20)]
        public string name { get; set; }

        public virtual ICollection<Category> subCategories { get; set; }

        public virtual ICollection<Good> goods { get; set; }
    }
}
