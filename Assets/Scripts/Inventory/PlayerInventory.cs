using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory
{
    public class PlayerInventory : MonoBehaviour, ICurrentItemProvider
    {

        [SerializeField]
        private List<ItemStack> items;

        private GameObject _hotbar;

        private Image select;

        private ItemStack _lastEquipped = null;

        private int _equipped = 0;

        private const int INVENTORY_SIZE = 6;

        private void Start() {
            //RefreshInventory();
            _hotbar = GameObject.Find("UI Canvas").transform.GetChild(0).gameObject;
            select = _hotbar.transform.GetChild(0).GetChild(1).GetComponent<Image>();
            LoadItems();
        }

        private void Update()
        {
            DisplayItems();
            TestInput();
            UpdateEquippedSlot();
            ItemStack equippedItem = GetEquippedItemStack();
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
                _hotbar.transform.GetChild(i).Find("ItemImg").GetComponent<Image>().color = Color.white;
                _hotbar.transform.GetChild(i).Find("ItemImg").GetComponent<Image>().sprite = item.Sprite;
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
            select.transform.SetParent(_hotbar.transform.GetChild(_equipped), false);
        }

        public ItemStack GetEquippedItemStack()
        {
            return items.Count == 0 ? null : items[_equipped];
        }

        public Item GetEquippedItem()
        {
            return GetEquippedItemStack()?.Item;
        }

        public void AddItem(ItemStack itemStack)
        {
            if (items.Count == INVENTORY_SIZE)
            {
                return;
            }
            items.Add(itemStack);
            int newIndex = items.Count-1;

            PlayerPrefs.SetString($"ItemStore{newIndex}", itemStack.Item.name);
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

        private void SaveItems() {
            List<String> itemNames = new List<String>();

            foreach (ItemStack itemArr in items) {
                itemNames.Add(itemArr.Item.name);
            }

            for(int i = 0; i < items.Count; i++) {
                PlayerPrefs.SetString($"ItemStore{i}", itemNames[i]);
            }
        }

        private void LoadItems() {
            // Remember to include amounts some time later Im just lazy rn
            for(int i = 0; i < 6; i++) {
                if(!PlayerPrefs.HasKey($"ItemStore{i}")) {
                    break;
                }
                String store_string = PlayerPrefs.GetString($"ItemStore{i}");
                if (store_string != null)
                {
                    ItemStack stack = new ItemStack(Resources.Load<Item>($"Items/{store_string}"));
                    if (i < items.Count)
                    {
                        items[i] = stack;
                    }
                    else
                    {
                        items.Add(stack);
                    }
                }
            }
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
        }

        public void RefreshInventory() {
            for(int i = 0; i < 6; i++) {
                if(PlayerPrefs.HasKey($"ItemStore{i}")) {
                    PlayerPrefs.DeleteKey($"ItemStore{i}");
                }
            }
        }

        private void OnDestroy()
        {
            SaveItems();
        }
    }
}