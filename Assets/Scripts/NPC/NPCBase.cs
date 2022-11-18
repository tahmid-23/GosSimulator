using System;
using System.Collections.Generic;
using Dialogue;
using UnityEngine;
using UnityEngine.UI;

namespace NPC
{
    public abstract class NPCBase: MonoBehaviour
    {
        private Classification _classification;
        private float _hp;
        private int _schoolbookFollowers;
        private GameObject _speechBubble;
        private GameObject _gosUI;
        private GameObject _npcUI;
        private GameObject _gos;
        private Text _npcSpeech;
        private bool _interactable;
        private bool _interacting;
        private List<String> _currentConversation;
        protected int _currentInteractionIndex;
        
        //these should be set by a subclass (aka specfic npc class)
        protected int _interactionID;
        protected String _dialogueFile;
        //you should be able to change these as you like in the subclass
        //for example if after one interaction you want to update the id to a conversation
        //you can do that in the subclass

        protected NPCBase(Classification classification, float hp, int schoolbookFollowers, int interactionID, String dialogueFile)
        {
            _classification = classification;
            _hp = hp;
            _schoolbookFollowers = schoolbookFollowers;
            _interactionID = interactionID;
            _dialogueFile = dialogueFile;
        }

        public float GetHP()
        {
            return _hp;
        }

        public void ChangeSchoolbookFollowers(int delta)
        {
            _schoolbookFollowers += delta;
        }

        public void Start()
        {
            _speechBubble = transform.Find("Speech Bubble").gameObject;
            _gosUI = GameObject.Find("UI Canvas");
            _npcUI = GameObject.Find("NPC Canvas");
            _npcSpeech = _npcUI.transform.Find("Panel").Find("Text (Legacy)").GetComponent<Text>();
            _npcUI.SetActive(false);
            _gos = GameObject.Find("Player");
        }

        public void Update()
        {
            _speechBubble.SetActive(_interactable);
           if (_interacting && Input.GetKeyDown(KeyCode.Space))
            {
                NextInteraction();
            }
            else if (_interactable && Input.GetKeyDown(KeyCode.Space))
            {
                Interact();
            }
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                _interactable = true;
            }
        }

        public void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                _interactable = false;
            }
        }

        private void Interact()
        {
            ChangeInteractionState();
            _currentConversation = JSONDialogueParser.GetDialogueByID(_dialogueFile, _interactionID).GetFields();
            _currentInteractionIndex = -1;
            NextInteraction();
        }

        private void NextInteraction()
        {
            BetweenInteractions();
            
            _currentInteractionIndex++;
            if (_currentInteractionIndex == _currentConversation.Count)
            {
                ChangeInteractionState();
                return;
            }

            _npcSpeech.text = _currentConversation[_currentInteractionIndex];
        }

        private void ChangeInteractionState()
        {
            //flip the state of interaction
            _interacting = !_interacting;
            //if the interaction is taking place, gosUI should be inactive
            _gosUI.SetActive(!_interacting);
            //if the interaction is taking place, npcUI should be active
            _npcUI.SetActive(_interacting);
        }

        protected abstract void BetweenInteractions();
    }
}