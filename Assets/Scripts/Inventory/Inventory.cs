using System;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
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
            if (items[_equipped] != null && items[_equipped] is Throwable)
            {
               ((Throwable) items[_equipped]).DisplayThrowingArc();
            }

            if (Input.GetButtonDown("Fire1") && items[_equipped] != null)
            {
                Item equipped = items[_equipped];
                equipped.Use();
            }
        }

        private void DisplayItems()
        {
            for (int i = 0; i < items.Count; i++)
            {
                try
                {
                    Item equipped = items[_equipped];
                    hotbar.transform.GetChild(i).Find("ItemImg").GetComponent<Image>().sprite = equipped.DisplaySprite;
                }
                catch (Exception)
                {
                    hotbar.transform.GetChild(i).Find("ItemImg").GetComponent<Image>().sprite = emptySprite;
                }
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

        public Item getEquippedItem()
        {
            return items[_equipped];
        }

        public void AddItem<T>() where T : Item
        {
            items.Add(gameObject.AddComponent<T>());
        }
    }
}