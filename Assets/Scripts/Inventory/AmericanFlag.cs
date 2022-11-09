using System.Buffers.Text;
using UnityEngine;

namespace Inventory
{
    public class AmericanFlag: Melee
    {
        private Sprite _sprite = Resources.Load<Sprite>("Sprites/flag");
        public AmericanFlag() : base(10, 1, 2)
        {
            
        }

        protected override void Use()
        {
            
        }

        public override Sprite DisplayItem()
        {
            Debug.Log(_sprite);
            return _sprite;
        }
    }
}