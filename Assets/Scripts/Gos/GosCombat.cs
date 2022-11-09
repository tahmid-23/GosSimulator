using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inventory;

public class GosCombat : MonoBehaviour
{
    public MeleeCombat gosMelee;
    public Inventory.Inventory _inventory;

    // Start is called before the first frame update
    void Start()
    {
        
        gosMelee = GetComponent<MeleeCombat>();
        _inventory = GetComponent<Inventory.Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0) && _inventory.getEquippedItem() is Melee)
        {
            if (gosMelee.IsMeleeAllowed())
            {
                Debug.Log("Hola");
                gosMelee.ConductMeleeAttack(transform.gameObject, gosMelee.ObjectClickedGameObject(),5);
            }
            // Debug.Log(gosMelee.objectClickedName());
            // Debug.Log(gosMelee.isMeleeAllowed());
            // Debug.Log("tf?"); 
        }
    }
}
