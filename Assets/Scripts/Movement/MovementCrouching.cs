using System;
using Height;
using UnityEngine;

namespace Movement
{
    public class MovementCrouching : MonoBehaviour
    {

        private HeightBehaviour _heightBehaviour;
        
        private MovementGos _movementGos;

        private bool _crouching;

        private int _initialHeight;

        [field : SerializeField]
        private float crouchSpeedMultiplier = 0.5f;

        private void Awake()
        {
            _heightBehaviour = GetComponent<HeightBehaviour>();
            _movementGos = GetComponent<MovementGos>();
            _initialHeight = _heightBehaviour.Height;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                _crouching = !_crouching;
                if (_crouching)
                {
                    _movementGos.maxSpeed *= crouchSpeedMultiplier;
                    _heightBehaviour.Height = 1;
                }
                else
                {
                    _movementGos.maxSpeed /= crouchSpeedMultiplier;
                    _heightBehaviour.Height = _initialHeight;
                }
            }
        }
    }
}