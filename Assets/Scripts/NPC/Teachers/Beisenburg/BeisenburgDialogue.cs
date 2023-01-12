using System;
using System.IO;
using Inventory;
using NPCData;
using UnityEngine;
using Gos;
using UnityEngine.SceneManagement;

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
            if(_interactionID == 2 && _currentInteractionIndex == 4) {
                _gosInventory.AddItem(new ItemStack(Resources.Load<Item>("Items/Staining Solution")));
            }

            if (_interactionID == 3 && _currentInteractionIndex == 3)
            {
                SceneManager.LoadScene("TitleScreen");
            }
        }

        void Start() {
            base.Start();
            Debug.Log("Hello");
            _gosInventory = GameObject.FindWithTag("Player").GetComponent<PlayerInventory>();
            base.SetStatus("BeisenburgConversation", "BeisenburgIntro");
            if(PlayerPrefs.GetInt("JPConversation") == 2) {
                if(_gosInventory.HasItem("Test Answers")) {
                    PlayerPrefs.SetInt("JPConversation", 3);
                    SetDialogue(_dialogueFile, 2);
                    PlayerPrefs.SetInt("BeisenburgConversation", 2);
                }
            }
            if(PlayerPrefs.GetInt("BeisenburgConversation") == 2) {
                if(_gosInventory.HasItem("Janitor Closet Flask")) {
                    PlayerPrefs.SetInt("BeisenburgConversation", 3);
                    SetDialogue(_dialogueFile, 3);
                }
            }
        }
    }
}