using Movement;
using UnityEngine;

namespace AI
{
    public class FollowGosGoal : IAIGoal
    {

        private readonly Transform _gosTransform;

        private readonly Rigidbody2D _aiRigidbody2D;

        private readonly MovementController _movementController;

        private readonly float _speed;

        public FollowGosGoal(Transform gosTransform, Rigidbody2D aiRigidbody2D, MovementController movementController, float speed)
        {
            _gosTransform = gosTransform;
            _aiRigidbody2D = aiRigidbody2D;
            _movementController = movementController;
            _speed = speed;
        }

        public void Start()
        {
            
        }

        public void Update()
        {
            Vector2 gosPosition = _gosTransform.position, aiPosition = _aiRigidbody2D.position;
            Vector2 direction = new Vector2(gosPosition.x - aiPosition.x, gosPosition.y - aiPosition.y) * _speed;
            direction.Normalize();
            _movementController.Speed = direction;
        }

        public void End()
        {
            
        }
    }
}