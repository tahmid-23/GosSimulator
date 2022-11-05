using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scene
{
    public class SceneSwitcher : MonoBehaviour
    {

        private const KeyCode Ctrl = KeyCode.LeftControl;

        private readonly IDictionary<KeyCode, string> _sceneDict = new Dictionary<KeyCode, string>();

        private void Start()
        {
            _sceneDict.Add(KeyCode.N, "UI Test");
            _sceneDict.Add(KeyCode.M, "SampleScene");
        }


        private void Update()
        {
            if (Input.GetKey(Ctrl))
            {
                foreach (KeyValuePair<KeyCode, string> pair in _sceneDict)
                {
                    if (Input.GetKeyDown(pair.Key))
                    {
                        SceneManager.LoadScene(pair.Value);
                    }
                }
            }
        }
    }
}
