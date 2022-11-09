using System.Collections.Generic;
using AI;
using Movement;
using UnityEngine;

namespace Opposition
{
    public class OppMovement: MonoBehaviour
    {

        [SerializeField]
        private Transform gosTransform;

        private IEnumerable<IAIGoal> _aiGoals;

        private void Awake()
        {
            Rigidbody2D aiRigidBody2D = GetComponent<Rigidbody2D>();
            MovementController movementController = GetComponent<MovementController>();
            _aiGoals = new[] { new FollowGosGoal(gosTransform, aiRigidBody2D, movementController, 3) };
        }

        private void Start()
        {
            foreach (IAIGoal aiGoal in _aiGoals)
            {
                aiGoal.Start();
            }
        }

        private void FixedUpdate()
        {
            foreach (IAIGoal aiGoal in _aiGoals)
            {
                aiGoal.Update();
            }
        }

        private void OnDisable()
        {
            foreach (IAIGoal aiGoal in _aiGoals)
            {
                aiGoal.End();
            }
        }

    }
}