using UnityEngine;

namespace Inventory
{
    public class TestAnswers: Item
    {
        void Start()
        {
            this.DisplaySprite = Resources.Load<Sprite>("Sprites/testanswers");
        }
        
        public override void Use()
        {
            
        }

        public override void VisualUpdate()
        {
            
        }
    }
}