using Combat;
using Inventory;
using UnityEngine;

namespace Gos
{
    public class GosCombat : MonoBehaviour
    {
        private MeleeCombat _gosMelee;
        private ShootingCombat _shootingCombat;

        private void Awake()
        {
            _gosMelee = GetComponent<MeleeCombat>();
            _shootingCombat = GetComponent<ShootingCombat>();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (_gosMelee.IsMeleeAllowed(out MeleeCombat.AttackContext context))
                {
                    _gosMelee.ConductMeleeAttack(context);
                }
                if (_shootingCombat.IsShootingAllowed(out Projectile projectile))
                {
                    _shootingCombat.ShootProjectile(projectile);
                }
            }
        }
    }
}
