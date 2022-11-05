namespace Inventory
{
    public class TestGun : Projectile
    {
        public TestGun() : base(10, 2)
        {
        }

        public override void DisplayItem()
        {
            throw new System.NotImplementedException();
        }

        protected override void Use()
        {
            throw new System.NotImplementedException();
        }
    }
}
