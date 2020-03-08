
namespace Kenguru_four_
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

        [NotMapped]
        public Permition PermitionDecode { get => new Permition(permitions) ; set => permitions = value.ToKey(); }

        public bool check()
        {
            KenguruDB database = new KenguruDB();
            Admin user = database.Admins.Find(id);

            if (user == null)
            {
                return false;
            }

            if (string.Compare(user.password, password) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }

}