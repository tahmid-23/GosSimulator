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

        private MovementController _movementController;

        private PlayerInventory _playerInventory;

        private AttackContext _currentContext;

        private bool _charging;

        private void Awake()
        {
            _camera = Camera.main;
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

            Melee attackWeapon = _playerInventory.GetEquippedItem().Item as Melee;
            if (attackWeapon == null)
            {
                attackContext = null;
                return false;
            }
            
            RaycastHit2D rayHit = Physics2D.GetRayIntersection(_camera.ScreenPointToRay(Input.mousePosition));
            Transform otherTransform = rayHit.transform;
            if (otherTransform == null)
            {
                attackContext = null;
                return false;
            }

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
            
            _currentContext.AttackWeapon.HandleAttack(collidedWith);

            _movementController.Speed += chargeRecoil * collisionRaycast.normal;
            
            _currentContext = null;
            _charging = false;
        }

    }
}
