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
        private Rigidbody2D body;
        private float angle;

        private void Start()
        {
            _aiming = GetComponent<Aiming>();
            body = GetComponent<Rigidbody2D>();
        }

        private void aimGos()
        {
            float dx = body.position.x - gos.position.x;
            float dy = body.position.y - gos.position.y;
            this.angle = Mathf.Atan2(dy, dx) + Mathf.PI;
        }

        private void FixedUpdate()
        {
            aimGos();
            _aiming.DrawCones(angle, angle);
        }

        public float getAngle()
        {
            return this.angle;
        }
    }
}