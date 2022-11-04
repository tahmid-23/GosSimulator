using Aim;
using UnityEngine;

namespace Gos
{
    public class GosAiming : MonoBehaviour
    {

        public Aiming Aiming { get; private set; }

        public bool IsAiming { get; private set; }

        private Camera _camera;

        private GosMovement _movementGos;

        private void Awake()
        {
            Aiming = GetComponent<Aiming>();
            _camera = Camera.main;
            _movementGos = GetComponent<GosMovement>();
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                IsAiming = !IsAiming;
            }

            if (IsAiming)
            {
                Aiming.DrawCones(_movementGos.Direction, GetAngle());
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
