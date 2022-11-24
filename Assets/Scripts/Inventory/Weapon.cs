using UnityEngine;

namespace Inventory
{
    [CreateAssetMenu(menuName = "Weapon", fileName = "Assets/Resources/Items/Weapon")]
    public class Weapon : Item
    {
        
        [field: SerializeField]
        public float Damage { get; private set; }
        
    }
}