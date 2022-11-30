using System.Collections;
using System.Collections.Generic;
using Movement;
using Scene;
using UnityEngine;

namespace AI
{
    public class CleanUpSpillGoal : MonoBehaviour
    {

        [SerializeField]
        private int totalCleanTime;

        [SerializeField]
        private float speed;

        [SerializeField]
        private GameObject guardedDoor;

        private Animator _animator;

        private MovementController _movementController;

        private TriggerSceneSwitcher _guardedSceneSwitcher;

        private Vector3 _restPosition;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _movementController = GetComponent<MovementController>();
            _guardedSceneSwitcher = guardedDoor.GetComponent<TriggerSceneSwitcher>();
        }

        private void Start()
        {
            _restPosition = transform.position;
            StartCoroutine(FindSpills().GetEnumerator());
        }

        private IEnumerable FindSpills()
        {
            while (true)
            {
                yield return StartCoroutine(CleanAllSpills().GetEnumerator());
                yield return new WaitForSeconds(1);
            }
        }

        private IEnumerable CleanAllSpills()
        {
            _guardedSceneSwitcher.WarpEnabled = true;
            bool anySpills = false;
            while (true) 
            {
                Vector3 startPosition = transform.position;
                GameObject[] spills = GameObject.FindGameObjectsWithTag("Spill");
                if (spills.Length == 0)
                {
                    if (anySpills)
                    {
                        yield return StartCoroutine(ReturnToRest().GetEnumerator());
                    }

                    break;
                }

                anySpills = true;
                GameObject closestSpill = FindClosestSpill(spills, startPosition);
                yield return StartCoroutine(Clean(closestSpill).GetEnumerator());
            }
            _guardedSceneSwitcher.WarpEnabled = false;
        }

        private static GameObject FindClosestSpill(IReadOnlyList<GameObject> spills, Vector3 startPosition)
        {
            GameObject closest = spills[0];
            float closestDistance = (closest.transform.position - startPosition).sqrMagnitude;
            for (int i = 1; i < spills.Count; ++i)
            {
                GameObject newSpill = spills[i];
                float newDistance = (newSpill.transform.position - startPosition).sqrMagnitude;

                if (newDistance < closestDistance)
                {
                    closest = newSpill;
                    closestDistance = newDistance;
                }
            }

            return closest;
        }

        private IEnumerable ReturnToRest()
        {
            _animator.SetBool("Walking", true);
            while (MoveTowards(_restPosition))
            {
                yield return new WaitForFixedUpdate();
            }
            _movementController.Speed = Vector2.zero;
            _animator.SetBool("Walking", false);
        }

        private IEnumerable Clean(GameObject spill)
        {
            Vector3 spillPosition = spill.transform.position;

            _animator.SetBool("Walking", true);
            while (spill != null && MoveTowards(spillPosition))
            {
                yield return new WaitForFixedUpdate();
            }
            _movementController.Speed = Vector2.zero;
            _animator.SetBool("Walking", false);

            _animator.SetBool("Mopping", true);
            for (int i = 0; i < totalCleanTime; ++i)
            {
                if (spill == null)
                {
                    break;
                }

                yield return new WaitForEndOfFrame();
            }
            _animator.SetBool("Mopping", false);

            if (spill != null)
            {
                Destroy(spill);
            }
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