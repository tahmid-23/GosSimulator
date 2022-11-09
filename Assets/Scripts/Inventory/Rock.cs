using UnityEngine;

namespace Inventory
{
    public class Rock : Throwable
    {
        public Rock() : base(10, 5)
        {
        }

        public override Sprite DisplayItem()
        {
            throw new System.NotImplementedException();
        }

        protected override void Use()
        {
            
        }
    }
}
