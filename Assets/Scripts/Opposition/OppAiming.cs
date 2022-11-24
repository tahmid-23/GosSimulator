using System;
using Aim;
using Gos;
using UnityEngine;

namespace Opposition
{
    public class OppAiming : MonoBehaviour
    {

        private Aiming _aiming;
        public Transform gos;
        private Rigidbody2D _body;
        private float _angle;

        private void Awake()
        {
            _aiming = GetComponent<Aiming>();
            _body = GetComponent<Rigidbody2D>();
        }

        private void AimGos()
        {
            Vector2 bodyPosition = _body.position;
            Vector3 gosPosition = gos.position;
            float dx = bodyPosition.x - gosPosition.x;
            float dy = bodyPosition.y - gosPosition.y;
            _angle = Mathf.Atan2(dy, dx) + Mathf.PI;
        }

        private void FixedUpdate()
        {
            AimGos();
            _aiming.DrawCones(_angle, _angle);
        }

        public float GetAngle()
        {
            return _angle;
        }
    }
}