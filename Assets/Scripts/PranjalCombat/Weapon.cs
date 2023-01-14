namespace PranjalCombat
{
    public abstract class Weapon
    {
        private WeaponInterface _weaponInterface;

        protected Weapon()
        {
            
        }

        protected Weapon(WeaponInterface weaponInterface)
        {
            this._weaponInterface = weaponInterface;
        }

        protected void ActivateInterface()
        {
            _weaponInterface.ActivateInterface();
        }

        protected void DeactivateInterface()
        {
            _weaponInterface.DeactivateInterface();
        }

        public WeaponInterface GetWeaponInterface()
        {
            return _weaponInterface;
        }
    }
}