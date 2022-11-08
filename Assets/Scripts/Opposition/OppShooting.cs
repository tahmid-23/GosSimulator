using System;
using Bullet;
using UnityEngine;

namespace Opposition
{
    public class OppShooting : MonoBehaviour
    {
        private OppAiming aiming;
        private GameObject _bullet;
        private Transform op_transform;
        
        private void Start()
        {
            op_transform = GetComponent<Transform>();
            aiming = GetComponent<OppAiming>();
            _bullet = Resources.Load("Prefabs/Bullet") as GameObject;
        }
        
        private void shootBullet()
        {
            Vector3 position = op_transform.position;
            float angle = aiming.GetAngle();
            Vector3 direction = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle));
            GameObject bullet = Instantiate(_bullet, position, Quaternion.identity);
            BulletBehaviour bulletBehaviour = bullet.GetComponent<BulletBehaviour>();
            bulletBehaviour.speed = 70 * direction;
            bulletBehaviour.distance = 100;
        }

        private void FixedUpdate()
        {
            shootBullet();
        }
    }
}