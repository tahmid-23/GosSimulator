using UnityEngine;
using Damage;

namespace PranjalCombat.Projectiles
{
    public class BasicProjectileBehavior : MonoBehaviour
    {
        public Vector3 speed;

        public float distance;

        private int _duration;

        private int _aliveTime;

        private void Start()
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

        private void OnCollisionEnter2D(Collision2D col)
        {
            GameObject collisionObject = col.gameObject;
            IDamageReceiver damageReceiver = collisionObject.GetComponent<IDamageReceiver>();

            if (collisionObject.CompareTag("Enemy"))
            {
                damageReceiver.ChangeHealth(-10);
            }
        } 
    }
}