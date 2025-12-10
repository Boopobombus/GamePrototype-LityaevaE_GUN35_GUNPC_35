using GamePrototype.Dungeon;

namespace GamePrototype.Units
{
    public sealed class Goblin : Unit
    {
        public Goblin(string name, uint health, uint maxHealth, uint baseDamage, uint Armor) : base(name, health, maxHealth, baseDamage, Armor)
        {
        }
        private DifficultySettings difficult = new DifficultySettings();
        /* public override uint GetUnitDamage() => BaseDamage;*/

        public override uint GetUnitDamage()
        {
            
            uint A = difficult.EnemyAttack;
            return BaseDamage * A;
        }

        public override void HandleCombatComplete() => Health = MaxHealth;

        protected override uint CalculateAppliedDamage(uint damage) => damage;

        
        
    }
}
