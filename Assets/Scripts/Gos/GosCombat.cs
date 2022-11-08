using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GosCombat : MonoBehaviour
{
    public MeleeCombat gosMelee;
    
    // Start is called before the first frame update
    void Start()
    {
        gosMelee = GetComponent<MeleeCombat>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log(gosMelee.objectClickedName());
                Debug.Log(gosMelee.isMeleeAllowed());
            }
        }
    }
}
