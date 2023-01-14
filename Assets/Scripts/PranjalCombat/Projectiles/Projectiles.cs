using UnityEngine;

namespace PranjalCombat.Projectiles
{
    public abstract class Projectiles : MonoBehaviour
    {
        private GameObject _bulletPrefab;

        protected Projectiles()
        {
            
        }

        protected Projectiles(GameObject bulletPrefab)
        {
            this._bulletPrefab = bulletPrefab;
        }
        
        public abstract void Shoot(Vector3 position, Vector3 direction, float bulletDistance);

        protected GameObject GetBulletPrefab()
        {
            return _bulletPrefab;
        }

        protected void SetBulletPrefab(GameObject bulletPrefab)
        {
            this._bulletPrefab = bulletPrefab;
        } 
    }
}