using UnityEngine;

namespace Movement
{
    public class MovementBullet : MonoBehaviour
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
        
    }
}