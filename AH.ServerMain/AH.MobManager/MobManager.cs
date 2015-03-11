using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AH.MobManager
{
    public class MobManager
    {
        public List<AH.Mob.Mob> AllMobs;

        public MobManager()
        {
            this.AllMobs = new List<AH.Mob.Mob>();
        }

        // приказать всем мобам двигаться
        public void MoveAllMobs()
        {
            for (int i = 0; i < AllMobs.Count(); i++)
            {
                AllMobs[i].Move();
            }
        }

        public void Update()
        {
            MoveAllMobs();
        }
    }
}
