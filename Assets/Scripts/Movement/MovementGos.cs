using System;
using UnityEngine;

namespace Movement
{
    public class MovementGos : MonoBehaviour
    {
        private Vector3 _speed = new Vector3(0, 0, 0);
        public float acceleration = 1f;
        public float maxSpeed = 5f;
        public float deceleration = 4f;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            float x0 = _speed.x;
            float y0 = _speed.y;
        
            AdjustComponent(ref _speed.x, horizontalInput);
            AdjustComponent(ref _speed.y, verticalInput);

            transform.position += Time.deltaTime * _speed;
        }

        private void AdjustComponent(ref float component, float input)
        {
            if (input != 0)
            {
                float newSpeed = component + Math.Sign(input) * acceleration;
                if (Math.Abs(newSpeed) > maxSpeed)
                {
                    component = Math.Sign(component) * maxSpeed;
                }
                else
                {
                    component = newSpeed;
                }
            }
            else if (Math.Abs(component) < deceleration) {
                component = 0;
            }
            else
            {
                component -= Math.Sign(component) * deceleration;
            }
        }
    
    }
}
