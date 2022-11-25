using Actions;
using UnityEngine;

namespace Inventory
{
    [CreateAssetMenu(menuName = "Throwable", fileName = "Assets/Resources/Items/Throwable")]
    public class Throwable : Item
    {

        [field: SerializeField]
        public int ParticleCount { get; private set; }

        [field: SerializeField]
        public float ThrowRange { get; private set; }
        
        [field: SerializeField]
        public GameObject ThrownObjectPrefab { get; private set; }

        [field: SerializeField]
        public int Iterations { get; private set; } = 120;
        
        [field: SerializeField]
        public Action Action { get; set; }

        public override void Equip(GameObject player)
        {
            base.Equip(player);
            if (player.TryGetComponent(out ArcRenderer arcRenderer))
            {
                arcRenderer.Throwable = this;
                arcRenderer.enabled = true;
            }
        }

        public override void Unequip(GameObject player)
        {
            base.Equip(player);
            if (player.TryGetComponent(out ArcRenderer arcRenderer))
            {
                arcRenderer.Throwable = null;
                arcRenderer.enabled = false;
            }
        }

        public override void Use(GameObject player)
        {
            Camera mainCamera = Camera.main;
            if (mainCamera == null)
            {
                return;
            }

            Vector3 playerPos = player.transform.position;
            Vector3 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;

            float r = Mathf.Min(Vector3.Distance(playerPos, mousePos), ThrowRange);
            float theta = Mathf.Atan2(mousePos.y - playerPos.y, mousePos.x - playerPos.x);

            GameObject thrownObject = Instantiate(ThrownObjectPrefab);
            FollowThrowArc throwArc = thrownObject.AddComponent<FollowThrowArc>();
            throwArc.StartPosition = playerPos;
            throwArc.EndPosition = new Vector3(r * Mathf.Cos(theta), r * Mathf.Sin(theta));
            throwArc.Iterations = Iterations;
            throwArc.Action = Action;
        }

    }
}