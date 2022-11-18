namespace Inventory
{
    public class StackedItem
    {
        private int _amount;
        private Item _item;

        public StackedItem(int amount, Item item)
        {
            _amount = amount;
            _item = item;
        }

        public int GetAmount()
        {
            return _amount;
        }

        public Item GetItem()
        {
            return _item;
        }
    }
}