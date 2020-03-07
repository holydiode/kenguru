using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kenguru_four_
{
    public class Permition
    {
        /// <summary>
        /// владелец прав может создавать и изменять других администраторов
        /// </summary>
        public bool SuperAdmin { get; set; }

        /// <summary>
        ///владелец прав может заходить в аккаунты продовца
        /// </summary>
        public bool ObserverRight { get; set;}

        /// <summary>
        ///владелец прав может подтверждать и откланяет закзы
        /// </summary>
        public bool GrestinRight { get; set; }

        /// <summary>
        ///владелец прав может настраивать и управлять конфигурацией сайта
        /// </summary>
        public bool MechanicusRight { get; set; }


        public Permition()
        {

        }

        public Permition(int key)
        {
            this.SuperAdmin = ((key >> 0) & 1) == 1;
            this.ObserverRight = ((key >> 1) & 1) == 1;
            this.GrestinRight = ((key >> 2) & 1) == 1;
            this.MechanicusRight = ((key >> 3) & 1) == 1;
        }

        /// <summary>
        ///Возвращает ключь, соответсвующий правам доступа
        /// </summary>
        /// 
        public int ToKey()
        {
            int key = 0;
            List<int> keyarray = this.ToKeyArrey();
            for(int i = 0; i < keyarray.Count; i++)
            {
                key = key + (1 << i);
            }
            return key;
        }


        /// <summary>
        ///Возвращает массив ключей, соответсвующий правам доступа
        /// </summary>
        /// 
        private List<int> ToKeyArrey()
        {
            List<int> keyarray = new List<int>();
            keyarray.Add(Convert.ToInt32(this.SuperAdmin));
            keyarray.Add(Convert.ToInt32(this.ObserverRight));
            keyarray.Add(Convert.ToInt32(this.GrestinRight));
            keyarray.Add(Convert.ToInt32(this.MechanicusRight));

            return keyarray;
        }
    }
}