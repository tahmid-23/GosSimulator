using Movement;
using Unity.VisualScripting;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;

namespace Gos
{
    public class GosStats : MonoBehaviour
    {
        public float health = 100f;

        public void modifyHealth(int modify) {
            health += modify;

            if(health < 0) {
                gameOver();
            }
        }

        public void gameOver() {

        }
    }
}
