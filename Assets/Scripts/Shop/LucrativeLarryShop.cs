using System;
using System.Collections.Generic;
using Inventory;
using UnityEngine;

namespace Shop
{
    public class LucrativeLarryShop: ShopBase
    {
        public LucrativeLarryShop()
        {
            
        }

        private void Start()
        {
            AddItem(new StackedItem(1, "flag", 50, "American Flag"));
            AddItem(new StackedItem(1, "watergun",500, "Water Gun"));
            
        }
    }
}