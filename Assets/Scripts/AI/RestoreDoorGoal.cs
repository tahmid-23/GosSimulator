using UnityEngine;

namespace AI
{
    public class RestoreDoorGoal : MonoBehaviour
    {

        private void Start()
        {
            foreach (GameObject door in GameObject.FindGameObjectsWithTag("Door"))
            {
                door.GetComponent<Collider2D>().isTrigger = false;
            }
        }

        private void OnDestroy()
        {
            foreach (GameObject door in GameObject.FindGameObjectsWithTag("Door"))
            {
                door.GetComponent<Collider2D>().isTrigger = true;
            }
        }

    }
}