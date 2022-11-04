using UnityEngine;

namespace Opposition
{
    public class MovementOpp: MonoBehaviour {
        public int Direction { get; private set; } = -1;
        public Vector3 speed = Vector3.zero;
        public float maxSpeed = 5f;
        private bool _combatMode;

        private Rigidbody2D _rigidbody2D;

        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            _rigidbody2D.velocity = speed;
        }

        private void Update() {
            speed.y = Direction * maxSpeed;
        }

        private void OnCollisionEnter2D(Collision2D collider) {
            // Remember to change this to just walls later on
            Direction *= -1;
        }

        public void TriggerCombat()
        {
            _combatMode = true;
        }
        
    }
}