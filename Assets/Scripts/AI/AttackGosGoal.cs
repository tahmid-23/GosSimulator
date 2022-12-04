using System;
using System.Collections;
using Combat;
using Inventory;
using Movement;
using UnityEngine;

namespace AI
{
    public class AttackGosGoal : MonoBehaviour
    {

        private MeleeCombat _meleeCombat;

        private FollowGosGoal _followGosGoal;

        private MovementController _movementController;

        private Melee _weapon;

        [SerializeField]
        private int recoilTime;

        [SerializeField]
        private int pauseTime;

        private int _updatesSinceAttack;

        private bool isPaused = false;

        private void Awake()
        {
            _meleeCombat = GetComponent<MeleeCombat>();
            _followGosGoal = GetComponent<FollowGosGoal>();
            _movementController = GetComponent<MovementController>();
            _movementController.OnCollision += OnCollision;
            _weapon = (Melee) GetComponent<ICurrentItemProvider>().GetEquippedItem();
            _updatesSinceAttack = _weapon.AttackRate;
        }

        private void OnCollision(RaycastHit2D collisionRaycast, Vector2 initialSpeed)
        {
            StartCoroutine(PauseFollow().GetEnumerator());
        }

        private IEnumerable PauseFollow()
        {
            isPaused = true;
            _followGosGoal.ShouldFollow = false;
            yield return new WaitForFixedUpdate();
            for (int i = 0; i < recoilTime; ++i)
            {
                yield return new WaitForEndOfFrame();
            }
            _movementController.Speed = Vector2.zero;
            yield return new WaitForFixedUpdate();
            for (int i = 0; i < pauseTime; ++i)
            {
                yield return new WaitForEndOfFrame();
            }
            _followGosGoal.ShouldFollow = true;
            yield return new WaitForFixedUpdate();
            isPaused = false;
        }

        private void Update()
        {
            if (isPaused)
            {
                return;
            }
            
            if (_updatesSinceAttack >= _weapon.AttackRate)
            {
                GameObject player = GameObject.FindWithTag("Player");
                if (player == null || !_meleeCombat.IsMeleeAllowed(player.transform, out MeleeCombat.AttackContext context))
                {
                    return;
                }

                _meleeCombat.ConductMeleeAttack(context);
                _updatesSinceAttack = 0;
            }
            else
            {
                ++_updatesSinceAttack;
            }
        }

    }
}