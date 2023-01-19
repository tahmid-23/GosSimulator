using System;
using System.Collections.Generic;
using PranjalCombat.RangedWeapons;
using UnityEngine;
using WeaponInterfaces;

namespace PranjalCombat
{
    public class PlayerCombat : MonoBehaviour
    {
        private List<Attack> _attackList;

        private double _exhaustion;
        private double _weaponMana;
        private double _hp;
        
        private Weapon _weapon = new StandardRangedWeapon();

        private void Start()
        {
            GameObject gameObject = new GameObject("PlayerInterface");
            gameObject.AddComponent<BasicRangedInterface>();
        }
        
        // Remember to call this when changing weapons
        public void ChangeWeapon(Weapon weapon)
        {
            this._weapon = weapon;
            _weapon.GetWeaponInterface().SetWeapon(weapon);
        }
    }
}