using Movement;
using UnityEngine;

namespace AI
{
    public class FollowGosGoal : MonoBehaviour
    {

        [SerializeField]
        private Transform gosTransform;

        private Rigidbody2D _aiRigidbody2D;

        private MovementController _movementController;

        [SerializeField]
        private float speed;

        private void Awake()
        {
            _aiRigidbody2D = GetComponent<Rigidbody2D>();
            _movementController = GetComponent<MovementController>();
        }

        private void Update()
        {
            Vector2 gosPosition = gosTransform.position, aiPosition = _aiRigidbody2D.position;
            Vector2 direction = gosPosition - aiPosition;
            direction.Normalize();
            _movementController.Speed = speed * direction;
        }

    }
}