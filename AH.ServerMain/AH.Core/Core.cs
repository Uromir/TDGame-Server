using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpDX;

namespace AH.Core
{
    public class CoreServer
    {
        AH.HeroManager.HeroManager MainHeroManager;
        AH.TowerManager.TowerManager MainTowerManager;

        public CoreServer()
        {
            this.MainHeroManager = new AH.HeroManager.HeroManager();
            this.MainTowerManager = new AH.TowerManager.TowerManager();
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
    }
}
