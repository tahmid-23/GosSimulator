using System;
using Inventory;
using UnityEngine;

namespace NPC
{
    public class JP: NPCBase
    {
        public bool rockGiven = false;
        
        public JP() : base(Classification.Ally, 100, 10)
        {
            
        }

        private void OnMouseDown()
        {
            Inventory.Inventory gosInventory = GameObject.Find("Gos").GetComponent<Inventory.Inventory>();
            
            Debug.Log("Hi my name is Clown P and I'm a massive circus");

            if (!rockGiven)
            {
                
                Debug.Log("Hey let me give you something");
                Debug.Log("You have been given a rock");
                gosInventory.AddItem(new Rock());
            }
        }
    }
}