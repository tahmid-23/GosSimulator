using System.Collections.Generic;
using Inventory;
using UnityEngine;

namespace Shop
{
    public abstract class ShopBase: MonoBehaviour
    {
        private List<StackedItem> _stackedItems = new List<StackedItem>();
        
        [SerializeField]
        private ShopManager shopManager;

        private List<GameObject> _instantiatedItems;
        private bool _instantiatedBool = false;
        
        public void EnableShop()
        {
            _instantiatedItems = shopManager.InstantiateShopItems(_stackedItems);
        }

        public void DisableShop()
        {
            shopManager.DestroyShopItems(_instantiatedItems);
        }

        protected void AddItem(StackedItem item)
        {
            _stackedItems.Add(item);
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                if (!_instantiatedBool)
                {
                    EnableShop();
                    _instantiatedBool = true;
                }
            }

            if (Input.GetKeyDown(KeyCode.L))
            {
                if (_instantiatedBool)
                {
                    DisableShop();
                    _instantiatedBool = false;
                }
            }
        }
    }
}