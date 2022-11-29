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
        
        [SerializeField]
        private GameObject shopObject;

        [SerializeField]
        private GameObject npcObject;

        List<GameObject> instantiatedItems = new List<GameObject>();
        
        private ShopEntry _selectedEntry;
        public List<GameObject> InstantiateShopItems(List<ShopEntry> shopEntries)
        {
            npcObject.SetActive(false);
            shopObject.SetActive(true);
            
            instantiatedItems.Clear();

            instantiatedItems = new List<GameObject>();
            
            for (int i = 0; i < shopEntries.Count; i++)
            {
                GameObject shopItemPrefab = Resources.Load<GameObject>("Prefabs/ItemBox");
                GameObject shopItem = Instantiate(shopItemPrefab, transform);
                shopItem.transform.Translate(new Vector3(250 * i, 0, 0));

                ShopEntry entry = shopEntries[i];
                
                SetImage(shopItem, entry.Item.Sprite);
                SetShopItemPrice(shopItem, entry.Cost);
                shopItem.GetComponent<Button>().onClick.AddListener(() =>
                {
                    _selectedEntry = entry;

                    if (entry.Cost > GosCoins.Instance.Coins)
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
            shopObject.SetActive(false);
            npcObject.SetActive(true);

            foreach (GameObject specificItem in items)
            {
                Destroy(specificItem);
            }

            instantiatedItems = new List<GameObject>();
        }

        public void SetImage(GameObject itemBox, Sprite sprite)
        {
            itemBox.transform.Find("Image").GetComponent<Image>().sprite = sprite;
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
            // GosCoins.Instance.Coins -= _selectedEntry.Cost;
            // GosCoins.Instance.Cost -= GosCoins.ChangeGosCoins(_selectedEntry.Cost);
            GosCoins.ChangeGosCoins(_selectedEntry.Cost);
            gosInventory.AddItem(new ItemStack(_selectedEntry.Item));
            DestroyShopItems(instantiatedItems);
        }
    }
}
