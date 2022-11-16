using UnityEngine;

namespace Movement
{
    public class MovementController : MonoBehaviour
    {

        public CollisionHandler OnCollision;
        
        public Vector2 Speed { get; set; } = Vector2.zero;

        private BoxCollider2D _boxCollider2D;

        private Rigidbody2D _rigidbody2D;

        public delegate void CollisionHandler(RaycastHit2D collisionRaycast);

        private void Awake()
        {
            _boxCollider2D = GetComponent<BoxCollider2D>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            Transform gosTransform = transform;
            Vector2 center = gosTransform.TransformPoint(_boxCollider2D.offset);
            Vector2 resultSpeed = Speed * Time.fixedDeltaTime;
            
            RaycastHit2D[] raycasts = Physics2D.BoxCastAll(center, gosTransform.localScale * _boxCollider2D.size,
                0F, resultSpeed.normalized, resultSpeed.magnitude);
            RaycastHit2D[] collidingRaycasts = new RaycastHit2D[raycasts.Length];
            int collidingRaycastCount = 0;
            foreach (RaycastHit2D raycast in raycasts)
            {
                if (raycast.collider == null || raycast.collider == _boxCollider2D) continue;
                
                float projection = Vector2.Dot(resultSpeed, raycast.normal);
                if (projection >= 0) continue;
                
                Vector2 reduction = (projection + raycast.distance) * raycast.normal;
                resultSpeed -= reduction;
                Speed -= projection / Time.fixedDeltaTime * raycast.normal; // next speed should be completely zeroed

                collidingRaycasts[collidingRaycastCount++] = raycast;
            }

            _rigidbody2D.MovePosition(_rigidbody2D.position + resultSpeed);
            foreach (RaycastHit2D raycast in collidingRaycasts)
            {
                OnCollision(raycast);
            }
        }

    }
}