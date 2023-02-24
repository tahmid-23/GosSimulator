using System;
using System.Collections.Generic;
using Dialogue;
using Gos;
using PranjalDialogue.Interactions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace PranjalDialogue
{
    public class DialogueBroker : MonoBehaviour
    {
        private static GameObject _npcUI;
        private static GameObject _speechPanel;
        private static Text _npcSpeech;
        private static Button[] _responseButtons = new Button[3];
        private static bool uiSetupCompleted = false;
        private bool _interactable = true;
        private bool _interacting = true;
        private bool _ableToMoveOn = true;

        private IInteraction _interaction;
        
        protected void Start()
        {
            this._interaction = new VartanGosIntroductionScene();
            _interactable = true;
            // _speechBubble = transform.Find("Speech Bubble").gameObject;
            if (!uiSetupCompleted)
            {
                _npcUI = Instantiate(Resources.Load<GameObject>("Prefabs/NPC Canvas"),new Vector3(0, 0, 0), Quaternion.identity);
                _speechPanel = _npcUI.transform.Find("Speech Panel").gameObject;
                // _speechPanel = Instantiate(Resources.Load<GameObject>("Prefabs/Speech Panel"), transform.position, Quaternion.identity);
                _npcSpeech = _speechPanel.transform.Find("Text (Legacy)").GetComponent<Text>();
                _speechPanel.SetActive(false);
                for (int i = 0; i < _responseButtons.Length; i++)
                {
                    _responseButtons[i] = _npcUI.transform.Find("Response " + (i+1)).GetComponent<Button>();
                    _responseButtons[i].gameObject.SetActive(false);
                }
                _npcUI.GetComponent<Canvas>().enabled = false;
                uiSetupCompleted = true;
            }
            
            ChangeInteractionState();
            Interact();
        }
        
        private void Update()
        {
            if (_ableToMoveOn)
            {
                if (_interacting && Input.GetKeyDown(KeyCode.Space))
                {
                    _npcSpeech.text = _interaction.NextInteraction(new Dictionary<string, string>());
                }
                else if (_interactable && Input.GetKeyDown(KeyCode.Space))
                {
                    if (SceneManager.GetActiveScene().name.Equals("Tutorial"))
                    {
                        GameObject.Find("NPC Tutorial")?.SetActive(false);
                    }
                    ChangeInteractionState();
                    Interact();
                }
            }
        }

        private void Interact()
        {
            foreach (Button b in _responseButtons)
            {
                b.gameObject.SetActive(false);
            }

            _speechPanel.SetActive(true);
            _npcSpeech.text = _interaction.NextInteraction(new Dictionary<string, string>());
        }
        
        public void GenerateResponses(Conversation _currentConversation, int _interactionID)
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

        public void ChangeInteractionState()
        {
            //flip the state of interaction
            // _interacting = !_interacting;
            //if the interaction is taking place, npcUI should be active
            _npcUI.GetComponent<Canvas>().enabled = _interacting;
            // GameObject.Find("Player").GetComponent<GosMovement>().locked = _interacting;
        }

        private void SetInteraction(IInteraction interaction)
        {
            this._interaction = interaction;
        }
    }
}