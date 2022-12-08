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
        private static GameObject _npcUI;
        private static GameObject _speechPanel;
        private static Text _npcSpeech;
        private static Button[] _responseButtons = new Button[3];
        private static bool uiSetupCompleted = false;
        private bool _interactable;
        private bool _interacting;
        private Conversation _currentConversation;
        protected int _currentInteractionIndex;
        protected bool _ableToMoveOn = true;
        
        //these should be set by a subclass (aka specfic npc class)
        protected int _interactionID;
        protected string _dialogueFile;
        //you should be able to change these as you like in the subclass
        //for example if after one interaction you want to update the id to a conversation
        //you can do that in the subclass

        protected NPCBase(Classification classification, float hp, int schoolbookFollowers, int interactionID, string dialogueFile)
        {
            _classification = classification;
            _hp = hp;
            _schoolbookFollowers = schoolbookFollowers;
            _interactionID = interactionID;
            _dialogueFile = dialogueFile;
        }
        
        protected NPCBase(Classification classification, float hp, int schoolbookFollowers)
        {
            _classification = classification;
            _hp = hp;
            _schoolbookFollowers = schoolbookFollowers;
        }

        public float GetHP()
        {
            return _hp;
        }

        public void ChangeSchoolbookFollowers(int delta)
        {
            _schoolbookFollowers += delta;
        }

        protected void Start()
        {
            _speechBubble = transform.Find("Speech Bubble").gameObject;
            if (!uiSetupCompleted) {
                _npcUI = GameObject.Find("NPC Canvas");
                _speechPanel = _npcUI.transform.Find("Speech Panel").gameObject;
                _npcSpeech = _speechPanel.transform.Find("Text (Legacy)").GetComponent<Text>();
                for (int i = 0; i < _responseButtons.Length; i++)
                {
                    _responseButtons[i] = _npcUI.transform.Find("Response " + (i+1)).GetComponent<Button>();
                    _responseButtons[i].gameObject.SetActive(false);
                }
                _npcUI.GetComponent<Canvas>().enabled = false;
                uiSetupCompleted = true;
            }
            _gosUI = GameObject.Find("UI Canvas");
        }

        private void Update()
        {
            _speechBubble.SetActive(_interactable);

            if (_ableToMoveOn)
            {
                if (_interacting && Input.GetKeyDown(KeyCode.Space))
                {
                    NextInteraction();
                }
                else if (_interactable && Input.GetKeyDown(KeyCode.Space))
                {
                    ChangeInteractionState();
                    Interact();
                }
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
            foreach (Button b in _responseButtons)
            {
                b.gameObject.SetActive(false);
            }

            _speechPanel.SetActive(true);
            _currentConversation = JSONDialogueParser.GetDialogueByID(_dialogueFile, _interactionID);
            _currentInteractionIndex = -1;
            NextInteraction();
        }

        private void NextInteraction()
        {
            BetweenInteractions();

            _currentInteractionIndex++;
            List<string> dialogueList = _currentConversation.GetFields();
            if (_currentInteractionIndex >= dialogueList.Count)
            {
                if (_currentConversation.GetResponses().Count > 0)
                {
                    GenerateResponses();
                }
                else
                {
                    ChangeInteractionState();
                }
                return;
            }

            _npcSpeech.text = dialogueList[_currentInteractionIndex];
        }

        private void GenerateResponses()
        {
            List<Response> responses = _currentConversation.GetResponses();
            _speechPanel.SetActive(false);
            for (int i = 0; i < Math.Min(responses.Count, _responseButtons.Length); i++)
            {
                Button b = _responseButtons[i];
                Response r = responses[i];
                b.GetComponentInChildren<Text>().text = r.getResponseText();
                b.onClick.AddListener(() =>
                {
                    _interactionID = r.getGoToID();
                    Interact();
                });
                _responseButtons[i].gameObject.SetActive(true);
            }
        }

        private void ChangeInteractionState()
        {
            //flip the state of interaction
            _interacting = !_interacting;
            //if the interaction is taking place, gosUI should be inactive
            _gosUI.SetActive(!_interacting);
            //if the interaction is taking place, npcUI should be active
            _npcUI.GetComponent<Canvas>().enabled = _interacting;
        }

        protected void PreventDialogue()
        {
            _ableToMoveOn = false;
        }

        protected void AllowDialogue()
        {
            _ableToMoveOn = true;
        }

        protected void SetConversationID(int id) {
            this._interactionID = id;
        }

        protected void SetDialogue(String filename, int interaction)
        {
            this._dialogueFile = filename;
            this._interactionID = interaction;
        }

        protected void SetStatus(String conversationID, String filename) {
            if (!PlayerPrefs.HasKey(conversationID))
            {
                PlayerPrefs.SetInt(conversationID, 1);
                SetDialogue(filename, 1);
            }
            else
            {
                SetDialogue(filename, PlayerPrefs.GetInt(conversationID));
            }
        }

        protected abstract void BetweenInteractions();
    }
}