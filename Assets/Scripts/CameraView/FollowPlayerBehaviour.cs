using UnityEngine;
using UnityEngine.Serialization;

namespace CameraView
{
    public class FollowPlayerBehaviour : MonoBehaviour
    {

        [SerializeField]
        private BoxCollider2D gosCollider;

        [SerializeField]
        private BoxCollider2D followCollider;

        [Range(0.0F, 1.0F)]
        [SerializeField]
        private float lerp;

        private bool _isFollowingX = true;

        private bool _isFollowingY = true;

        private void LateUpdate()
        {
            Transform cameraTransform = transform;
            Vector3 cameraPosition = cameraTransform.position, gosPosition = gosCollider.transform.position;
            
            Bounds followBounds = followCollider.bounds;
            float newX = cameraPosition.x, newY = cameraPosition.y;
            float minFollowX = followBounds.min.x, maxFollowX = followBounds.max.x;
            if (minFollowX <= gosPosition.x && gosPosition.x <= maxFollowX)
            {
                if (_isFollowingX)
                {
                    newX = gosPosition.x;
                }
                else
                {
                    newX = Mathf.Lerp(cameraPosition.x, gosPosition.x, lerp);
                    if (Mathf.Abs(gosPosition.x - newX) < 0.1F)
                    {
                        newX = gosPosition.x;
                        _isFollowingX = true;
                    }
                }
            }
            else
            {
                _isFollowingX = false;
            }
            float minFollowY = followBounds.min.y, maxFollowY = followBounds.max.y;
            if (minFollowY <= gosPosition.y && gosPosition.y <= maxFollowY)
            {
                if (_isFollowingY)
                {
                    newY = gosPosition.y;
                }
                else
                {
                    newY = Mathf.Lerp(cameraPosition.y, gosPosition.y, lerp);
                    if (Mathf.Abs(gosPosition.y - newY) < 0.1F)
                    {
                        newY = gosPosition.y;
                        _isFollowingY = true;
                    }
                }
            }
            else
            {
                _isFollowingY = false;
            }

            cameraTransform.position = new Vector3(newX, newY, cameraPosition.z);
        }
    }
}