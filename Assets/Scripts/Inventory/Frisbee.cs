using UnityEngine;

namespace Inventory
{
    public class Frisbee : Throwable
    {
        public override void Use()
        {
            Debug.Log("Threw a Frisbee");
        }
    }
}
