using System;
using UnityEngine;

namespace Inventory
{
    public abstract class Throwable : Weapon
    {

        [SerializeField]
        private Camera mainCamera;

        [SerializeField]
        private Transform player;

        [SerializeField]
        private GameObject bulletPrefab;

        [SerializeField]
        private Transform testObj;

        [SerializeField]
        private Transform testHeight;

        [SerializeField]
        private float throwRange;

        private static Vector3 GetTrajectory(Vector3 playerPos, Vector3 target, float height, float x)
        {
            //-k(x-a)(x-b) where a is player position and b is target position
            //where k = 4h/(a-b)^2
            float a = playerPos.x;
            float b = target.x;
            float k = 4 * height / ((a - b) * (a - b));
            return new Vector3(x, -k * (x - a) * (x - b));
        }

        public void DisplayThrowingArc()
        {
            Vector3 playerPos = player.position;
            Vector3 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;

            float r = Mathf.Min(Vector3.Distance(playerPos, mousePos), throwRange);
            float theta = Mathf.Atan2(mousePos.y - playerPos.y, mousePos.x - playerPos.x);
            
            Vector3 finalPos = new Vector3(r * Mathf.Cos(theta), r * Mathf.Sin(theta)) + playerPos;
            
            //non-rigorous height code
            float height = Math.Max(1, throwRange - r);
            testHeight.position = new Vector3((finalPos.x + playerPos.x) / 2, height + playerPos.y);
            //i plan to solve for arclength (its gonna be a parabolic curve due to mechanics)
            //and basically the height will be set to such a value that makes the overall
            //length of the parabola from start to end = throw range
            
            testObj.position = finalPos;
            
            GenerateTrajectory(playerPos, finalPos, height, theta, 7);


            //old code that only depended on x-axis range
            /*float dx = mousePos.x - playerPos.x;
            if (dx < 0)
            {
                mousePos.x = Mathf.Max(dx, -_throwRange) + playerPos.x;
            }
            else
            {
                mousePos.x = Mathf.Min(dx, _throwRange) + playerPos.x;
            }*/
        }

        private void GenerateTrajectory(Vector3 playerPos, Vector3 target, float height, float theta, int n)
        {
            float dx = (target.x - playerPos.x)/(n+1);
            for (int i = 1; i <= n; i++)
            {
                GameObject bullet = Instantiate(bulletPrefab);
                Vector3 unrotatedPos = GetTrajectory(playerPos, target, height, i*dx + playerPos.x) - playerPos;
                bullet.transform.position =
                    new Vector3(unrotatedPos.x * Mathf.Cos(theta) - unrotatedPos.y * Mathf.Sin(theta),
                        unrotatedPos.x * Mathf.Sin(theta) + unrotatedPos.y * Mathf.Cos(theta)) + playerPos;
                Destroy(bullet, 4 * Time.deltaTime);
            }

            if (n % 2 == 0)
            {
                GenerateTrajectory(playerPos, target, height, theta, 1);
            }
        }
    }
}
