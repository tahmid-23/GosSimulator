using UnityEngine;

namespace Inventory
{
    public abstract class Item : MonoBehaviour
    {

        [field: SerializeField]
        public Sprite DisplaySprite { get; private set; }

        public abstract void Use();

        public abstract void VisualUpdate();

    }
}
