using UnityEngine;

namespace Shooting
{
    public class HitAnimation : MonoBehaviour
    {

        public int duration;

        private SpriteRenderer _spriteRenderer;

        private Color _initialColor;
        
        private int _aliveTime;

        private void Awake()
        {
            _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            _initialColor = _spriteRenderer.color;
            _spriteRenderer.color = Color.red;
        }

        private void Update()
        {
            if (_aliveTime == duration)
            {
                _spriteRenderer.color = _initialColor;
                Destroy(this);
            }
            else
            {
                _aliveTime++;
            }
        }
        
    }
}