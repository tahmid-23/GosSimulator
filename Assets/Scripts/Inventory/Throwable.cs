using System;
using UnityEngine;

namespace Inventory
{
    public abstract class Throwable : Weapon
    {
        private readonly float _throwRange;
        
        protected Throwable(float damage, float range) : base(damage)
        {
            _throwRange = range;
        }

        public void Throw()
        {
            Use();
        }

        public float GetThrowRange()
        {
            return _throwRange;
        }

        //this needs to be changed i think
        private readonly Transform _player = GameObject.Find("Square").transform;
        private readonly Camera _cam = GameObject.Find("Main Camera").GetComponent<Camera>();

        private readonly Transform _testObj = GameObject.Find("Test Aimer").transform;
        private readonly Transform _testHeight = GameObject.Find("Test Height").transform;
        //we need to figure out a better way to get this stuff - maybe define it at the top of the hierarchy

        public void DisplayThrowingArc()
        {
            Vector3 playerPos = _player.position;
            Vector3 mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;

            float r = Mathf.Min(Vector3.Distance(playerPos, mousePos), _throwRange);
            float theta = Mathf.Atan2(mousePos.y - playerPos.y, mousePos.x - playerPos.x);
            
            Vector3 finalPos = new Vector3(r*Mathf.Cos(theta), r*Mathf.Sin(theta)) + playerPos;
            
            //non-rigorous height code
            float height = Math.Max(1, _throwRange-r);
            _testHeight.position = new Vector3((finalPos.x + playerPos.x)/2, height+playerPos.y);
            //i plan to solve for arclength (its gonna be a parabolic curve due to mechanics)
            //and basically the height will be set to such a value that makes the overall
            //length of the parabola from start to end = throw range
            
            _testObj.position = finalPos;
            
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
                GameObject trajectoryDot = Resources.Load<GameObject>("Prefabs/Bullet");
                GameObject obj = GameObject.Instantiate(trajectoryDot);
                Vector3 unrotatedPos = GetTrajectory(playerPos, target, height, i*dx + playerPos.x) - playerPos;
                obj.transform.position =
                    new Vector3(unrotatedPos.x * Mathf.Cos(theta) - unrotatedPos.y * Mathf.Sin(theta),
                        unrotatedPos.x * Mathf.Sin(theta) + unrotatedPos.y * Mathf.Cos(theta)) + playerPos;
                GameObject.Destroy(obj, 4*Time.deltaTime);
            }

            if (n % 2 == 0)
            {
                GenerateTrajectory(playerPos, target, height, theta, 1);
            }
        }

        private Vector3 GetTrajectory(Vector3 playerPos, Vector3 target, float height, float x)
        {
            //-k(x-a)(x-b) where a is player position and b is target position
            //where k = 4h/(a-b)^2
            float a = playerPos.x;
            float b = target.x;
            float k = (4 * height)/((a-b)*(a-b));
            return new Vector3(x, -k*(x-a)*(x-b));
        }
    }
}
