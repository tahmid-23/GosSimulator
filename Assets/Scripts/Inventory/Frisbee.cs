using Inventory;
using UnityEngine;

namespace Inventory
{
    public class Frisbee : Throwable
    {
        public Frisbee() : base(1, 15)
        {
        }

        public override Sprite DisplayItem()
        {
            throw new System.NotImplementedException();
        }

        protected override void Use()
        {
            Debug.Log("Threw a Frisbee");
        }
    }
}
