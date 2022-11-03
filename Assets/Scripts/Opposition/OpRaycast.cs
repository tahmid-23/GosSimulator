using System;
using UnityEngine;

namespace Opposition
{
    public class OpRaycast : MonoBehaviour
    {
        public OpMovement op;
        private float distanceRay = 90f;
        private void FixedUpdate()
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, distanceRay);
            
            if(hit.collider != null)
            {
                if (hit.collider.tag == "main_character")
                {
                    op.TriggerCombat();
                    Debug.Log("collision");
                }
            }
        }
    }
}