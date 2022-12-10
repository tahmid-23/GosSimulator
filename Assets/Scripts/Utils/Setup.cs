using System;
using System.Collections.Generic;
using Inventory;
using UnityEngine;

namespace Utils
{
    public class Setup : MonoBehaviour
    {

        private static bool isSetup = false;

        [SerializeField]
        private List<GameObject> prefabs;

        private void Awake()
        {
            if (isSetup) return;

            foreach (GameObject prefab in prefabs)
            {
                GameObject instantiated = Instantiate(prefab);
                instantiated.name = prefab.name;
            }
            isSetup = true;
        }

    }
}