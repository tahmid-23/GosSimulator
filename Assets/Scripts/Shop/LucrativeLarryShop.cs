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
            // For now we need to create a sprite for this
            AddItem(new StackedItem(1, "testanswers", 200, "Beisenburg Test Answers"));
        }
    }
}