using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kenguru_four_
{
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
            kenguru database = new kenguru();
            sellers user = database.sellers.Find(id);

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