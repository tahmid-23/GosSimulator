using UnityEngine;

namespace Utils
{
    public class DontDestroy : MonoBehaviour
    {

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

    }
}