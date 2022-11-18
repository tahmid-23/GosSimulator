using System;
using Dialogue;
using Inventory;
using UnityEngine;

namespace NPC
{
    public class JPDialogue: NPCBase
    {
        public JPDialogue() : base(Classification.Ally, 100, 10, 1, "JPIntro")
        {
            
        }

        private void OnMouseDown()
        {
            PlayerInventory gosInventory = GameObject.Find("Gos").GetComponent<PlayerInventory>();
        }

        protected override void BetweenInteractions()
        {
            throw new NotImplementedException();
        }
    }
}