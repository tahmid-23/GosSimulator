using UnityEngine;

namespace Inventory
{
    public abstract class Item
    {
        public abstract void DisplayItem();

        protected abstract void Use();
    }
}
