namespace Damage
{
    public interface IDamageReceiver
    {

        void ChangeHealth(float delta);

        public float Health { get; }
        
        public float MaxHealth { get; }

        delegate void OnChangeHealth(float delta);
        
        public OnChangeHealth ChangeHealthHandler { get; set; }

    }
}