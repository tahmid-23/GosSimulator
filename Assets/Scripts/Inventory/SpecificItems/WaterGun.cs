using System;
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

        private void Start()
        {
            this.DisplaySprite = Resources.Load<Sprite>("Sprites/watergun");
        }

        public override void Use()
        {
            Debug.Log("Used WaterGun");
        }

        public override void VisualUpdate()
        {
            
        }
    }
}