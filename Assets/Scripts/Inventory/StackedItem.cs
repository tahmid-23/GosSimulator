using System;

namespace Inventory
{
    public class StackedItem
    {
        private int _amount;
        private String _sprite;
        private double _cost;

        public StackedItem(int amount, string sprite, double cost)
        {
            this._amount = amount;
            this._sprite = sprite;
            this._cost = cost;
        }

        public int GetAmount()
        {
            return _amount;
        }

        public String GetSprite()
        {
            return _sprite;
        }

        public double GetCost()
        {
            return _cost;
        }

        public void SetAmount(int amount)
        {
            _amount = amount;
        }

        public void SetSprite(String sprite)
        {
            _sprite = sprite;
        }

        public void SetCost(double cost)
        {
            this._cost = cost;
        }
    }
}