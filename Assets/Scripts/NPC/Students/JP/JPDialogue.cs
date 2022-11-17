using System;
using Dialogue;
using Inventory;
using UnityEngine;

namespace NPC
{
    public class JPDialogue: NPCBase
    {
        public bool rockGiven = false;

        void Start()
        {
            
        }
        
        public JPDialogue() : base(Classification.Ally, 100, 10)
        {
            
        }

        private void OnMouseDown()
        {
            PlayerInventory gosInventory = GameObject.Find("Gos").GetComponent<PlayerInventory>();
            
            Debug.Log("Hi my name is Jester P and I'm a massive circus");

            if (!rockGiven)
            {
                
                Debug.Log("Hey let me give you something cuz Im a Jester");
                Debug.Log("You have been given a rock");
                gosInventory.AddItem<Rock>();
            }
        }
    }
}