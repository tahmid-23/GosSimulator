using System.Transactions;
using UnityEngine;

namespace Inventory
{
    public class Rock : Throwable
    {
        private void Start()
        {
            // Change this because we don't have the rock sprite yet
            this.DisplaySprite = Resources.Load<Sprite>("Sprites/watergun");
        }
        public override void Use()
        {
            
        }
    }
}
