using Combat;
using Inventory;
using UnityEngine;

namespace Gos
{
    public class GosCombat : MonoBehaviour
    {
        private MeleeCombat _gosMelee;
        private GosAiming _gosAiming;
        private ShootingCombat _shootingCombat;
    
        private PlayerInventory _playerInventory;

        // Start is called before the first frame update
        void Start()
        {
            _gosAiming = GetComponent<GosAiming>();
            _gosMelee = GetComponent<MeleeCombat>();
            _playerInventory = GetComponent<PlayerInventory>();
            _shootingCombat = GetComponent<ShootingCombat>();
        }

        // Update is called once per frame
        private void Update()
        {
        
            if (Input.GetMouseButtonDown(0) && _playerInventory.GetEquippedItem() is Melee)
            {
                if (_gosMelee.IsMeleeAllowed())
                {
                    Debug.Log("Hola");
                    _gosMelee.ConductMeleeAttack();
                }
            }
        
            // if (_gosAiming.IsAiming && Input.GetButtonDown("Fire1") && _inventory.getEquippedItem() is Projectile)
            // {
            //     _shootingCombat.ShootProjectile();
            // }
        }
    }
}
