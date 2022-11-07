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

        private void Start()
        {
            _aiming = GetComponent<Aiming>();
            body = GetComponent<Rigidbody2D>();
        }

        private double aimGos()
        {
            double dx = body.position.x - gos.position.x;
            double dy = body.position.y - gos.position.y;
            return Math.Atan2(dy, dx);
        }

        private void FixedUpdate()
        {
            _aiming.DrawCones((float) aimGos(), (float) aimGos());
        }

    }
}