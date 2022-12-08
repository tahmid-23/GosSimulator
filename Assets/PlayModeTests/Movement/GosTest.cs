using Gos;
using NUnit.Framework;
using UnityEngine;

namespace PlayModeTests.Gos
{
    public class GosDamageReceiverTest : MonoBehaviour
    {

        private const int MaxHealth = 10;

        private GameObject _root;
        
        private GosDamageReceiver _damageReceiver;
        
        [SetUp]
        public void SetUpDamageReceiver()
        {
            _root = new GameObject();
            _damageReceiver = _root.AddComponent<GosDamageReceiver>();
            _damageReceiver.MaxHealth = MaxHealth;
            _damageReceiver.Health = MaxHealth;
        }

        [TearDown]
        public void TearDown()
        {
            Destroy(_root);
        }

        [Test]
        public void TestRemoveHealth()
        {
            _damageReceiver.ChangeHealth(-5);
            
            Assert.AreEqual(MaxHealth - 5, _damageReceiver.Health);
        }
        
        [Test]
        public void TestPastZero()
        {
            _damageReceiver.ChangeHealth(-15);
            
            Assert.AreEqual(0, _damageReceiver.Health);
        }

        [Test]
        public void TestDelegateInvoke()
        {
            bool[] set = { false };
            _damageReceiver.ChangeHealthHandler += _ =>
            {
                set[0] = true;
            };
            _damageReceiver.ChangeHealth(0);
            
            Assert.IsTrue(set[0]);
        }
        
    }
}