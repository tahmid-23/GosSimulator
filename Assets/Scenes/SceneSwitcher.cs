using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes
{
    public class SceneSwitcher : MonoBehaviour
    {
        private const KeyCode Ctrl = KeyCode.LeftControl;
        private readonly IDictionary<KeyCode, String> _sceneDict = new Dictionary<KeyCode, String>();

        private void Start()
        {
            _sceneDict.Add(KeyCode.N, "UI Test");
            _sceneDict.Add(KeyCode.M, "SampleScene");
        }


        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey(Ctrl))
            {
                foreach (KeyCode k in _sceneDict.Keys)
                {
                    if (Input.GetKeyDown(k))
                    {
                        SceneManager.LoadScene(_sceneDict[k]);
                    }
                }
            }
        }
    }
}
