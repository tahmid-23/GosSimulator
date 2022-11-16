using System;
using Damage;
using Inventory;
using Movement;
using UnityEngine;

namespace Combat
{
    public class MeleeCombat : MonoBehaviour
    {
        [SerializeField]
        public double radius = 5.0;

        private bool _chargeBoolean = false;
        private Camera _camera;
        private MovementController _movementController;
        private GameObject _otherGameObject;
        private Melee _currentWeapon;

        private void Start()
        {
            _camera = Camera.main;
            _movementController = GetComponent<MovementController>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (_currentWeapon != null && collision.gameObject.CompareTag("Enemy"))
            {
                collision.gameObject.GetComponent<IDamageReceiver>().ChangeHealth(_currentWeapon.Damage);
                _chargeBoolean = false;
                _movementController.Speed += new Vector2(-2, 0);
            }
        }

        private void Update()
        {
            if (_chargeBoolean)
            {
                double dx = (_otherGameObject.transform.position.x - transform.position.x);
                double dy = (_otherGameObject.transform.position.y - transform.position.y);
                
                transform.position += new Vector3((float) dx * Time.deltaTime, (float) dy * Time.deltaTime);
            }
        }

        public GameObject ObjectClickedGameObject()
        {
            RaycastHit2D rayHit = Physics2D.GetRayIntersection(_camera.ScreenPointToRay(Input.mousePosition));
            _otherGameObject = rayHit.rigidbody.gameObject;
            return _otherGameObject;
        }

        public bool IsMeleeAllowed()
        {
            RaycastHit2D rayHit = Physics2D.GetRayIntersection(_camera.ScreenPointToRay(Input.mousePosition));
            Transform other = rayHit.transform;
            if (other == null)
            {
                return false;
            }
        
            double dx = Math.Abs(other.position.x - GetX());
            double dy = Math.Abs(other.position.y - GetY());

            double length = Math.Sqrt((dx * dx) + (dy * dy));

            return (length < radius);
        }

        // Speed from 1-5? Idk it works for now
        public void ConductMeleeAttack()
        {
            PlayerInventory playerInventory = GetComponent<PlayerInventory>();
            _currentWeapon = (Melee) playerInventory.GetEquippedItem();
            _chargeBoolean = true;
        }

        private double GetX()
        {
            return transform.position.x;
        }

        private double GetY()
        {
            return transform.position.y;
        }
    }
}
