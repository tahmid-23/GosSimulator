using Aim;
using UnityEngine;

namespace Opposition
{
    public class OppAiming : MonoBehaviour
    {

        private Aiming _aiming;

        private void Start()
        {
            _aiming = GetComponent<Aiming>();
        }

        private void FixedUpdate()
        {
            _aiming.DrawCones(Mathf.PI / 2, Mathf.PI / 2);
        }

    }
}