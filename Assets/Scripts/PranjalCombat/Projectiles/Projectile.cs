using UnityEngine;

namespace PranjalCombat.Projectiles
{
    public abstract class Projectile : MonoBehaviour
    {
        protected GameObject _bulletPrefab;

        public abstract void Shoot(Vector3 position, Vector3 direction, float bulletDistance);
    }
}