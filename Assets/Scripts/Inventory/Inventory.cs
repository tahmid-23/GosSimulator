using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory
{
    public class Inventory : MonoBehaviour
    {

        [SerializeField]
        private List<Item> items;

        [SerializeField]
        private GameObject hotbar;

        [SerializeField]
        private Image select;

        [SerializeField]
        private Sprite emptySprite;

        private int _equipped;

        private void Update()
        {
            DisplayItems();
            TestInput();
            UpdateEquippedSlot();
            Item equippedItem = GetEquippedItem();
            if (items[_equipped] != null)
            {
               equippedItem.VisualUpdate();
            }

            if (Input.GetButtonDown("Fire1"))
            {
                equippedItem.Use();
            }
        }

        private void DisplayItems()
        {
            for (int i = 0; i < items.Count; i++)
            {
                Item item = items[i];
                hotbar.transform.GetChild(i).Find("ItemImg").GetComponent<Image>().sprite = item.DisplaySprite;
            }
        }

        private void TestInput()
        {
            for (int i = 0; i < Math.Min(9, items.Count); i++)
            {
                int key = i + 1;
                if (key == 10)
                {
                    key = 0;
                }

                if (Input.GetKeyDown(key.ToString()))
                {
                    _equipped = i;
                    break;
                }
            }
        }

        private void UpdateEquippedSlot()
        {
            select.transform.SetParent(hotbar.transform.GetChild(_equipped), false);
        }

        public Item GetEquippedItem()
        {
            return items[_equipped];
        }

        public void AddItem<T>() where T : Item
        {
            items.Add(gameObject.AddComponent<T>());
        }
    }
}