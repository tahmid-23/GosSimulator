using System.Collections.Generic;
using Inventory;
using UnityEngine;

namespace Shop
{
    public class ShopBase: MonoBehaviour
    {
        private List<StackedItem> _item;

        [SerializeField] 
        private GameObject shopBackground;

        protected void EnableShop()
        {
            shopBackground.SetActive(false);
        }

        protected void DisableShop()
        {
            shopBackground.SetActive(true);
        }
    }
}