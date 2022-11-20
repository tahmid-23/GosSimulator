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
        private float radius = 5.0F;

        [SerializeField]
        private float chargeSpeed = 1.0F;

        [SerializeField]
        private float chargeRecoil = 1.0F;

        private Camera _camera;

        private Collider2D _collider2D;

        private MovementController _movementController;

        private PlayerInventory _playerInventory;

        private Melee _currentWeapon;

        private AttackContext _currentContext;

        private bool _charging;

        private void Awake()
        {
            _camera = Camera.main;
            _collider2D = GetComponent<Collider2D>();
            _movementController = GetComponent<MovementController>();
            _movementController.OnCollision += OnCollision;
            _playerInventory = GetComponent<PlayerInventory>();
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

        public bool IsMeleeAllowed(out AttackContext attackContext)
        {
            if (_charging)
            {
                attackContext = null;
                return false;
            }
            
            bool isWieldingMelee = _playerInventory.TryGetEquippedItem(out Melee attackWeapon);
            if (!isWieldingMelee)
            {
                attackContext = null;
                return false;
            }
            
            RaycastHit2D[] rayHits = Physics2D.GetRayIntersectionAll(_camera.ScreenPointToRay(Input.mousePosition));
            RaycastHit2D intendedHit = new RaycastHit2D();
            bool hasHit = false;
            foreach (RaycastHit2D rayHit in rayHits)
            {
                if (rayHit.collider != null && !rayHit.collider.isTrigger && rayHit.collider != _collider2D)
                {
                    intendedHit = rayHit;
                    hasHit = true;
                    break;
                }
            }
            if (!hasHit)
            {
                attackContext = null;
                return false;
            }

            Transform otherTransform = intendedHit.transform;
            Vector2 selfPosition = transform.position, otherPosition = otherTransform.position;
            float sqrLength = (otherPosition - selfPosition).sqrMagnitude;
            bool inRange = sqrLength <= radius * radius;
            if (!inRange)
            {
                attackContext = null;
                return false;
            }

            attackContext = new AttackContext(attackWeapon, otherTransform.gameObject);
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
            if (collidedWith != _currentContext.Target)
            {
                return;
            }
            
            if (collidedWith.TryGetComponent(out IDamageReceiver damageReceiver))
            {
                damageReceiver.ChangeHealth(_currentContext.AttackWeapon.Damage);
            }

            _movementController.Speed += chargeRecoil * collisionRaycast.normal;
            
            _currentContext = null;
            _charging = false;
        }

    }
}
