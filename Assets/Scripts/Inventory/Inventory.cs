using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory
{
    public class Inventory : MonoBehaviour
    {

        private ArrayList _items = new ArrayList();

        [SerializeField]
        private Image select;

        [SerializeField] private Sprite emptySprite;

        [SerializeField] private GameObject hotbar;

        private int _equipped;

        private void Start()
        {
            _items.Add(new Rock());
            _items.Add(new Frisbee());
            _items.Add(new AmericanFlag());
            _items.Add(new WaterGun());
        }

        private void Update()
        {
            DisplayItems();
            TestInput();
            UpdateEquippedSlot();
            if (_items[_equipped] != null && _items[_equipped] is Throwable)
            {
               ((Throwable) _items[_equipped]).DisplayThrowingArc();
            }

            if (Input.GetButtonDown("Fire1") && _items[_equipped] != null)
            {
                Item equipped = (Item) _items[_equipped];
                equipped.UseItem();
            }
        }

        private void DisplayItems()
        {
            for (int i = 0; i < _items.Count; i++)
            {
                try
                {
                    Item equipped = (Item) _items[_equipped];
                    hotbar.transform.GetChild(i).Find("ItemImg").GetComponent<Image>().sprite = equipped.DisplayItem();
                }
                catch (Exception)
                {
                    hotbar.transform.GetChild(i).Find("ItemImg").GetComponent<Image>().sprite = emptySprite;
                }
            }
        }

        private void TestInput()
        {
            for (int i = 0; i < Math.Min(9, _items.Count); i++)
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
            return (Item) _items[_items.Count - 1];
        }

        public void AddItem(Item item)
        {
            _items.Add(item);
        }

        public void RemoveItem(Item item)
        {
            _items.Remove(item);
        }
    }
}