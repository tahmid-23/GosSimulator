using System.Collections;
using Actions;
using UnityEngine;

namespace Inventory
{
    public class FollowThrowArc : MonoBehaviour
    {
        
        public Vector3 StartPosition { get; set; }
        
        public Vector3 EndPosition { get; set; }
        
        public int Iterations { get; set; }
        
        public Action Action { get; set; }

        private void Start()
        {
            transform.position = StartPosition;
            StartCoroutine(Throw().GetEnumerator());
        }

        private IEnumerable Throw()
        {
            for (int i = 0; i < Iterations; ++i)
            {
                float x = (float) i / (Iterations - 1);
                float y = -4 * x * (x - 1);
                transform.position = StartPosition + new Vector3(EndPosition.x * x, EndPosition.y * x + y);

                yield return null;
            }

            if (Action != null)
            {
                Action.Run(gameObject);
            }
            Destroy(gameObject);
        }
        
    }
}