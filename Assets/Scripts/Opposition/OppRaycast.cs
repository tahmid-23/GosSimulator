using UnityEngine;

namespace Opposition
{
    public class OppRaycast : MonoBehaviour
    {
        private const float DistanceRay = 90f;

        private OppMovement _opp;

        private void Awake()
        {
            _opp = GetComponent<OppMovement>();
        }

        private void FixedUpdate()
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up * _opp.Direction, DistanceRay);
            
            if(hit.collider != null && hit.collider.CompareTag("main_character"))
            { 
                _opp.TriggerCombat(); 
                Debug.Log("collision");
            }
        }
    }
}