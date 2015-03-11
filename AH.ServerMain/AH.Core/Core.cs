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

        public int a;

        public CoreServer()
        {
            this.MainHeroManager = new AH.HeroManager.HeroManager();
            this.MainTowerManager = new AH.TowerManager.TowerManager();
            this.MainMobManager = new AH.MobManager.MobManager();
            this.MainBulletManager = new BulletManager.BulletManager();
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
        public void Update(System.Object StateInfo)
        {
            AutoResetEvent autoEvent = (AutoResetEvent)StateInfo;

            MainHeroManager.Update();
            MainMobManager.Update();
            MainBulletManager.Update();
        }
    }
}
