using System;
using System.Collections.Generic;
using PranjalCombat.Projectiles;
using PranjalCombat.RangedWeapons;
using PranjalCombat.WeaponInterfaces;
using UnityEngine;

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
            GameObject gameObject = new GameObject("DetectPlayer");
            gameObject.AddComponent<BasicRangedInterface>();
        }

        private void FixedUpdate()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _weapon.GetWeaponInterface().ActivateInterface();
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                _weapon.GetWeaponInterface().DeactivateInterface();
            }
            
            _weapon.GetWeaponInterface().UpdateInterface();
        }
        
        // Remember to call this when changing weapons
        public void ChangeWeapon(Weapon weapon)
        {
            this._weapon = weapon;
            _weapon.GetWeaponInterface().SetWeapon(weapon);
        }
    }
}