using UnityEngine;

namespace Opposition
{
    public class OpStats : MonoBehaviour
    {

        public float health = 100f;

        public void modifyHealth(int modify) {
            health += modify;
            Debug.Log(health);

            if(health < 0) {
                opDeath();
            }
        }

        public void opDeath() {

        }
    }
}
