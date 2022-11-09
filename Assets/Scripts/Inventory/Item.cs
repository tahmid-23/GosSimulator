using UnityEngine;

namespace Inventory
{
    public abstract class Item
    {
        public abstract Sprite DisplayItem();

        protected abstract void Use();

        public void UseItem()
        {
            Use();
        }
    }
}
