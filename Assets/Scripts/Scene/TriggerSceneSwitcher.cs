using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scene
{
    public class TriggerSceneSwitcher : MonoBehaviour
    {

        [SerializeField]
        private Transform player;
        
        [SerializeField]
        private string sceneName;

        [SerializeField]
        private Vector3 destinationPosition;

        [field: SerializeField]
        public bool WarpEnabled { get; set; } = true;

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (!WarpEnabled)
            {
                return;
            }
            if (col.gameObject.CompareTag("Player"))
            {
                //SceneManager.LoadScene(sceneName);
                player.position = destinationPosition;
            }
        }

    }
}