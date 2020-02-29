using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kenguru_four_
{
    public enum StatusOrder{NotPai, Weit, Sent, Complit, Cancel}

    public class User
    {
        public int id { set; get; }
        public string hash { set; get;}

        public User(int id, string hash) {
            this.id = id;
            this.hash = hash; 
        }

        public bool check()
        {
            KenguruDB database = new KenguruDB();
            Seller user = database.Sellers.Find(id);

            if (user == null)
            {
                return false;
            }

            if (string.Compare( user.password, hash) == 0)
            {
                return true;
            }
            else{
                return false;
            }

        }

    }
}