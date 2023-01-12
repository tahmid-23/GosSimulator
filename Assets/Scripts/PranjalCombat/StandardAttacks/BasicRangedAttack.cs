using PranjalCombat.Projectiles;

namespace PranjalCombat.StandardAttacks
{
    public class BasicRangedAttack : Attack
    {
        private Projectile _projectile;

        public BasicRangedAttack()
        {
            
        }

        public BasicRangedAttack(Projectile projectile)
        {
            this._projectile = projectile;
        }
        
        public void Attack(CombatPosition position1, CombatPosition position2)
        {
            throw new System.NotImplementedException();
        }
    }
}