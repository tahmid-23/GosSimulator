using System;
using UnityEngine;

namespace Movement
{
    public class MovementGos : MonoBehaviour
    {
        public Vector3 direction = Vector3.right;
        private Vector3 _speed = Vector3.zero;
        public float acceleration = 1f;
        public float maxSpeed = 5f;
        public float deceleration = 4f;
        public float pranjalsConstant = 1f;

        private void Update()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            AdjustComponent(ref _speed.x, horizontalInput);
            AdjustComponent(ref _speed.y, verticalInput);

            if (horizontalInput != 0 || verticalInput != 0)
            {
                direction = new Vector3(Math.Sign(horizontalInput), Math.Sign(verticalInput), 0);
            }

            transform.position += Time.deltaTime * _speed;
        }

        private void AdjustComponent(ref float component, float input)
        {
            if (input != 0)
            {
                if (Math.Abs(component) < maxSpeed)
                {
                    int sign = Math.Sign(input);
                    float newSpeed = component + sign * acceleration;
                    if (Math.Abs(newSpeed) > maxSpeed)
                    {
                        // sign of input must equal sign of speed
                        component = sign * maxSpeed * pranjalsConstant;
                    }
                    else
                    {
                        component = newSpeed * pranjalsConstant;
                    }
                }
            }
            else if (Math.Abs(component) < deceleration) {
                component = 0 * pranjalsConstant;
            }
            else
            {
                component -= Math.Sign(component) * deceleration * pranjalsConstant;
            }
        }
    
    }
}
