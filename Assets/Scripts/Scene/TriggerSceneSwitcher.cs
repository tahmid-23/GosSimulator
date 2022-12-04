using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scene
{
    public class TriggerSceneSwitcher : MonoBehaviour
    {
        
        [SerializeField]
        private string sceneName;

        [SerializeField]
        private Vector3 destinationPosition;

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (!col.gameObject.CompareTag("Player"))
            {
                return;
            }

            SceneManager.LoadScene(sceneName);
            col.gameObject.transform.position = destinationPosition;
        }

    }
}