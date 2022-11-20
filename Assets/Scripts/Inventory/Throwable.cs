using System;
using UnityEngine;

namespace Inventory
{
    public abstract class Throwable : Weapon
    {

        [SerializeField]
        private Transform player;

        [SerializeField]
        private GameObject bulletPrefab;

        [SerializeField]
        private int particleCount = 5;

        [SerializeField]
        private float throwRange;
        
        private Camera _mainCamera;

        private GameObject[] _bullets;

        private void Awake()
        {
            _mainCamera = Camera.main;
            _bullets = new GameObject[particleCount];

            OnEquipped += RefreshBullets;
        }

        public override void VisualUpdate()
        {
            Vector3 playerPos = player.position;
            Vector3 mousePos = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;

            float r = Mathf.Min(Vector3.Distance(playerPos, mousePos), throwRange);
            float theta = Mathf.Atan2(mousePos.y - playerPos.y, mousePos.x - playerPos.x);
            
            Vector3 finalVec = new Vector3(r * Mathf.Cos(theta), r * Mathf.Sin(theta));

            for (int i = 0; i < _bullets.Length; ++i)
            {
                float x = (float) i / (_bullets.Length - 1);
                float y = -4 * x * (x - 1);
                Vector3 transformedVector = new Vector2(finalVec.x * x, finalVec.y * x + y); // linear algebra

                _bullets[i].transform.position = transformedVector + playerPos;
            }
        }

        private void RefreshBullets(bool equipped)
        {
            if (equipped)
            {
                _bullets = new GameObject[particleCount];
                for (int i = 0; i < _bullets.Length; ++i)
                {
                    _bullets[i] = Instantiate(bulletPrefab);
                }
            }
            else
            {
                foreach (GameObject bullet in _bullets)
                {
                    Destroy(bullet);
                }
                _bullets = Array.Empty<GameObject>();
            }
        }

    }
}
