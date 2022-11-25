using UnityEngine;

namespace Inventory
{
    [CreateAssetMenu(menuName = "Item", fileName = "Assets/Resources/Items/Item")]
    public class Item : ScriptableObject
    {

        [field: SerializeField]
        public Sprite Sprite { get; private set; }

        public virtual void Equip(GameObject player)
        {
            
        }

        public virtual void Unequip(GameObject player)
        {
            
        }

        public virtual void Use(GameObject player)
        {

        }
    }
}