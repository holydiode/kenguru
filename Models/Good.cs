namespace Kenguru_four_
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public enum GoodStatus {save, publsih, deleted }


    [Table("kengu.goods")]
    public partial class Good
    {
        public virtual ICollection<Order> orders { get; set; }

        [Key]
        public int id { get; set; }

        [Column("id-seller")]
        public int? sellerID { get; set; }
        public virtual Seller seller { get; set; }

        [StringLength(50)]
        public string title { get; set; }
        public int? count { get; set; }
        public int price { get; set; }

        [NotMapped]
        public float PriceInRubles { get => ((float)price)/ 100; set => price = (int)Math.Round(value * 100, 0); }

        [Column("id-category")]
        public int categoryID { get; set; }
        public virtual Category category { get; set; }
        public int seles { get; set; }


        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string description { get; set; }

        [Column("short-discribe", TypeName = "text")]
        [StringLength(65535)]
        public string short_discribe { get; set; }
        public int status { get; set; }
    }
}
