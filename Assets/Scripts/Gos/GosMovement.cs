using System;
using Movement;
using Sprites;
using UnityEngine;

namespace Gos
{
    public class GosMovement : MonoBehaviour
    {
        
        public float Direction { get; private set; }

        private GosAiming _gosAim;

        private Transform _square;

        private MovementController _movementController;

        [SerializeField]
        private float maxSpeed = 5F;
        
        [SerializeField]
        private float acceleration = 1F;
        
        [SerializeField]
        private float deceleration = 2F;

        private GosSpriteSwitcher _gosSpriteSwitcher;

        private void Awake()
        {
            _gosAim = GetComponent<GosAiming>();
            _movementController = GetComponent<MovementController>();
            // _square = transform.GetChild(0);
            _gosSpriteSwitcher = GetComponent<GosSpriteSwitcher>();
        }

        private void FixedUpdate()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

<<<<<<< Updated upstream
            if (horizontalInput > 0)
            {
                _gosSpriteSwitcher.SwitchSpriteRight();
            }

            if (horizontalInput < 0)
            {
                _gosSpriteSwitcher.SwitchSpriteLeft();
            }

            if (verticalInput > 0)
            {
                _gosSpriteSwitcher.SwitchSpriteUp();
            }
            
            if(verticalInput < 0)
            {
                _gosSpriteSwitcher.SwitchSpriteDown();
            }
=======
            if (SceneManager.GetActiveScene().name.Equals("Tutorial"))
            {
                if (horizontalInput != 0 || verticalInput != 0)
                {
                    GameObject.Find("Move Tutorial")?.SetActive(false);
                }
            }

            // if (horizontalInput > 0)
            // {
            //     _gosSpriteSwitcher.SwitchSpriteRight();
            // }
            //
            // if (horizontalInput < 0)
            // {
            //     _gosSpriteSwitcher.SwitchSpriteLeft();
            // }
            //
            // if (verticalInput > 0)
            // {
            //     _gosSpriteSwitcher.SwitchSpriteUp();
            // }
            //
            // if(verticalInput < 0)
            // {
            //     _gosSpriteSwitcher.SwitchSpriteDown();
            // }
>>>>>>> Stashed changes
            
            float newX = AdjustComponent(_movementController.Speed.x, horizontalInput);
            float newY = AdjustComponent(_movementController.Speed.y, verticalInput);
            _movementController.Speed = new Vector2(newX, newY);

            // if ((horizontalInput != 0 || verticalInput != 0) && !_gosAim.IsAiming)
            // {
            //    Direction = InputToAngle(horizontalInput, verticalInput);
            //    // AdjustSprite();
            // }
        }

        private float AdjustComponent(float component, float input)
        {
            if (input != 0)
            {
                float inputSign = Mathf.Sign(input), componentSign = Mathf.Sign(component);
                float acceleratedSpeed = component + inputSign * acceleration;
                if (Mathf.Abs(component) > maxSpeed)
                {
                    if (inputSign != componentSign)
                    {
                        return acceleratedSpeed;
                    }
                }
                else if (Mathf.Abs(acceleratedSpeed) > maxSpeed)
                {
                    return maxSpeed * componentSign;
                }
                else
                {
                    return acceleratedSpeed;
                }
            }
            if (Mathf.Abs(component) < deceleration) {
                return 0;
            }

            return component - Mathf.Sign(component) * deceleration;
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

        public void AdjustSpeed(float multiplier, bool multiply)
        {
            if (multiply)
            {
                maxSpeed *= multiplier;
            }
            else
            {
                maxSpeed /= multiplier;
                float speedX = Mathf.Min(_movementController.Speed.x, maxSpeed);
                float speedY = Mathf.Min(_movementController.Speed.y, maxSpeed);

                _movementController.Speed = new Vector2(speedX, speedY);
            }
        }

    }
}
