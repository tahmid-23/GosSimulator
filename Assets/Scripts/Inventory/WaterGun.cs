using UnityEngine;

namespace Inventory
{
    public class WaterGun : Projectile
    {
        private double _percentFull = 100.0;

        public void FillUp()
        {
            _percentFull = 100.0;
        }

        public override void Use()
        {
            Debug.Log("Used WaterGun");
        }

        public override void VisualUpdate()
        {
            throw new System.NotImplementedException();
        }
    }
}