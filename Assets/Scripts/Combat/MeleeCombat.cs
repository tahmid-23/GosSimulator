using Damage;
using Inventory;
using Movement;
using UnityEngine;

namespace Combat
{
    public class MeleeCombat : MonoBehaviour
    {
        
        public class AttackContext
        {

            public Melee AttackWeapon { get; }

            public GameObject Target { get; }
            
            public AttackContext(Melee attackWeapon, GameObject target)
            {
                AttackWeapon = attackWeapon;
                Target = target;
            }

        }

        [SerializeField]
        private float chargeSpeed = 1.0F;

        [SerializeField]
        private float chargeRecoil = 1.0F;

        private MovementController _movementController;

        private ICurrentItemProvider _currentItemProvider;
        
        private AttackContext _currentContext;

        private bool _charging;

        private void Awake()
        {
            _movementController = GetComponent<MovementController>();
            _movementController.OnCollision += OnCollision;
            _currentItemProvider = GetComponent<ICurrentItemProvider>();
        }

        private void Update()
        {
            if (!_charging)
            {
                return;
            }

            if (_currentContext.Target == null)
            {
                _currentContext = null;
                _charging = false;
                return;
            }

            Vector2 chargeVector = _currentContext.Target.transform.position - transform.position;
            chargeVector = chargeSpeed * chargeVector.normalized;
            _movementController.Speed = chargeVector;
        }

        public bool IsMeleeAllowed(Transform target, out AttackContext attackContext)
        {
            if (_charging)
            {
                attackContext = null;
                return false;
            }

            Melee attackWeapon = _currentItemProvider.GetEquippedItem() as Melee;
            if (attackWeapon == null)
            {
                attackContext = null;
                return false;
            }

            Vector2 selfPosition = transform.position, otherPosition = target.position;
            float sqrLength = (otherPosition - selfPosition).sqrMagnitude;
            bool inRange = sqrLength <= attackWeapon.AttackRange * attackWeapon.AttackRange;
            if (!inRange)
            {
                attackContext = null;
                return false;
            }

            attackContext = new AttackContext(attackWeapon, target.gameObject);
            return true;
        }

        public void ConductMeleeAttack(AttackContext context)
        {
            _currentContext = context;
            _charging = true;
        }

        private void OnCollision(RaycastHit2D collisionRaycast, Vector2 initialSpeed)
        {
            if (!_charging)
            {
                return;
            }

            GameObject collidedWith = collisionRaycast.transform.gameObject;
            if (collidedWith == _currentContext.Target)
            {
                _currentContext.AttackWeapon.HandleAttack(collidedWith);
                _movementController.Speed += chargeRecoil * collisionRaycast.normal;
            }
            
            _currentContext = null;
            _charging = false;
        }

    }
}
