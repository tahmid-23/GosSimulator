using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory
{
    public class PlayerInventory : MonoBehaviour
    {

        [SerializeField]
        private List<ItemStack> items;

        [SerializeField]
        private GameObject hotbar;

        [SerializeField]
        private Image select;

        private ItemStack _lastEquipped = null;

        private int _equipped = 0;

        private void Update()
        {
            DisplayItems();
            TestInput();
            UpdateEquippedSlot();
            ItemStack equippedItem = GetEquippedItem();
            if (equippedItem != _lastEquipped)
            {
                _lastEquipped?.Item.Unequip(gameObject);
                equippedItem?.Item.Equip(gameObject);
            }
            if (equippedItem != null && Input.GetButtonDown("Fire1"))
            {
                equippedItem.Item.Use(gameObject);
            }

            _lastEquipped = equippedItem;
        }

        private void DisplayItems()
        {
            for (int i = 0; i < items.Count; i++)
            {
                Item item = items[i].Item;
                hotbar.transform.GetChild(i).Find("ItemImg").GetComponent<Image>().color = Color.white;
                hotbar.transform.GetChild(i).Find("ItemImg").GetComponent<Image>().sprite = item.Sprite;
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

        public ItemStack GetEquippedItem()
        {
            return items.Count == 0 ? null : items[_equipped];
        }

        public void AddItem(ItemStack itemStack)
        {
            items.Add(itemStack);
        }

        public bool HasItem(String itemName)
        {
            List<String> itemNames = new List<string>();
            
            foreach(ItemStack itemArr in items)
            {
                itemNames.Add(itemArr.Item.name);
            }

            foreach (String nameArr in itemNames)
            {
                if (nameArr.Equals(itemName))
                {
                    return true;
                }  
            }

            return false;
        }

        public void RemoveItem(String itemName) {
            List<String> itemNames = new List<String>();

            foreach (ItemStack itemArr in items){
                itemNames.Add(itemArr.Item.name);
            }

            int i = 0;

            foreach (String nameArr in itemNames)
            {
                if (nameArr.Equals(itemName))
                {    
                    break;
                }

                i++;
            }

            items.RemoveAt(i);
        }
    }
}