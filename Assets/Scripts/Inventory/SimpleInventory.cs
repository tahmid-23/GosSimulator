using UnityEngine;

namespace Inventory
{
    public class SimpleInventory : MonoBehaviour, ICurrentItemProvider
    {

        [SerializeField]
        private Item item;

        public Item GetEquippedItem()
        {
            return item;
        }
    }
}