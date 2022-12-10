using System;
using System.IO;
using Inventory;
using NPCData;
using UnityEngine;
using UnityEngine.SceneManagement;

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

            if (SceneManager.GetActiveScene().name.Equals("First Scene"))
            {
                PlayerPrefs.SetInt("JPConversation", 2);
                SetDialogue(_dialogueFile, 2);
            }
            if(PlayerPrefs.GetInt("JPConversation") == 2) {
                if(_gosInventory.HasItem("Test Answers")) {
                    PlayerPrefs.SetInt("JPConversation", 3);
                    SetDialogue("JPIntro", 3);
                    PlayerPrefs.SetInt("BeisenburgConversation", 2);
                }
            }
        }
        
        protected override void BetweenInteractions()
        {
            if (_interactionID == 1)
            {
                if (_currentInteractionIndex == 9)
                {
                    PlayerPrefs.SetString("CurrentScene", "First Scene");
                    SceneManager.LoadScene("First Scene");
                }
            }
            if(base._interactionID == 3) {
                if(_currentInteractionIndex == 0) {
                   _gosInventory.RemoveItem("Test Answers");
                }
            } 
        }
    }
}