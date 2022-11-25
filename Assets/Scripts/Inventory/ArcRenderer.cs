using System;
using UnityEngine;

namespace Inventory
{
    public class ArcRenderer : MonoBehaviour
    {

        private Throwable _throwable;

        public Throwable Throwable
        {
            get => _throwable;
            set
            {
                _throwable = value;

                if (_throwable != null)
                {
                    _bullets = new GameObject[_throwable.ParticleCount];
                    for (int i = 0; i < _throwable.ParticleCount; ++i)
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

        [SerializeField]
        private GameObject bulletPrefab;

        private GameObject[] _bullets = Array.Empty<GameObject>();

        private Camera _mainCamera;

        private void Awake()
        {
            _mainCamera = Camera.main;
        }

        private void Update()
        {
            if (Throwable == null)
            {
                return;
            }
            
            Vector3 playerPos = transform.position;
            Vector3 mousePos = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;

            float r = Mathf.Min(Vector3.Distance(playerPos, mousePos), Throwable.ThrowRange);
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

    }
}
