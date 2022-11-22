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

        private void Start()
        {
            _mainCamera = Camera.main;
        }

        public override void VisualUpdate()
        {
            Vector3 playerPos = player.position;
            Vector3 mousePos = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;

            float r = Mathf.Min(Vector3.Distance(playerPos, mousePos), throwRange);
            float theta = Mathf.Atan2(mousePos.y - playerPos.y, mousePos.x - playerPos.x);
            
            Vector3 finalVec = new Vector3(r * Mathf.Cos(theta), r * Mathf.Sin(theta));

            for (int i = 0; i < particleCount; ++i)
            {
                float x = (float) i / (particleCount - 1);
                float y = -4 * x * (x - 1);
                Vector3 transformedVector = new Vector2(finalVec.x * x, finalVec.y * x + y); // linear algebra

                GameObject newBullet = Instantiate(bulletPrefab);
                newBullet.transform.position = transformedVector + playerPos;
                Destroy(newBullet, 4 * Time.deltaTime);
            }
        }

    }
}
