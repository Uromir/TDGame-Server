using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX;

namespace AH.TowerManager
{
    public class TowerManager
    {
        public List<AH.Tower.Tower> AllTower;

        public TowerManager()
        {
            this.AllTower = new List<AH.Tower.Tower>();
        }

        public void CreateNewTower(Vector3 TowerPosition, int TowerType)
        {
            AH.Tower.Tower NewTower = new AH.Tower.Tower(TowerPosition, TowerType);
            this.AllTower.Add(NewTower);
        }
    }
}
