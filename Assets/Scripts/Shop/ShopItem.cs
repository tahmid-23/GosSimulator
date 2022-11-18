using UnityEngine;
using UnityEngine.UI;

namespace Shop
{
    public class ShopItem: MonoBehaviour
    {
        [SerializeField]
        private GameObject imageGameObject;

        [SerializeField]
        private Text text;

        private ShopItemPrice _shopItemPrice;

        void Start()
        {
            SetImage(Resources.Load<Sprite>("Sprites/speech_bubble"));
            SetShopItemPrice(new ShopItemPrice(50));
        }

        public void SetImage(Sprite sprite)
        {
            SpriteRenderer imageRenderer = imageGameObject.GetComponent<SpriteRenderer>();
            imageRenderer.sprite = sprite;
            imageGameObject.transform.localScale = new Vector3(0.71f, 0.71f, 1);
        }

        public void SetShopItemPrice(ShopItemPrice shopItemPrice)
        {
            this._shopItemPrice = shopItemPrice;
            text.text = shopItemPrice.GetCost().ToString();
        }
    }
}