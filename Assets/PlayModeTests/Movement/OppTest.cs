using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Opposition;
using UnityEngine;

public class OppTest : MonoBehaviour
{
    private const int MaxHealth = 10;

    private GameObject _root;
        
    private OppDamageReceiver _damageReceiver;
        
    [SetUp]
    public void SetUpDamageReceiver()
    {
        _root = new GameObject();
        _damageReceiver = _root.AddComponent<OppDamageReceiver>();
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
