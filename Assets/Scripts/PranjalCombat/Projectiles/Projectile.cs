using UnityEngine;

namespace PranjalCombat.Projectiles
{
    public abstract class Projectile : MonoBehaviour
    {
        public Vector3 speed;

        public float distance;

        private int _duration;

        private int _aliveTime;

        public Projectile(Vector3 speed, float distance)
        {
            this.speed = speed;
            this.distance = distance;
        }

        private void Awake()
        {
            _duration = Mathf.FloorToInt(distance / (speed.magnitude * Time.deltaTime));
        }

        private void Update()
        {
            transform.position += speed * Time.deltaTime;
            if (_aliveTime == _duration)
            {
                Destroy(gameObject);
            }
            else
            {
                _aliveTime++;
            }
        }

        public abstract void Shoot();
    }
}