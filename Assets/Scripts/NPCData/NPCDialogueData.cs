using System;
using UnityEngine;

namespace NPCData
{
    [System.Serializable]
    public class NPCDialogueData
    {
        private int _conversationID = 1;
        private string _dialogueFile = "JPIntro";

        public NPCDialogueData(string dialogueFile, int conversationID)
        {
            this._conversationID = conversationID;
            this._dialogueFile = dialogueFile;
        }

        public void SetInteractionID(string dialogueFile, int conversationID)
        {
            this._dialogueFile = dialogueFile;
            this._conversationID = conversationID;
        }

        public int GetConversationID()
        {
            return _conversationID;
        }

        public string GetDialogueFile()
        {
            return _dialogueFile;
        }
    }
}