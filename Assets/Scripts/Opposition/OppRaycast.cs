using UnityEngine;

namespace Opposition
{
    public class OppRaycast : MonoBehaviour
    {
        private const float DistanceRay = 90f;

        private void FixedUpdate()
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.forward, DistanceRay);
            
            if(hit.collider != null && hit.collider.CompareTag("main_character"))
            { 
<<<<<<< Updated upstream
                Debug.Log("collision");
=======
                _opp.TriggerCombat();
>>>>>>> Stashed changes
            }
        }
    }
}