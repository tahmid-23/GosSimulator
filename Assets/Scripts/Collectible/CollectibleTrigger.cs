using Inventory;
using UnityEngine;
using Action = Actions.Action;

namespace Collectible
{
    public class CollectibleTrigger : MonoBehaviour
    {

        [SerializeField]
        private Collider2D collectionBounds;

        [SerializeField]
        private ItemStack reward;

        [SerializeField]
        private Action onCollect;

        private Camera _mainCamera;

        private Collider2D _itemBounds;

        private void Awake()
        {
            _mainCamera = Camera.main;
            _itemBounds = GetComponent<Collider2D>();
        }

        private void Update()
        {
            if (!Input.GetMouseButtonDown(0))
            {
                return;
            }
            
            GameObject player = GameObject.FindWithTag("Player");
            if (player == null)
            {
                return;
            }

            Collider2D playerCollider = player.GetComponent<Collider2D>();
            if (!Physics2D.IsTouching(collectionBounds, playerCollider))
            {
                return;
            }

            if (!_itemBounds.OverlapPoint(_mainCamera.ScreenToWorldPoint(Input.mousePosition)))
            {
                return;
            }
            
            player.GetComponent<PlayerInventory>().AddItem(reward);
            if (onCollect != null)
            {
                onCollect.Run(player);
            }
            Destroy(gameObject);
        }

    }
}