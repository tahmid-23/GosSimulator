using System;
using UnityEngine;

namespace Currency
{
    public class GosCoins : MonoBehaviour
    {

        public static GosCoins Instance { get; private set; }

        public double Coins { get; set; } = 250;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
            }
        }

    }
}