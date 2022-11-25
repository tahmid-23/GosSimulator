using System;
using System.IO;
using Inventory;
using NPCData;
using UnityEngine;

namespace NPC.Students.JP
{
    public class JPDialogue: NPCBase
    {
        public JPDialogue() : base(Classification.Ally, 100, 10)
        {
            string path = Application.persistentDataPath + "/JP.npc";
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