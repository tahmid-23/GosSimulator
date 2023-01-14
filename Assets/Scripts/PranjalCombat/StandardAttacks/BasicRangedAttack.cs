using ProjectilesFolder;

namespace PranjalCombat.StandardAttacks
{
    public class BasicRangedAttack : Attack
    {
        private Projectiles _projectile;

        public BasicRangedAttack()
        {
            
        }

        public BasicRangedAttack(Projectiles projectile)
        {
            this._projectile = projectile;
        }
        
        public void Attack(CombatPosition position1, CombatPosition position2)
        {
            throw new System.NotImplementedException();
        }
    }
}