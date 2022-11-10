using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GosSpriteSwitcher : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private Sprite _currentSprite;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        DefaultSprite();
    }

    public void DefaultSprite()
    {
        SwitchSpriteDown();
    }
    
    public void SwitchSpriteUp()
    {
        Sprite sprite = Resources.Load<Sprite>("Sprites/Asset+27");
        _currentSprite = sprite;
        _spriteRenderer.sprite = sprite;
    }

    public void SwitchSpriteDown()
    {
        Sprite sprite = Resources.Load<Sprite>("Sprites/Asset+26");
        _currentSprite = sprite;
        _spriteRenderer.sprite = sprite;
    }

    public void SwitchSpriteRight()
    {
        Sprite sprite = Resources.Load<Sprite>("Sprites/Asset+28");
        _currentSprite = sprite;
        _spriteRenderer.sprite = sprite;
    }

    public void SwitchSpriteLeft()
    {
        Sprite sprite = Resources.Load<Sprite>("Sprites/Asset+29");
        _currentSprite = sprite;
        _spriteRenderer.sprite = sprite;
    }

    public Sprite CurrentSprite()
    {
        return _currentSprite;
    }
}
