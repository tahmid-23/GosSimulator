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
            base.SetStatus("JPConversation", "JPIntro");
        
            // Remove these 2 lines when done testing
            PlayerPrefs.SetInt("JPConversation", 1);
            PlayerPrefs.SetInt("BeisenburgConversation", 1);

            if(PlayerPrefs.GetInt("JPConversation") == 1) {
                if(gosInventory.HasItem("Test Answers")) {
                    Debug.Log("Cope and seethe");
                    PlayerPrefs.SetInt("JPConversation", 2);
                    SetDialogue("JPIntro", 2);
                    PlayerPrefs.SetInt("BeisenburgConversation", 2);
                }
            }
        }
        
        protected override void BetweenInteractions()
        {
            if(base._interactionID == 2) {
                if(_currentInteractionIndex == 0) {
                   gosInventory.RemoveItem("Test Answers");
                }
            } 
        }
    }
}