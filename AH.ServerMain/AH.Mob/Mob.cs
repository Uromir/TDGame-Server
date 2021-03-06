﻿using System;
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
        public double ActualDamage { set; get; }

        public Mob(int Id)
        {
            this.HP = 100;
            this.Id = Id; // изменить метод присваивания Id
        }

        public void CauseDamage(double Damage)
        {
            ActualDamage += Damage;
        }

        // Изменение характеристик мобов (заморозка и т.д.), а так же возвращает тру если он умер
        public bool ChangeStatus()
        {
            if (HP <= 0)
                return true;
            return false;
        }
    }
}
