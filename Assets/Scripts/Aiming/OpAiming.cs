using System;
using UnityEngine;
using Aiming;

namespace Aiming
{
    public class OpAiming : MonoBehaviour
    {
        private AimingAbstract _aimingAbstract;
        private Transform _player;

        void Start()
        {
            _aimingAbstract = GetComponent<AimingAbstract>();
            _player = GetComponent<Transform>();
        }
        void FixedUpdate()
        {
            drawCones(1);
        }
        
        private void drawCones(float direction)
        {
            float angleLow = direction - Mathf.PI / 8;
            float angleHigh = direction + Mathf.PI / 8;
        
            _aimingAbstract.DrawTestCone(direction, angleLow, angleHigh);
            _aimingAbstract.setAngle(AimingAbstract.ClampAngle(1, angleLow, angleHigh));
            Vector3 endpoint = new Vector3(5 * Mathf.Cos(_aimingAbstract.getAngle()), 5 * Mathf.Sin(_aimingAbstract.getAngle()), 0);
            Debug.DrawRay(_player.position, endpoint, Color.red, Time.deltaTime);
        }
    }
}