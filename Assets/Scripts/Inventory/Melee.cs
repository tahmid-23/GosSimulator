using Damage;
using UnityEngine;

namespace Inventory
{
    [CreateAssetMenu(menuName = "Melee", fileName = "Assets/Resources/Items/Melee")]
    public class Melee : Weapon
    {

        [field: SerializeField]
        public int AttackRate { get; private set; }

        [field: SerializeField]
        public float AttackRange { get; private set; }

        public void HandleAttack(GameObject gameObject)
        {
            if (gameObject.TryGetComponent(out IDamageReceiver damageReceiver))
            {
                damageReceiver.ChangeHealth(-Damage);
            }
        }

    }
}