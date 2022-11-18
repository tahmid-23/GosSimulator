using UnityEngine;
using UnityEngine.Windows;
using Input = UnityEngine.Input;

namespace Shop
{
    public class LucrativeLarryShop: ShopBase
    {
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                EnableShop();
            }

            if (Input.GetKeyDown(KeyCode.L))
            {
                DisableShop();
            }
        }
    }
}