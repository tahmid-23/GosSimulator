using System;
using UnityEngine;

namespace Opposition
{
    public class OpMovement: MonoBehaviour {
        private int direction = -1;
        public Vector3 speed = new Vector3(0, 0, 0);
        public float maxSpeed = 5f;
        private bool combatMode = false;

        void Start() {

        }

        void Update() {
            speed.y = direction * maxSpeed;
            transform.position += speed * Time.deltaTime;
        }

        void OnCollisionEnter2D(Collision2D collider) {
            // Remember to change this to just walls later on
            direction *= -1;
        }

        public void TriggerCombat()
        {
            combatMode = true;
        }

        public int returnDirection()
        {
            return direction;
        }
    }
}