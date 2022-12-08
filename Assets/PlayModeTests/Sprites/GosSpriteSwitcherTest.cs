using NUnit.Framework;
using Sprites;
using UnityEngine;

namespace PlayModeTests.Sprites
{
    public class GosSpriteSwitcherTest
    {

        private Sprite left = Sprite.Create(null, Rect.zero, Vector2.zero),
            right = Sprite.Create(null, Rect.zero, Vector2.zero),
            up = Sprite.Create(null, Rect.zero, Vector2.zero),
            down = Sprite.Create(null, Rect.zero, Vector2.zero);

        private GameObject _root;

        private GosSpriteSwitcher spriteSwitcher;

        [SetUp]
        public void SetUpDamageReceiver()
        {
            _root = new GameObject();
            _root.AddComponent<SpriteRenderer>();
            spriteSwitcher = _root.AddComponent<GosSpriteSwitcher>();
            spriteSwitcher._upSprite = up;
            spriteSwitcher._downSprite = down;
            spriteSwitcher._leftSprite = left;
            spriteSwitcher._rightSprite = right;
        }

        [TearDown]
        public void TearDown()
        {
            GameObject.Destroy(_root);
        }

        [Test]
        public void TestUp()
        {
            spriteSwitcher.SwitchSpriteUp();

            Assert.AreEqual(up, spriteSwitcher.CurrentSprite());
        }

        [Test]
        public void TestDown()
        {
            spriteSwitcher.SwitchSpriteDown();

            Assert.AreEqual(down, spriteSwitcher.CurrentSprite());
        }

        [Test]
        public void TestLeft()
        {
            spriteSwitcher.SwitchSpriteLeft();

            Assert.AreEqual(left, spriteSwitcher.CurrentSprite());
        }

        [Test]
        public void TestRight()
        {
            spriteSwitcher.SwitchSpriteRight();

            Assert.AreEqual(right, spriteSwitcher.CurrentSprite());
        }

    }

}