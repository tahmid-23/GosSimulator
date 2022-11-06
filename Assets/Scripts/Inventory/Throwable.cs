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
        //we need to figure out a better way to get this stuff - maybe define it at the top of the hierarchy

        public void DisplayThrowingArc()
        {
            //float height = 0;

            Vector3 playerPos = _player.position;
            Vector3 mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;

            float r = Mathf.Min(Vector3.Distance(playerPos, mousePos), _throwRange);
            float theta = Mathf.Atan2(mousePos.y - playerPos.y, mousePos.x - playerPos.x);
            
            Vector3 finalPos = new Vector3(r*Mathf.Cos(theta), r*Mathf.Sin(theta)) + playerPos;
            
            /*float dx = mousePos.x - playerPos.x;
            if (dx < 0)
            {
                mousePos.x = Mathf.Max(dx, -_throwRange) + playerPos.x;
            }
            else
            {
                mousePos.x = Mathf.Min(dx, _throwRange) + playerPos.x;
            }*/

            _testObj.position = finalPos;
        }
    }
}
