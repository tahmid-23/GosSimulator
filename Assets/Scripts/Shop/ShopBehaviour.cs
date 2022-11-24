using System.Collections.Generic;
using UnityEngine;

namespace Shop
{
    public class ShopBehaviour: MonoBehaviour
    {
        [SerializeField]
        private List<ShopEntry> entries = new List<ShopEntry>();
        
        [SerializeField]
        private ShopManager shopManager;

        private List<GameObject> _instantiatedItems;
        private bool _instantiatedBool = false;
        
        public void EnableShop()
        {
            _instantiatedItems = shopManager.InstantiateShopItems(entries);
        }

        public void DisableShop()
        {
            shopManager.DestroyShopItems(_instantiatedItems);
        }

        private void Update()
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