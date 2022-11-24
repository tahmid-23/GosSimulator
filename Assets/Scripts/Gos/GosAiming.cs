using Aim;
using UnityEngine;

namespace Gos
{
    public class GosAiming : MonoBehaviour
    {

        public Aiming Aiming { get; private set; }

        public bool IsAiming { get; private set; }

        private Camera _camera;

        private GosMovement _gosMovement;
        
        [Range(0.0f, 1.0f)]
        [SerializeField]
        private float aimSpeedMultiplier = 0.5f;

        private void Awake()
        {
            Aiming = GetComponent<Aiming>();
            _camera = Camera.main;
            _gosMovement = GetComponent<GosMovement>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                IsAiming = !IsAiming;
                _gosMovement.AdjustSpeed(aimSpeedMultiplier, IsAiming);
            }

            if (IsAiming)
            {
                Aiming.DrawCones(_gosMovement.Direction, GetAngle());
            }
        }

        private float GetAngle()
        {
            Vector3 mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
            Vector3 playerPos = transform.position;
            float dy = mousePos.y - playerPos.y;
            float dx = mousePos.x - playerPos.x;
    
            return Mathf.Atan2(dy, dx);
        }
    }
}
