using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using SharpDX;

namespace AH.Core
{
    public class CoreServer
    {
        AH.HeroManager.HeroManager MainHeroManager;
        AH.TowerManager.TowerManager MainTowerManager;
        AH.MobManager.MobManager MainMobManager;
        AH.BulletManager.BulletManager MainBulletManager;

        public CoreServer()
        {
            this.MainHeroManager = new AH.HeroManager.HeroManager();
            this.MainTowerManager = new AH.TowerManager.TowerManager();
            this.MainMobManager = new AH.MobManager.MobManager();
            this.MainBulletManager = new BulletManager.BulletManager();
        }

        public double[] GetXCoordHero()
        {
            int n = MainHeroManager.AllHero.Count();
            double[] result = new double[n];

            for (int i = 0; i < n; i++)
            {
                result[i] = MainHeroManager.AllHero[i].Position.X;
            }
            return result;
        }

        public double[] GetYCoordHero()
        {
            int n = MainHeroManager.AllHero.Count();
            double[] result = new double[n];

            for (int i = 0; i < n; i++)
            {
                result[i] = MainHeroManager.AllHero[i].Position.Y;
            }
            return result;
        }

        public int[] GetIdHero()
        {
            int n = MainHeroManager.AllHero.Count();
            int[] result = new int[n];

            for (int i = 0; i < n; i++)
            {
                result[i] = MainHeroManager.AllHero[i].Id; ;
            }
            return result;
        }

        public double[] GetXCoordMobs()
        {
            int n = MainMobManager.AllMobs.Count();
            double[] result = new double[n];

            for (int i = 0; i < n; i++)
            {
                result[i] = MainMobManager.AllMobs[i].Position.X;
            }
            return result;
        }

        public double[] GetYCoordMobs()
        {
            int n = MainMobManager.AllMobs.Count();
            double[] result = new double[n];

            for (int i = 0; i < n; i++)
            {
                result[i] = MainMobManager.AllMobs[i].Position.Y;
            }
            return result;
        }

        public int[] GetIdMobs()
        {
            int n = MainMobManager.AllMobs.Count();
            int[] result = new int[n];

            for (int i = 0; i < n; i++)
            {
                result[i] = MainMobManager.AllMobs[i].Id;
            }
            return result;
        }

        public double[] GetHpMobs()
        {
            int n = MainMobManager.AllMobs.Count();
            double[] result = new double[n];

            for (int i = 0; i < n; i++)
            {
                result[i] = MainMobManager.AllMobs[i].HP;
            }
            return result;
        }

        public double[] GetXCoordBullets()
        {
            int n = MainBulletManager.AllBullet.Count();
            double[] result = new double[n];

            for (int i = 0; i < n; i++)
            {
                result[i] = MainBulletManager.AllBullet[i].Position.X;
            }
            return result;
        }

        public double[] GetYCoordBullets()
        {
            int n = MainBulletManager.AllBullet.Count();
            double[] result = new double[n];

            for (int i = 0; i < n; i++)
            {
                result[i] = MainBulletManager.AllBullet[i].Position.Y;
            }
            return result;
        }

        public int[] GetIdBullets()
        {
            int n = MainBulletManager.AllBullet.Count();
            int[] result = new int[n];

            for (int i = 0; i < n; i++)
            {
                result[i] = MainBulletManager.AllBullet[i].Id;
            }
            return result;
        }

        // устанавливаем героя направление движения
        public void SetDirectionPlayer(Vector3 NewDirection, int Id)
        {
            this.MainHeroManager.GetHeroById(Id).Direction = NewDirection;
        }

        // добавляем новую башню
        public void CreateNewTower(Vector3 TowerPosition, int TowerType)
        {
            this.MainTowerManager.CreateNewTower(TowerPosition, TowerType);
        }

        // функция обновляющая игровую логику и ведущая все вычисления
        public void Update()
        {
            MainHeroManager.Update();
            MainMobManager.Update();

            for (int i = 0; i < MainTowerManager.AllTower.Count(); i++)
            {
                int ShotCount = 0;
                if ((MainTowerManager.AllTower[i].TimeLastShot - DateTime.Now).Milliseconds > 1000 / MainTowerManager.AllTower[i].AttackSpeed)
                {
                    for (int j = 0; j < MainMobManager.AllMobs.Count() && ShotCount < MainTowerManager.AllTower[i].TargetCount; j++)
                    {
                        // здесь находим первого попавшегося моба в радиусе, хотя правильно брать ближайшего
                        if ((MainTowerManager.AllTower[i].Position - MainMobManager.AllMobs[j].Position).Length() < MainTowerManager.AllTower[i].Radius)
                        {
                            MainBulletManager.CreateBullet(MainMobManager.AllMobs[j], MainTowerManager.AllTower[i]);
                            ShotCount++;
                            MainTowerManager.AllTower[i].TimeLastShot = DateTime.Now;
                        }
                    }
                }
            }

            MainBulletManager.Update();

            // исключительно для теста
            Console.WriteLine("{0}", DateTime.Now.ToString());
        }
    }
}
