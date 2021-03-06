﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AH.Hero;

namespace AH.HeroManager
{
    public class HeroManager
    {
        public List<AH.Hero.Hero> AllHero;

        public HeroManager()
        {
            this.AllHero = new List<AH.Hero.Hero>();
        }

        // вернуть героя по его Id
        public AH.Hero.Hero GetHeroById(int Id)
        {
            for (int i = 0; i < AllHero.Count; i++)
            {
                if(AllHero[i].Id == Id)
                    return AllHero[i];
            }
            return null;
        }

        // Приказать всем героям двигаться
        public void MoveAllHeroes()
        {
            for (int i = 0; i < AllHero.Count(); i++ )
            {
                AllHero[i].Move();
            }
        }

        public void Update()
        {
            MoveAllHeroes();
        }
    }
}
