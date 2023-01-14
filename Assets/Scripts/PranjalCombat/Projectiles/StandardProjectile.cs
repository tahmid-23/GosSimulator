using PranjalCombat;
using UnityEngine;
using UnityEngine.UI;

namespace PranjalCombat.Projectiles
{
    public class StandardProjectile : Projectiles
    {
        public StandardProjectile(GameObject gameObject) : base(gameObject)
        {
            
        }

        public StandardProjectile()
        {
            base.SetBulletPrefab(Resources.Load<GameObject>("Prefabs/Bullet"));
        }

        public override void Shoot(Vector3 position, Vector3 direction, float bulletDistance)
        {
            GameObject bullet = Instantiate(base.GetBulletPrefab(), position, Quaternion.identity);
            BasicProjectileBehavior bulletBehaviour = bullet.GetComponent<BasicProjectileBehavior>();

            bulletBehaviour.speed = bulletBehaviour.speed * direction;
            bulletBehaviour.distance = bulletDistance;
        }
    }
}