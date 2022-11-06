using UnityEngine;

namespace Inventory
{
    public class Frisbee : Throwable
    {
        public Frisbee() : base(1, 15)
        {
        }

        public override void DisplayItem()
        {
        
        }

        protected override void Use()
        {
            Debug.Log("Threw a Frisbee");
        }
    }
}
