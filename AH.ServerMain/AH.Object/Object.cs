using SharpDX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AH.Object
{
    public class Object
    {
        public Vector3 Position { set; get; }

        public Object()
        {
            this.Position = new Vector3(0, 0, 0);
        }

        public Object(double x, double y)
        {
            this.Position = new Vector3((float)x, (float)y, 0);
        }
    }
}
