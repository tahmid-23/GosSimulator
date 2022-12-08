using System;
using System.IO;
using Inventory;
using NPCData;
using UnityEngine;

namespace NPC.Students.JP
{
    public class JPDialogue: NPCBase
    {
        private PlayerInventory _gosInventory;
        
        public JPDialogue() : base(Classification.Ally, 100, 10)
        {

        }

        void Start()
        {
            _gosInventory = GameObject.Find("Player").GetComponent<PlayerInventory>();
            base.Start();
            base.SetStatus("JPConversation", "JPIntro");
        
            // Remove these 2 lines when done testing
            PlayerPrefs.SetInt("JPConversation", 1);
            PlayerPrefs.SetInt("BeisenburgConversation", 1);

            if(PlayerPrefs.GetInt("JPConversation") == 1) {
                if(_gosInventory.HasItem("Test Answers")) {
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
                   _gosInventory.RemoveItem("Test Answers");
                }
            } 
        }
    }
}