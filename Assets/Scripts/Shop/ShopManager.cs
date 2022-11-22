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
            
            // GameObject shopItemPrefab = Resources.Load<GameObject>("Prefabs/ItemBox");
            // GameObject shopItem = Instantiate(shopItemPrefab, transform);
            // shopItem.transform.Translate(new Vector3(0, 0, 0));
            //     
            // SetImage(shopItem, "flag");
            // SetShopItemPrice(shopItem, 50);
        }

        public List<GameObject> InstantiateShopItems(List<StackedItem> items)
        {
            List<GameObject> instantiatedItems = new List<GameObject>();
            
            for (int i = 0; i < items.Count; i++)
            {
                GameObject shopItemPrefab = Resources.Load<GameObject>("Prefabs/ItemBox");
                GameObject shopItem = Instantiate(shopItemPrefab, transform);
                shopItem.transform.Translate(new Vector3(50 * i, 0, 0));
                
                SetImage(shopItem, items[i].GetSprite());
                SetShopItemPrice(shopItem, items[i].GetCost());
                
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