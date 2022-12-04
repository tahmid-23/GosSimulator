using UnityEngine;

namespace Sprites
{
    public class GosSpriteSwitcher : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;
        private Sprite _currentSprite;

        [SerializeField]
        private Sprite _upSprite;

        [SerializeField]
        private Sprite _downSprite;

        [SerializeField]
        private Sprite _leftSprite;

        [SerializeField]
        private Sprite _rightSprite;



        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            DefaultSprite();
        }

        private void DefaultSprite()
        {
            SwitchSpriteDown();
        }
    
        public void SwitchSpriteUp()
        {
            // Sprite sprite = Resources.Load<Sprite>("Sprites/Player_Back_12.png");
            _currentSprite = _upSprite;
            _spriteRenderer.sprite = _currentSprite;
        }

        public void SwitchSpriteDown()
        {
            // Sprite sprite = Resources.Load<Sprite>("Sprites/Player_Front_12.png");
            _currentSprite = _downSprite;
            _spriteRenderer.sprite = _currentSprite;
        }

        public void SwitchSpriteRight()
        {
            // Sprite sprite = Resources.Load<Sprite>("Sprites/Player_Right_12.png");
            _currentSprite = _rightSprite;
            _spriteRenderer.sprite = _currentSprite;
        }

        public void SwitchSpriteLeft()
        {
            // Sprite sprite = Resources.Load<Sprite>("Sprites/Player_Left_12.png");
            _currentSprite = _leftSprite;
            _spriteRenderer.sprite = _currentSprite;
        }

        public Sprite CurrentSprite()
        {
            return _currentSprite;
        }
    }
}
