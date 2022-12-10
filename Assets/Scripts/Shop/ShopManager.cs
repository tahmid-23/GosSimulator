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

        private PlayerInventory _gosInventory;
        
        [SerializeField]
        private GameObject shopObject;

        private GameObject _npcObject;

        List<GameObject> instantiatedItems = new List<GameObject>();
        
        private ShopEntry _selectedEntry;

        private void Awake()
        {
            _gosInventory = GameObject.FindWithTag("Player").GetComponent<PlayerInventory>();
            _npcObject = GameObject.Find("NPC Canvas");
        }

        public List<GameObject> InstantiateShopItems(List<ShopEntry> shopEntries)
        {
            //_npcObject.GetComponent<Canvas>().enabled = false;
            shopObject.SetActive(true);
            
            instantiatedItems.Clear();

            instantiatedItems = new List<GameObject>();
            
            for (int i = 0; i < shopEntries.Count; i++)
            {
                GameObject shopItemPrefab = Resources.Load<GameObject>("Prefabs/ItemBox");
                GameObject shopItem = Instantiate(shopItemPrefab, transform);
                shopItem.transform.SetSiblingIndex(0);
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
                        canPurchase.transform.GetChild(0).GetComponent<Text>().text = $"Are you sure that you want to purchase this for {entry.Cost} gos coin";
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
            _npcObject.GetComponent<Canvas>().enabled = true;

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
        }

        public void BuyItem()
        {
            HideCanPurchasePopUp();
            // GosCoins.Instance.Coins -= _selectedEntry.Cost;
            // GosCoins.Instance.Cost -= GosCoins.ChangeGosCoins(_selectedEntry.Cost);
            GosCoins.ChangeGosCoins(-_selectedEntry.Cost);
            _gosInventory.AddItem(new ItemStack(_selectedEntry.Item));
            DestroyShopItems(instantiatedItems);
        }
    }
}
