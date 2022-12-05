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
        [SerializeField]
        private PlayerInventory gosInventory;

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
                gosInventory.AddItem(new ItemStack(Resources.Load<Item>("Items/Test Answers")));
            }
        }

        void Start() {
            base.Start();
            base.SetStatus("BeisenburgConversation", "BeisenburgIntro");
        }
    }
}