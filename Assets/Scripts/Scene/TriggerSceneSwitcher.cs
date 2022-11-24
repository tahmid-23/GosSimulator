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

        private Collider2D _trigger;

        private void Awake()
        {
            _trigger = GetComponent<Collider2D>();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            SceneManager.LoadScene(sceneName);
            player.position = destinationPosition;
        }

    }
}