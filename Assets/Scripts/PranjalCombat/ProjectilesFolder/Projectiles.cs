using PranjalCombat;
using UnityEngine;

namespace ProjectilesFolder
{
    public abstract class Projectiles : Weapon
    {
        protected GameObject _bulletPrefab;

        public Projectiles()
        {
            
        }

        public Projectiles(GameObject bulletPrefab)
        {
            this._bulletPrefab = bulletPrefab;
        }

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