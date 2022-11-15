using UnityEngine;

namespace Inventory
{
    public abstract class Weapon : Item
    {

        [field: SerializeField]
        public float Damage { get; private set; }

    }
}