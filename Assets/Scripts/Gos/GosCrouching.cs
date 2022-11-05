using Height;
using UnityEngine;

namespace Gos
{
    public class GosCrouching : MonoBehaviour
    {

        private HeightBehaviour _heightBehaviour;
        
        private GosMovement _gosMovement;

        private bool _crouching;

        private int _initialHeight;

        [Range(0.0f, 1.0f)]
        [SerializeField]
        private float crouchSpeedMultiplier = 0.5f;

        private void Awake()
        {
            _heightBehaviour = GetComponent<HeightBehaviour>();
            _gosMovement = GetComponent<GosMovement>();
            _initialHeight = _heightBehaviour.Height;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                _crouching = !_crouching;
                if (_crouching)
                {
                    _gosMovement.AdjustSpeed(crouchSpeedMultiplier, true);
                    _heightBehaviour.Height = 1;
                }
                else
                {
                    _gosMovement.AdjustSpeed(crouchSpeedMultiplier, false);
                    _heightBehaviour.Height = _initialHeight;
                }
            }
        }
    }
}