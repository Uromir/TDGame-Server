using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AH.Bullet
{
    public class Bullet: AH.Object.DinamicObject
    {
        // тут обязательно должны быть указатели на цель и отправителя иначе ничего работать не будет
        public AH.Mob.Mob Target { set; get; }
        public AH.Tower.Tower Sender { set; get; }

        public double Damage { set; get; }

        public Bullet(AH.Mob.Mob Target, AH.Tower.Tower Sender)
        {
            this.Target = Target;
            this.Sender = Sender;
            this.Damage = Sender.Damage;
        }

        ~Bullet()
        {
            Target = null;
            Sender = null;
        }
    }
}
