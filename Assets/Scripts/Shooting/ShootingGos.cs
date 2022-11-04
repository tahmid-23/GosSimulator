using Damage;
using Movement;
using Unity.VisualScripting;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Opposition;

namespace Shooting
{
    public class ShootingGos : MonoBehaviour
    {

        private const int BulletSpeed = 75;
        
        private GameObject _bullet;

        private MovementGos _movementGos;
        public PlayerAiming player;
    
        private void Start()
        {
            _bullet = Resources.Load("Prefabs/Bullet") as GameObject;
            _movementGos = GetComponent<MovementGos>();
        }

        private void Update()
        {
            if (player.IsAiming() && Input.GetButtonDown("Fire1"))
            {
                Vector3 position = transform.position;
                Vector3 direction = new Vector3(Mathf.Cos(_movementGos.direction), Mathf.Sin(_movementGos.direction))
                    .normalized;
                
                RaycastHit2D raycast = Physics2D.Raycast(position, transform.TransformDirection(direction));
                if (raycast.collider != null)
                {
                    if (raycast.collider.gameObject.TryGetComponent(out IDamageReceiver damageReceiver))
                    {
                        damageReceiver.ChangeHealth(-5);
                    }
                }
                
                GameObject bullet = Instantiate(_bullet, position, Quaternion.identity);
                MovementBullet movementBullet = bullet.GetComponent<MovementBullet>();
                movementBullet.speed.x = BulletSpeed * Mathf.Cos(player.Angle);
                movementBullet.speed.y = BulletSpeed * Mathf.Sin(player.Angle);
                movementBullet.duration = 100;
            }
        }
    }
}
