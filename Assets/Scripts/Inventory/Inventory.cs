using System;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory
{
    public class Inventory : MonoBehaviour
    {

        private readonly Item[] _items = new Item[6];

        [SerializeField]
        private Image select;

        private int _equipped;

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
            for (int i = 0; i < Math.Min(9, _items.Length); i++)
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
            select.transform.SetParent(transform.GetChild(_equipped), false);
        }
    }
}