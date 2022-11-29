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
            if(!PlayerPrefs.HasKey("GosCoins")) {
                PlayerPrefs.SetFloat("GosCoins", (float) Coins);
            }
            else {
                Coins = PlayerPrefs.GetFloat("GosCoins");
            }

            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
            }
        }


        public static void ChangeGosCoins(double delta) {
            GosCoins.Instance.Coins += delta;

            PlayerPrefs.SetFloat("GosCoins", (float) GosCoins.Instance.Coins);
        }

    }
}