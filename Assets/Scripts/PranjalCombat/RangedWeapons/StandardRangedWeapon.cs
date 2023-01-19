using PranjalCombat.SpecialAttacks;
using StandardAttacks;
using UnityEngine;
using UnityEngine.UI;
using WeaponInterfaces;

namespace PranjalCombat.RangedWeapons
{
    public class StandardRangedWeapon : Range
    {
        public StandardRangedWeapon() : base(10, 10, new BasicRangedAttack(), new SpecialBasicRangedAttack())
        {
            
        }
    }
}