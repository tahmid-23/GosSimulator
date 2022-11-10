using UnityEngine;

namespace Inventory
{
    public class WaterGun : Projectile
    {
        private double _percentFull = 100.0;
        private Sprite _sprite = Resources.Load<Sprite>("Sprites/watergun");

        public WaterGun() : base(10, 1, 20)
        {
            
        }

        public void FillUp()
        {
            _percentFull = 100.0;
        }

        protected override void Use()
        {
            Debug.Log("Used");
        }

        public override Sprite DisplayItem()
        {
            return _sprite;
        }
    }
}