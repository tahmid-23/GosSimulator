using System;
using UnityEngine;

namespace Inventory
{
    [Serializable]
    public class ItemStack
    {

        private ItemStack()
        {
            
        }

        public ItemStack(Item item, int amount = 1)
        {
            Item = item;
            Amount = amount;
        }

        [field: SerializeField]
        public Item Item { get; private set; }

        [field: SerializeField]
        public int Amount { get; set; } = 1;

    }
}