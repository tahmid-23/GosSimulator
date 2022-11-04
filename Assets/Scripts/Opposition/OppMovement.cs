using UnityEngine;

namespace Opposition
{
    public class OppMovement: MonoBehaviour {
        public int Direction { get; private set; } = -1;

        public Vector3 speed = Vector3.zero;

        public float maxSpeed = 5f;

        private Rigidbody2D _rigidbody2D;

        private bool _combatMode;

        private void Awake()
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

        private void OnCollisionEnter2D(Collision2D collision) {
            // Remember to change this to just walls later on
            Direction *= -1;
        }

        public void TriggerCombat()
        {
            _combatMode = true;
        }
        
    }
}