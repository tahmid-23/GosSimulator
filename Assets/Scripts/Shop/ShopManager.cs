using System;
using System.Collections.Generic;
using Currency;
using Inventory;
using UnityEngine;
using UnityEngine.UI;

namespace Shop
{
    public class ShopManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject cannotPurchase;

        [SerializeField]
        private GameObject canPurchase;

        [SerializeField]
        private PlayerInventory gosInventory;
        
        List<GameObject> instantiatedItems = new List<GameObject>();
        
        private KeyValuePair<String, double> _selectedItem;
        public List<GameObject> InstantiateShopItems(List<StackedItem> items)
        {
            instantiatedItems = new List<GameObject>();
            
            for (int i = 0; i < items.Count; i++)
            {
                GameObject shopItemPrefab = Resources.Load<GameObject>("Prefabs/ItemBox");
                GameObject shopItem = Instantiate(shopItemPrefab, transform);
                shopItem.transform.Translate(new Vector3(250 * i, 0, 0));

                StackedItem item = items[i];
                
                SetImage(shopItem, item.GetSprite());
                SetShopItemPrice(shopItem, item.GetCost());
                shopItem.GetComponent<Button>().onClick.AddListener(() =>
                {
                    _selectedItem = new KeyValuePair<string, double>(item.GetDisplayName(), item.GetCost());

                    if (item.GetCost() > MakeThisASingleton.GetCosCoins())
                    {
                        cannotPurchase.SetActive(true);
                    }
                    else
                    {
                        canPurchase.SetActive(true);
                    }
                });

                instantiatedItems.Add(shopItem);
            }

            return instantiatedItems;
        }

        public void DestroyShopItems(List<GameObject> items)
        {
            foreach (GameObject specificItem in items)
            {
                Destroy(specificItem);
            }

            instantiatedItems = new List<GameObject>();
        }

        public void SetImage(GameObject itemBox, String sprite)
        {
            itemBox.transform.Find("Image").GetComponent<Image>().sprite = Resources.Load<Sprite>($"Sprites/{sprite}");
        }

        public void SetShopItemPrice(GameObject itemBox, double price)
        {
            itemBox.transform.Find("Cost").GetComponent<Text>().text = $"Cost:{price}";
        }

        public void HideCannotPurchasePopUp()
        {
            transform.Find("CannotPurchase").gameObject.SetActive(false);
        }

        public void HideCanPurchasePopUp()
        {
            transform.Find("CanPurchase").gameObject.SetActive(false);
            MakeThisASingleton.ChangeGosCoins(-1 * _selectedItem.Value);
            gosInventory.LookUpAndAdd(_selectedItem.Key);
            DestroyShopItems(instantiatedItems);
        }
    }
}