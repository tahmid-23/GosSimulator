using System;
using System.IO;
using Inventory;
using NPCData;
using UnityEngine;

namespace NPC.Students.JP
{
    public class JPDialogue: NPCBase
    {
        [SerializeField]
        private PlayerInventory gosInventory;
        
        public JPDialogue() : base(Classification.Ally, 100, 10)
        {

        }

        void Awake()
        {
            base.Awake();
            // This will cause issues and remove this
            // All this does is sets it to 1 for testing purposes
            SetDialogue("JPIntro", 1);
            if (!PlayerPrefs.HasKey("JPConversation"))
            {
                PlayerPrefs.SetInt("JPConversation", 1);
                SetDialogue("JPIntro", 1);
            }
            else
            {
                SetDialogue("JPIntro", PlayerPrefs.GetInt("JPConversation"));
            }
        
            if(PlayerPrefs.GetInt("JPConversation") == 1) {
                if(gosInventory.HasItem("Test Answers")) {
                    PlayerPrefs.SetInt("JPConversation", 2);
                    SetDialogue("JPIntro", 2);
                }
            }
        }
        
        protected override void BetweenInteractions()
        {
            // if(base._interactionID == 2) {
            //     if(_currentConversationIndex == 0) {
            //        gosInventory.RemoveItem("Test Answers");
            //     }
            // } 
        }
    }
}