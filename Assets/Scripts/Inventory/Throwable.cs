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

    }
}