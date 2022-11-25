using System;
using System.IO;
using Dialogue;
using Inventory;
using NPCData;
using UnityEngine;

namespace NPC
{
    public class JPDialogue: NPCBase
    {
        public JPDialogue() : base(Classification.Ally, 100, 10)
        {
            String path = Application.persistentDataPath + "/JP.npc";
            if (!File.Exists(path))
            {
                SaveNPCDialogue.SaveDialogue(new NPCDialogueData("JPIntro", 1), path);
                SetDialogue("JPIntro", 1);
            }
            else
            {
                NPCDialogueData dialogueData = SaveNPCDialogue.LoadNPCDialogue(path);
                SetDialogue(dialogueData.GetDialogueFile(), dialogueData.GetConversationID());
            }
        }

        private void OnMouseDown()
        {
            PlayerInventory gosInventory = GameObject.Find("Gos").GetComponent<PlayerInventory>();
        }

        protected override void BetweenInteractions()
        {
            
        }
    }
}