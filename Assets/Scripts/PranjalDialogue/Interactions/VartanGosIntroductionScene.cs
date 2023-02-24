using System;
using System.Collections.Generic;
using Dialogue;
using UnityEngine;

namespace PranjalDialogue.Interactions
{
    public class VartanGosIntroductionScene : IInteraction
    {
        public DialogueBroker dialogueBroker;
        
        private int _currentInteractionIndex = -1;
        private Conversation _currentConversation = JSONDialogueParser.GetDialogueByID("BeisenburgIntro", 2);

        public VartanGosIntroductionScene()
        {
            
        }

        public String NextInteraction(Dictionary<String, String> parameters)
        {
            _currentInteractionIndex++;
            Debug.Log(_currentConversation);
            List<string> dialogueList = _currentConversation.GetFields();
            Debug.Log(dialogueList);

            foreach (String var in dialogueList)
            {
                Debug.Log(var);
            }

            if (_currentInteractionIndex >= dialogueList.Count)
            {
                if (_currentConversation.GetResponses().Count > 0)
                {
                    dialogueBroker.GenerateResponses(_currentConversation, 2);
                }
                else
                {
                    dialogueBroker.ChangeInteractionState();
                }
                return "";
            }

            // _npcSpeech.text = dialogueList[_currentInteractionIndex];
            return dialogueList[_currentInteractionIndex];
        }
    }
}