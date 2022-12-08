using Movement;
using UnityEngine;

namespace AI
{
    public class FollowGosGoal : MonoBehaviour
    {

        private GameObject _gos;

        private MovementController _movementController;

        [SerializeField]
        private float speed;

        public bool ShouldFollow { get; set; } = true;

        private void Awake()
        {
            _movementController = GetComponent<MovementController>();
            _gos = GameObject.FindWithTag("Player");
        }

        private void Update()
        {
            if (_gos == null)
            {
                _movementController.Speed = Vector2.zero;
                return;
            }

            if (!ShouldFollow)
            {
                return;
            }

            Vector2 gosPosition = _gos.transform.position, aiPosition = transform.position;
            Vector2 direction = gosPosition - aiPosition;
            direction.Normalize();
            _movementController.Speed += speed * direction;
        }

    }
}