using UnityEngine;

namespace Inventory
{
    public abstract class Melee : Weapon
    {
        [field: SerializeField]
        public float AttackRate { get; private set; }
        [field: SerializeField]
        public float AttackRange { get; private set; }
    }
}
