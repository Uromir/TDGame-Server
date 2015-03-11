﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AH.BulletManager
{
    public class BulletManager
    {
        List<AH.Bullet.Bullet> AllBullet;

        public BulletManager()
        {
            AllBullet = new List<AH.Bullet.Bullet>();
        }

        public void MoveAllBullets()
        {
            for (int i = 0; i < AllBullet.Count(); i++)
            {
                AH.Bullet.Bullet ActualBullet = AllBullet[i];
                ActualBullet.Move();
                // это невозможно так как даблы, но правильно сделаю чуть позже
                if (ActualBullet.Position == ActualBullet.Target.Position)
                {
                    ActualBullet.Target.CauseDamage(ActualBullet.Damage);
                }
            }
        }

        public void Update()
        {

        }
    }
}
