using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AH.Object;

namespace AH.Mob
{
    public class Mob : DinamicObject
    {
        public double HP { set; get; }
        public int Id { set; get; }

        public Mob(int Id)
        {
            this.HP = 100;
            this.Id = Id; // изменить метод присваивания Id
        }
    }
}
