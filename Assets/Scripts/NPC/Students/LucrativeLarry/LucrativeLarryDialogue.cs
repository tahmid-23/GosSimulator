using Shop;
using UnityEngine;

namespace NPC.Students.LucrativeLarry
{
    public class LucrativeLarryDialogue: NPCBase
    {
        [SerializeField]
        private ShopBehaviour _shopBehaviour;
        
        public LucrativeLarryDialogue() : base(Classification.Neutral, 100, 1000, 1, "LucrativeLarry")
        {
            
        }

        protected override void BetweenInteractions()
        {
            if (_currentInteractionIndex == 0)
            {
                //GetComponent<ShopBehaviour>().EnableShop();
        		_shopBehaviour.EnableShop();
            }
        }
    }
}
