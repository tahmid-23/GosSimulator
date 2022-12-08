using System.Collections;
using Movement;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace PlayModeTests.Movement
{
    public class MovementControllerTest
    {

        private MovementController _movementController;
        
        private GameObject _movingObject;

        private GameObject _staticObject;

        [SetUp]
        public void SetUpMovingObject()
        {
            _movingObject = new GameObject("Moving Object");
            BoxCollider2D boxCollider2D = _movingObject.AddComponent<BoxCollider2D>();
            boxCollider2D.size = new Vector2(1, 1);
            Rigidbody2D rigidbody2D = _movingObject.AddComponent<Rigidbody2D>();
            rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
            _movementController = _movingObject.AddComponent<MovementController>();
        }
        
        [SetUp]
        public void SetUpStaticObject()
        {
            _staticObject = new GameObject("Static Object");
            BoxCollider2D boxCollider2D = _staticObject.AddComponent<BoxCollider2D>();
            boxCollider2D.size = new Vector2(1, 5);
            Rigidbody2D rigidbody2D = _staticObject.AddComponent<Rigidbody2D>();
            rigidbody2D.bodyType = RigidbodyType2D.Static;
        }

        [TearDown]
        public void DestroyPreviousObjects()
        {
            Object.Destroy(_movingObject);
            Object.Destroy(_staticObject);
        }

        [UnityTest]
        public IEnumerator TestRegularObjectMovementUninhibited()
        {
            _staticObject.SetActive(false);
            _movingObject.transform.position = Vector3.zero;
           
            _movementController.Speed = Vector2.right;
            yield return new WaitForFixedUpdate();

            Assert.AreEqual(Time.fixedDeltaTime * Vector3.right, _movingObject.transform.position);
        }

        [UnityTest]
        public IEnumerator TestAdjacentCollisionPreventsMovement()
        {
            _movingObject.transform.position = Vector3.zero;
            _staticObject.transform.position = new Vector3(1F, 0, 0);

            _movementController.Speed = Vector2.right;
            yield return new WaitForFixedUpdate();
            
            Assert.AreEqual(Vector3.zero, _movingObject.transform.position);
            Assert.AreEqual(Vector2.zero, _movementController.Speed);
        }

        [UnityTest]
        public IEnumerator TestAdjacentPerpendicularMovementUninhibited()
        {
            _movingObject.transform.position = Vector3.zero;
            _staticObject.transform.position = new Vector3(1F, 0, 0);

            _movementController.Speed = Vector2.up;
            yield return new WaitForFixedUpdate();
            
            Assert.AreEqual(Time.fixedDeltaTime * Vector3.up, _movingObject.transform.position);
            Assert.AreEqual(Vector2.up, _movementController.Speed);
        }

    }
}