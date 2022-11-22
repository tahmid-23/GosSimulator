using UnityEngine;

namespace Currency
{
    public class MakeThisASingleton : MonoBehaviour
    {
        private static double _gosCoins = 250;

        public static void ChangeGosCoins(double delta)
        {
            _gosCoins += delta;
        }

        public static double GetCosCoins()
        {
            return _gosCoins;
        }
    }
}