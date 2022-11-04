using System;
using UnityEngine;

namespace Movement
{
    public class MovementGos : MonoBehaviour
    {
        public float direction = 0f;
        private Vector3 _speed = Vector3.zero;
        public float acceleration = 1f;
        public float maxSpeed = 5f;
        public float deceleration = 4f;
        public float pranjalsConstant = 1f;
        private PlayerAiming _gosAim;
        private Rigidbody2D _rigidbody2D;
        private Transform _square;

        private void Start()
        {
            _gosAim = GetComponent<PlayerAiming>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _square = transform.GetChild(0);
        }

        private void FixedUpdate()
        {
            _rigidbody2D.velocity = _speed;
        }

        private void Update()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            AdjustComponent(ref _speed.x, horizontalInput);
            AdjustComponent(ref _speed.y, verticalInput);

            if ((horizontalInput != 0 || verticalInput != 0) && !_gosAim.Aiming)
            {
                direction = InputToAngle(horizontalInput, verticalInput);
                AdjustSprite();
            }
        }

        private void AdjustComponent(ref float component, float input)
        {
            if (input != 0)
            {
                if (Mathf.Abs(component) < maxSpeed)
                {
                    float sign = Mathf.Sign(input);
                    float newSpeed = component + sign * acceleration;
                    if (Mathf.Abs(newSpeed) > maxSpeed)
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
            else if (Mathf.Abs(component) < deceleration) {
                component = 0 * pranjalsConstant;
            }
            else
            {
                component -= Mathf.Sign(component) * deceleration * pranjalsConstant;
            }
        }

        private float InputToAngle(float horizontal, float vertical)
        {
            if (horizontal == 0)
            {
                if (vertical == 0)
                {
                    return direction;
                }

                return Mathf.Sign(vertical) * Mathf.PI / 2;
            }

            if (vertical == 0)
            {
                return horizontal > 0 ? 0 : Mathf.PI;
            }

            if (horizontal > 0)
            {
                return Mathf.Sign(vertical) * Mathf.PI / 6;
            }

            return Mathf.PI - Mathf.Sign(vertical) * Mathf.PI / 6;
        }
        
        private void AdjustSprite()
        {
            _square.eulerAngles = Vector3.forward * (Mathf.Rad2Deg * direction);
        }
        
    }
}
