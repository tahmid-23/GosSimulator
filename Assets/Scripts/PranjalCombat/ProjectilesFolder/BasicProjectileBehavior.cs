using System;
using UnityEngine;
using Damage;

namespace PranjalCombat.ProjectilesFolder
{
    public class BasicProjectileBehavior : MonoBehaviour
    {
        public Vector3 speed;

        public float distance;

        private int _duration;

        private int _aliveTime;

        private Collider2D _collider2D;

        private void Start()
        {
            _duration = Mathf.FloorToInt(distance / (speed.magnitude * Time.deltaTime));
            _collider2D = GetComponent<Collider2D>();
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
        

        private void OnTriggerEnter2D(Collider2D col)
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