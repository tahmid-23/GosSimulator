using System;
using System.IO;
using Inventory;
using NPCData;
using UnityEngine;
using Gos;

namespace NPC.Teachers.Beisenburg
{
    public class BeisenburgDialogue: NPCBase
    {
        private PlayerInventory _gosInventory;

        public BeisenburgDialogue() : base(Classification.Neutral, 100, 10, 1, "BeisenburgIntro")
        {
            
        }

        protected override void BetweenInteractions()
        {
            Debug.Log(_currentInteractionIndex);
            if(_currentInteractionIndex == 0) {
                base.SetConversationID(PlayerPrefs.GetInt("BeisenburgConversation"));
            }

            else if(_currentInteractionIndex == 4) {
                _gosInventory.AddItem(new ItemStack(Resources.Load<Item>("Items/Staining Solution")));
            }
        }

        void Start() {
            base.Start();
            _gosInventory = GameObject.FindWithTag("Player").GetComponent<PlayerInventory>();
            base.SetStatus("BeisenburgConversation", "BeisenburgIntro");
        }
    }
}