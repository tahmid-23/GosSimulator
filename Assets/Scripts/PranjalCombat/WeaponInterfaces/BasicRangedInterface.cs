using System;
using UnityEngine;
using PranjalCombat;
using ProjectilesFolder;
using Weapon = PranjalCombat.Weapon;

namespace WeaponInterfaces
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
                Projectiles castedWeapon = (Projectiles) _weapon;
                castedWeapon.Shoot(_player.position, GetDirection(), 100);
            }
        }
        
        private Vector3 GetDirection() {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 playerPos = transform.position;
            float dy = mousePos.y - playerPos.y;
            float dx = mousePos.x - playerPos.x;
    
            float angle = Mathf.Atan2(dy, dx);

            Vector3 direction = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle));

            return direction;
        }

        public void SetWeapon(Weapon weapon)
        {
            throw new NotImplementedException();
        }
    }
}