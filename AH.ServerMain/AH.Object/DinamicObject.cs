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

        public DinamicObject()
        {
            this.Direction = new Vector3(0, 0, 0);
        }
    }
}
