using Movement;
using Unity.VisualScripting;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;

namespace Shooting
{
    public class ShootingGos : MonoBehaviour
    {

        private const int BulletSpeed = 75;
        
        private GameObject _bullet;

        private MovementGos _movementGos;
    
        private void Start()
        {
            _bullet = Resources.Load("Prefabs/Bullet") as GameObject;
            _movementGos = GetComponent<MovementGos>();
        }

        private void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Vector3 position = transform.position;
                RaycastHit2D raycast = Physics2D.Raycast(position, transform.TransformDirection(_movementGos.direction.normalized));
                if (raycast.collider != null && raycast.collider.CompareTag("Opp"))
                {
                    HitAnimation hitAnimation = raycast.collider.gameObject.GetOrAddComponent<HitAnimation>();
                    hitAnimation.duration = 100;
                }
                
                GameObject bullet = Instantiate(_bullet, position, Quaternion.identity);
                MovementBullet movementBullet = bullet.GetComponent<MovementBullet>();
                movementBullet.speed = BulletSpeed * _movementGos.direction;
                movementBullet.duration = 100;
            }
        }
    }
}
