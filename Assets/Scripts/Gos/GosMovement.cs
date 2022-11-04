using UnityEngine;

namespace Gos
{
    public class GosMovement : MonoBehaviour
    {
        
        public float Direction { get; private set; }

        public float MaxSpeed { get; set; } = 5f;
        
        private const float Acceleration = 1f;
        
        private const float Deceleration = 4f;

        private const float PranjalsConstant = 1f;

        private GosAiming _gosAim;

        private Rigidbody2D _rigidbody2D;

        private Transform _square;

        private Vector3 _speed = Vector3.zero;

        private void Awake()
        {
            _gosAim = GetComponent<GosAiming>();
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

            if ((horizontalInput != 0 || verticalInput != 0) && !_gosAim.IsAiming)
            {
                Direction = InputToAngle(horizontalInput, verticalInput);
                AdjustSprite();
            }
        }

        private void AdjustComponent(ref float component, float input)
        {
            if (input != 0)
            {
                if (Mathf.Abs(component) < MaxSpeed)
                {
                    float sign = Mathf.Sign(input);
                    float newSpeed = component + sign * Acceleration;
                    if (Mathf.Abs(newSpeed) > MaxSpeed)
                    {
                        // sign of input must equal sign of speed
                        component = sign * MaxSpeed * PranjalsConstant;
                    }
                    else
                    {
                        component = newSpeed * PranjalsConstant;
                    }
                }
            }
            else if (Mathf.Abs(component) < Deceleration) {
                component = 0 * PranjalsConstant;
            }
            else
            {
                component -= Mathf.Sign(component) * Deceleration * PranjalsConstant;
            }
        }

        private float InputToAngle(float horizontal, float vertical)
        {
            if (horizontal == 0)
            {
                if (vertical == 0)
                {
                    return Direction;
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
            _square.eulerAngles = Vector3.forward * (Mathf.Rad2Deg * Direction);
        }
        
    }
}
