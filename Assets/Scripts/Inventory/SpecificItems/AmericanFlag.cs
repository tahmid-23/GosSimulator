using System;
using System.Buffers.Text;
using UnityEngine;

namespace Inventory
{
    public class AmericanFlag: Melee
    {
        private void Start()
        {
            this.DisplaySprite = Resources.Load<Sprite>("Sprites/flag");
        }

        public override void Use()
        {
            Debug.Log("angered the opps");
        }

        public override void VisualUpdate()
        {
            
        }
    }
}