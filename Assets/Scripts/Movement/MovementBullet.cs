using UnityEngine;

namespace Movement
{
    public class MovementBullet : MonoBehaviour
    {
        
        public Vector3 speed;

        public int duration;

        private int _aliveTime;

        private void Update()
        {
            transform.position += speed * Time.deltaTime;
            if (_aliveTime == duration)
            {
                Destroy(gameObject);
            }
            else
            {
                _aliveTime++;
            }
        }
        
    }
}