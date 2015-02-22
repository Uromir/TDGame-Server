using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AH.Object;

namespace AH.Hero
{
    public class Hero : DinamicObject
    {
        public double HP { set; get; }
        public int Id { set; get; }

        public Hero()
        {
            this.HP = 100;
            this.Id = 1; // изменить метод присваивания Id
        }
    }
}
