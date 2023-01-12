namespace PranjalCombat
{
    public interface WeaponInterface
    {
        void ActivateInterface();
        
        void DeactivateInterface();
        
        void UpdateInterface();

        void SetWeapon(Weapon weapon);
    }
}