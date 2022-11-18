using Inventory;

namespace Shop
{
    public class ShopItemPrice
    {
        private double _cost;

        public ShopItemPrice(double cost)
        {
            this._cost = cost;
        }

        public double GetCost()
        {
            return this._cost;
        }
    }
}