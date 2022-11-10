using System.Collections;
using System.Collections.Generic;
using Gos;
using UnityEngine;
using Inventory;

public class GosCombat : MonoBehaviour
{
    private MeleeCombat _gosMelee;
    private GosAiming _gosAiming;
    private ShootingCombat _shootingCombat;
    
    public Inventory.Inventory _inventory;

    // Start is called before the first frame update
    void Start()
    {
        _gosAiming = GetComponent<GosAiming>();
        _gosMelee = GetComponent<MeleeCombat>();
        _inventory = GetComponent<Inventory.Inventory>();
        _shootingCombat = GetComponent<ShootingCombat>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0) && _inventory.getEquippedItem() is Melee)
        {
            if (_gosMelee.IsMeleeAllowed())
            {
                Debug.Log("Hola");
                _gosMelee.ConductMeleeAttack(transform.gameObject, _gosMelee.ObjectClickedGameObject(),5);
            }
        }
        
        // if (_gosAiming.IsAiming && Input.GetButtonDown("Fire1") && _inventory.getEquippedItem() is Projectile)
        // {
        //     _shootingCombat.ShootProjectile();
        // }
    }
}
