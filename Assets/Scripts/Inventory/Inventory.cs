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

        [SerializeField] private Sprite emptySprite;

        [SerializeField] private GameObject hotbar;

        private int _equipped;

        private void Start()
        {
            _items[1] = new Rock();
            _items[2] = new Frisbee();
            _items[3] = new AmericanFlag();
            _items[4] = new WaterGun();
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
                _items[_equipped].UseItem();
            }
        }

        private void DisplayItems()
        {
            for (int i = 0; i < _items.Length; i++)
            {
                try
                {
                    hotbar.transform.GetChild(i).Find("ItemImg").GetComponent<Image>().sprite = _items[i].DisplayItem();
                }
                catch (Exception)
                {
                    hotbar.transform.GetChild(i).Find("ItemImg").GetComponent<Image>().sprite = emptySprite;
                }
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
            select.transform.SetParent(hotbar.transform.GetChild(_equipped), false);
        }

        public Item getEquippedItem()
        {
            return _items[_equipped];
        }
    }
}