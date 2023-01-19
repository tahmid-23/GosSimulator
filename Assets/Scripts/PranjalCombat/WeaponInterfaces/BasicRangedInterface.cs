using System;
using UnityEngine;
using PranjalCombat;
using PranjalCombat.ProjectilesFolder;
using PranjalCombat.RangedWeapons;
using ProjectilesFolder;
using Range = PranjalCombat.Range;
using Weapon = PranjalCombat.Weapon;

namespace WeaponInterfaces
{
    public class BasicRangedInterface : MonoBehaviour, WeaponInterface
    {
        private Weapon _weapon = new StandardRangedWeapon();
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
            
            Debug.Log("Awakened");
            
            Range castedWeapon = (Range) _weapon;
            castedWeapon.SetProjectilePrefab(Resources.Load<GameObject>("Prefabs/Bullet"));
        }

        private void FixedUpdate()
        {
            Debug.DrawLine(_player.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), Color.red);

            if (Input.GetMouseButton(0))
            {
                Vector3 direction = GetDirection();
                
                Debug.Log(direction);
                
                Range castedWeapon = (Range) _weapon;
                
                GameObject bullet = Instantiate(castedWeapon.GetProjectilePrefab(), _player.position, Quaternion.identity);
                BasicProjectileBehavior bulletBehaviour = bullet.GetComponent<BasicProjectileBehavior>();

                bulletBehaviour.speed = 10 * direction;
                bulletBehaviour.distance = 200;
            }
        }
        
        private Vector3 GetDirection() {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 playerPos = _player.position;
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