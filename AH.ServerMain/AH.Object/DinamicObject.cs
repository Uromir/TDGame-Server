using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX;

namespace AH.Object
{
    public class DinamicObject : Object
    {
        public Vector3 Direction { set; get; }
        public double Speed { set; get; }

        public DinamicObject()
        {
            this.Direction = new Vector3(0, 0, 0);
        }

        // метод возвращает отклонение по каждой координате от конечной точки в силу препятствий
        // но пока пусть оно всегда будет нулевым
        public Vector3 Move()
        {
            Position += new Vector3((float)(Direction.X * Speed), 
                (float)(Direction.Y * Speed), (float)(Direction.Z * Speed));
            return new Vector3(0, 0, 0);
        }

        public Vector3 Move(Vector3 NewDirection)
        {
            Position += new Vector3((float)(NewDirection.X * Speed),
                (float)(NewDirection.Y * Speed), (float)(NewDirection.Z * Speed));
            return new Vector3(0, 0, 0);
        }
    }
}
