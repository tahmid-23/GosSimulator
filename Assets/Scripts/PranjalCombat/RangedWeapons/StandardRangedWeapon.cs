using PranjalCombat.SpecialAttacks;
using PranjalCombat.StandardAttacks;
using WeaponInterfaces;

namespace PranjalCombat.RangedWeapons
{
    public class StandardRangedWeapon : Range
    {
        public StandardRangedWeapon() : base(10, 10, new BasicRangedAttack(), new SpecialBasicRangedAttack(), new BasicRangedInterface())
        {
            
        }
    }
}