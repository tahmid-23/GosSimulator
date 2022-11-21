using System;
using System.Collections.Generic;
using Inventory;
using UnityEngine;
using UnityEngine.UI;

namespace Shop
{
    public class ShopManager : MonoBehaviour
    {
        void Start()
        {
            // SetImage(Resources.Load<Sprite>("Sprites/speech_bubble"));
            // SetShopItemPrice(new ShopItemPrice(50));
            // Debug.Log(gameObject.name);
            
            GameObject shopItemPrefab = Resources.Load<GameObject>("Prefabs/ItemBox");
            GameObject shopItem = Instantiate(shopItemPrefab, transform);
            shopItem.transform.Translate(new Vector3(0, 0, 0));
                
            SetImage(shopItem, "flag");
            SetShopItemPrice(shopItem, 50);
            
        }

        public void InstantiateItems(List<StackedItem> items)
        {
            for (int i = 0; i < items.Count; i++)
            {
                GameObject shopItemPrefab = Resources.Load<GameObject>("Prefabs/ItemBox");
                GameObject shopItem = Instantiate(shopItemPrefab, transform);
                shopItem.transform.Translate(new Vector3(50 * i, 0, 0));
                
                SetImage(shopItem, items[i].GetSprite());
                SetShopItemPrice(shopItem, items[i].GetCost());
            }
        }

        public void SetImage(GameObject itemBox, String sprite)
        {
            itemBox.transform.Find("Image").GetComponent<Image>().sprite = Resources.Load<Sprite>($"Sprites/{sprite}");
        }

        public void SetShopItemPrice(GameObject itemBox, double price)
        {
            itemBox.transform.Find("Cost").GetComponent<Text>().text = $"Cost:{price}";
        }
    }
}