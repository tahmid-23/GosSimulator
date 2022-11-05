using System;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory
{
    public class Inventory : MonoBehaviour
    {
        private Item[] _items = new Item[6];
        private int _equipped = 0;
        public Image select;

        private void Update()
        {
            DisplayItems();
            TestInput();
            UpdateEquippedSlot();
        }

        private void DisplayItems()
        {
            foreach (Item i in _items)
            {
                i?.DisplayItem();
            }
        }

        private void TestInput()
        {
            if (Input.GetKeyDown("1"))
            {
                _equipped = 0;
            }
            if (Input.GetKeyDown("2"))
            {
                _equipped = 1;
            }
            if (Input.GetKeyDown("3"))
            {
                _equipped = 2;
            }
            if (Input.GetKeyDown("4"))
            {
                _equipped = 3;
            }
            if (Input.GetKeyDown("5"))
            {
                _equipped = 4;
            }
            if (Input.GetKeyDown("6"))
            {
                _equipped = 5;
            }
        }

        private void UpdateEquippedSlot()
        {
            select.transform.SetParent(transform.GetChild(_equipped), false);
        }
    }
}