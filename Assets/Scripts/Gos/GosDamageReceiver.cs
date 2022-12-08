using Damage;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Gos
{
    public class GosDamageReceiver : BasicDamageReceiver
    {

        protected override bool OnHeal(float amount)
        {
            return true;
        }

        protected override bool OnDamage(float amount)
        {
            return true;
        }

        protected override void OnDeath()
        {
            Destroy(GameObject.Find("UI Canvas"));
            Destroy(GameObject.Find("Speech Panel"));
            Destroy(GameObject.Find("NPC Canvas"));
            Destroy(gameObject);
            SceneManager.LoadScene("TitleScreen");
        }
    }
}