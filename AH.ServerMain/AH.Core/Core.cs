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

        public CoreServer()
        {
            this.MainHeroManager = new AH.HeroManager.HeroManager();
        }

        // устанавливаем героя направление движения
        public void SetDirectionPlayer(Vector3 NewDirection, int Id)
        {
            this.MainHeroManager.GetHeroById(Id).Direction = NewDirection;
        }
    }
}
