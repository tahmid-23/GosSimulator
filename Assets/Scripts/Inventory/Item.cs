using UnityEngine;

namespace Inventory
{
    public abstract class Item : MonoBehaviour
    {

        [field: SerializeField]
        public Sprite DisplaySprite { get; private set; }
        
        public EquipHandler OnEquipped { get; set; } = delegate { };

        public abstract void Use();

        public abstract void VisualUpdate();

        public delegate void EquipHandler(bool equipped);

    }
}
