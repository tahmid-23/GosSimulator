using System.Collections;
using Movement;
using UnityEngine;

namespace AI
{
    public class CleanUpSpillGoal : MonoBehaviour
    {

        [SerializeField]
        private int totalCleanTime;

        [SerializeField]
        private float speed;

        private MovementController _movementController;

        private void Awake()
        {
            _movementController = GetComponent<MovementController>();
        }

        private void Start()
        {
            StartCoroutine(FindSpills().GetEnumerator());
        }

        private IEnumerable FindSpills()
        {
            while (true)
            {
                GameObject spill = GameObject.FindWithTag("Spill");
                if (spill != null)
                {
                    yield return StartCoroutine(Clean(spill).GetEnumerator());
                }

                yield return new WaitForSeconds(1);
            }
        }

        private IEnumerable Clean(GameObject spill)
        {
            Vector3 initialPosition = transform.position;
            Vector3 spillPosition = spill.transform.position;

            while (spill != null && MoveTowards(spillPosition))
            {
                yield return new WaitForFixedUpdate();
            }
            _movementController.Speed = Vector2.zero;

            for (int i = 0; i < totalCleanTime; ++i)
            {
                if (spill == null)
                {
                    break;
                }

                yield return new WaitForFixedUpdate();
            }
            if (spill != null)
            {
                Destroy(spill);
            }

            while (MoveTowards(initialPosition))
            {
                yield return new WaitForEndOfFrame();
            }
            _movementController.Speed = Vector2.zero;
        }

        private bool MoveTowards(Vector3 position)
        {
            Vector3 currentPosition = transform.position;
            float distance = Vector3.SqrMagnitude(position - currentPosition);
            Vector2 delta = position - currentPosition;

            if (distance >= speed * Time.fixedDeltaTime)
            {
                _movementController.Speed = speed * delta.normalized;
                return true;
            }

            _movementController.Speed = delta / Time.fixedDeltaTime;
            return false;
        }

    }
}