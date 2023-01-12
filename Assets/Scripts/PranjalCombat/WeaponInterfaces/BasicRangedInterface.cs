using System;
using UnityEngine;

namespace PranjalCombat.WeaponInterfaces
{
    public class BasicRangedInterface : MonoBehaviour, WeaponInterface
    {
        private Weapon _weapon;
        private Transform _player;
        
        public void ActivateInterface()
        {
            throw new System.NotImplementedException();
        }

        public void DeactivateInterface()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateInterface()
        {
            
        }

        private void Awake()
        {
            _player = GameObject.Find("Square").GetComponent<Transform>();
        }

        private void FixedUpdate()
        {
            Debug.DrawLine(_player.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), Color.red);

            if (Input.GetMouseButton(0))
            {
                
            }
        }

        public void SetWeapon(Weapon weapon)
        {
            this._weapon = weapon;
        }
    }
}