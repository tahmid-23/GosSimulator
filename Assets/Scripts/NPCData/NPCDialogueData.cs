using System;
using UnityEngine;

namespace NPCData
{
    [System.Serializable]
    public class NPCDialogueData
    {
        private int _conversationID = 1;
        private String _dialogueFile = "JPIntro";

        public NPCDialogueData(String dialogueFile, int conversationID)
        {
            this._conversationID = conversationID;
            this._dialogueFile = dialogueFile;
        }

        public void SetInteractionID(String dialogueFile, int conversationID)
        {
            this._dialogueFile = dialogueFile;
            this._conversationID = conversationID;
        }

        public int GetConversationID()
        {
            return _conversationID;
        }

        public String GetDialogueFile()
        {
            return _dialogueFile;
        }
    }
}