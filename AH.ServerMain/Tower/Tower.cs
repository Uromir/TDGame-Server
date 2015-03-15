using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AH.Object;
using SharpDX;

namespace AH.Tower
{
    public class Tower : StaticObject
    {
        public double Damage { set; get; }
        public double HP { set; get; }
        public int Type { set; get; }
        public double AttackSpeed { set; get; }
        public double Radius { set; get; }
        public DateTime TimeLastShot { set; get; }
        public int TargetCount { set; get; }

        public Tower(Vector3 TowerPosition, int TowerType)
        {
            this.Position = TowerPosition;
            // тут по идее надо характеристики башни в зависимости от типа но пока так
            this.Damage = 10;
            this.HP = 100;
            this.Type = 1;
            this.AttackSpeed = 10;
            this.Radius = 100;
            this.TargetCount = 1;
        }
    }
}
