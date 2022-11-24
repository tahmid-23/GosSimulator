using System;
using Inventory;
using UnityEngine;

namespace Shop
{
    [Serializable]
    public class ShopEntry
    {
        
        [field: SerializeField]
        public Item Item { get; private set; }
        
        [field: SerializeField]
        public int Cost { get; private set; }
        
        [field: SerializeField]
        public string DisplayName { get; private set; }
        
    }
}