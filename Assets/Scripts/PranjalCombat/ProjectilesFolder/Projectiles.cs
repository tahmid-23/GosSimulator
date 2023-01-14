using PranjalCombat;
using UnityEngine;

namespace ProjectilesFolder
{
    public abstract class Projectiles : Weapon
    {
        protected GameObject _bulletPrefab;

        public abstract void Shoot(Vector3 position, Vector3 direction, float bulletDistance);

        public GameObject GetBulletPrefab()
        {
            return _bulletPrefab;
        }

        public void SetBulletPrefab(GameObject bulletPrefab)
        {
            this._bulletPrefab = bulletPrefab;
        }
    }
}