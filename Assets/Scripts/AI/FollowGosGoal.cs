using Movement;
using UnityEngine;

namespace AI
{
    public class FollowGosGoal : MonoBehaviour
    {

        [SerializeField]
        private Transform gosTransform;

        private MovementController _movementController;

        [SerializeField]
        private float speed;

        private void Awake()
        {
            _movementController = GetComponent<MovementController>();
        }

        private void Update()
        {
            Vector2 gosPosition = gosTransform.position, aiPosition = transform.position;
            Vector2 direction = gosPosition - aiPosition;
            direction.Normalize();
            _movementController.Speed = speed * direction;
        }

    }
}