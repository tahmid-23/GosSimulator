using UnityEngine;

namespace Inventory
{
    public class WaterGun : Projectile
    {
        private float _percentFull = 100.0F;

        public void FillUp()
        {
            _percentFull = 100.0F;
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