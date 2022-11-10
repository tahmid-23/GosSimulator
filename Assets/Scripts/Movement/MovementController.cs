using UnityEngine;

namespace Movement
{
    public class MovementController : MonoBehaviour
    {
        
        public Vector2 Speed { get; set; } = Vector2.zero;

        private BoxCollider2D _boxCollider2D;

        private Rigidbody2D _rigidbody2D;

        private void Awake()
        {
            _boxCollider2D = GetComponent<BoxCollider2D>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            Vector2 center = transform.TransformPoint(_boxCollider2D.offset);
            Vector2 resultSpeed = Speed * Time.fixedDeltaTime;
            
            RaycastHit2D[] raycasts = Physics2D.BoxCastAll(center, _boxCollider2D.size, 0F, resultSpeed, resultSpeed.magnitude);
            foreach (RaycastHit2D raycast in raycasts)
            {
                if (!raycast.collider || raycast.collider == _boxCollider2D) continue;
                
                float projection = Vector2.Dot(resultSpeed, raycast.normal);
                if (projection >= 0) continue;
                
                resultSpeed -= (projection + raycast.distance) * raycast.normal;
            }
            
            _rigidbody2D.MovePosition(_rigidbody2D.position + resultSpeed);
        }

    }
}