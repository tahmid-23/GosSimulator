using System;
using Combat;
using Damage;
using Inventory;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Gos
{
    public class GosCombat : MonoBehaviour
    {
        private MeleeCombat _gosMelee;
        private ShootingCombat _shootingCombat;
        private Collider2D _collider2D;

        private void Awake()
        {
            _gosMelee = GetComponent<MeleeCombat>();
            _shootingCombat = GetComponent<ShootingCombat>();
            _collider2D = GetComponent<Collider2D>();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Transform meleeTarget = GetMeleeTarget();
                if (meleeTarget != null && _gosMelee.IsMeleeAllowed(meleeTarget, out MeleeCombat.AttackContext context))
                {
                    _gosMelee.ConductMeleeAttack(context);
                }
                if (_shootingCombat.IsShootingAllowed(out Projectile projectile))
                {
                    _shootingCombat.ShootProjectile(projectile);
                }
            }
        }

        private Transform GetMeleeTarget()
        {
            RaycastHit2D[] rayHits = Physics2D.GetRayIntersectionAll(Camera.main.ScreenPointToRay(Input.mousePosition));
            Transform target = null;
            foreach (RaycastHit2D rayHit in rayHits)
            {
                if (rayHit.collider != null && rayHit.collider != _collider2D && !rayHit.collider.isTrigger
                    && rayHit.collider.gameObject.GetComponent<IDamageReceiver>() != null)
                {
                    target = rayHit.transform;
                    break;
                }
            }

            return target;
        }
        
    }
}
