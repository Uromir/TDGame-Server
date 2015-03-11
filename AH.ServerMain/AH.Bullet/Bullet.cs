using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AH.Bullet
{
    public class Bullet
    {
        public AH.Mob.Mob Target { set; get; }
        public AH.Tower.Tower Sender { set; get; }

        public Bullet(AH.Mob.Mob Target, AH.Tower.Tower Sender)
        {
            this.Target = Target;
            this.Sender = Sender;
        }
    }
}
