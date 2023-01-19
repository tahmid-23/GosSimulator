using PranjalCombat;
using ProjectilesFolder;
using UnityEngine;
using UnityEngine.UI;

namespace PranjalCombat.ProjectilesFolder
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
    }
}