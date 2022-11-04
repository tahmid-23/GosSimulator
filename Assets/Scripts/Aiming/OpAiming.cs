using UnityEngine;

namespace Aiming
{
    public class OpAiming : MonoBehaviour
    {
        private AimingAbstract _aimingAbstract;
        private Transform _transform;

        private void Start()
        {
            _aimingAbstract = GetComponent<AimingAbstract>();
            _transform = transform;
        }

        private void FixedUpdate()
        {
            DrawCones(1);
        }
        
        private void DrawCones(float direction)
        {
            float angleLow = direction - Mathf.PI / 8;
            float angleHigh = direction + Mathf.PI / 8;
        
            _aimingAbstract.DrawTestCone(angleLow, angleHigh);
            _aimingAbstract.setAngle(AimingAbstract.ClampAngle(1, angleLow, angleHigh));
            Vector3 endpoint = new Vector3(5 * Mathf.Cos(_aimingAbstract.getAngle()), 5 * Mathf.Sin(_aimingAbstract.getAngle()), 0);
            Debug.DrawRay(_transform.position, endpoint, Color.red, Time.deltaTime);
        }
    }
}