using Movement;
using UnityEngine;

namespace Aiming
{
    public class PlayerAiming : MonoBehaviour
    {

        public bool Aiming { get; private set; }
    
        public AimingAbstract AimingAbstract { get; private set; }

        public Camera camera;

        private MovementGos _movementGos;
    
        private Transform _player;
    
        private const int R = 5;

        private void Awake()
        {
            Aiming = false;
            _movementGos = GetComponent<MovementGos>();
            AimingAbstract = GetComponent<AimingAbstract>();
            _player = transform;
        }

        // Update is called once per frame
        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Aiming = !Aiming;
            }

            if (Aiming)
            {
                drawCones(_movementGos.direction);
            }
        }

        private float GetAngle()
        {
            Vector3 mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
            Vector3 playerPos = _player.position;
            float dx = mousePos.x - playerPos.x;
            float dy = mousePos.y - playerPos.y;
    
            return Mathf.Atan2(dy, dx);
        }
    
        private void drawCones(float direction)
        {
            float angleLow = direction - Mathf.PI / 8;
            float angleHigh = direction + Mathf.PI / 8;
        
            AimingAbstract.DrawTestCone(angleLow, angleHigh);
            AimingAbstract.setAngle(AimingAbstract.ClampAngle(GetAngle(), angleLow, angleHigh));
            Vector3 endpoint = R * new Vector3(Mathf.Cos(getAngleHelper()), Mathf.Sin(getAngleHelper()), 0);
            Debug.DrawRay(_player.position, endpoint, Color.red, Time.deltaTime);
        }

        public float getAngleHelper()
        {
            return AimingAbstract.getAngle();
        }
    }
}
