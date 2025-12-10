using GamePrototype.Dungeon;
using GamePrototype.Items.EconomicItems;
using GamePrototype.Items.EquipItems;
using GamePrototype.Utils;
using static System.Net.Mime.MediaTypeNames;

namespace GamePrototype.Units
{
    public abstract class Unit
    {
        private const int INVENTORY_SIZE = 3;
        private uint _health;
        private uint _maxHealth;
        protected uint BaseDamage;
        protected Inventory Inventory;
        protected uint _durability;
        private DifficultySettings _difficult; /*= new DifficultySettings();*/
        
       




        public uint baseDamage
        {  get => BaseDamage; 
           set => BaseDamage = value; }

        

        public uint Armour 
        { 
            get => _durability; 
            set => _durability = value; 
        }

       

        public string Name { get; private set; }
        public uint Health
        {
            get => _health;
            protected set => _health = value;
        }

       


        public uint MaxHealth => _maxHealth;

        protected Unit(string name, uint health, uint maxHealth, uint baseDamage, uint Armor) 
        {
            Name = name;
            _health = health;
            _maxHealth = maxHealth;
            BaseDamage = baseDamage;
            Inventory = new Inventory(INVENTORY_SIZE);
            _durability = Armor;
            
        }

        public void ApplyDamage(uint damage)
        {
            var damageApplied = CalculateAppliedDamage(damage);
            if (_health < damageApplied || (_health - damageApplied) <= 0) 
            {
                _health = 0;
            }
            else 
            {
                _health -= damageApplied;
            }
            
            DamageReceiveHandler();
        }
        public uint ArmorDamage (uint damage)
        {
            var damageArmor = CalculateAppliedDamage(damage);
            if (damage > 0 && _durability > 1)
            {
                _durability = _durability - 1;
                Console.WriteLine($"Armor = {_durability}");
                return _durability;
            }
            else if (damage == 0)
            {
                _durability = _durability+0;
                return _durability;
            }
            else if (damage > 0 && _durability == 1)
            {
                _durability = _durability - 1;
                Console.WriteLine("Броня разрушена");
                return _durability;
            }
            else
            { return 0; }
        }

        /*public uint WeaponDamage(uint damage)
        {
            var damageWeapon = CalculateAppliedDamage(damage);
            if (damage >0 && _durability > 1)
            { .ReduceDurability(1); }
        }*/
        protected virtual uint CalculateAppliedDamage(uint damage)                                       // Было protected abstract uint CalculateAppliedDamage(uint damage);
        {
            damage = damage * _difficult.EnemyAttack;

            return damage;
        }

       


        protected virtual void DamageReceiveHandler() { }
        
        public abstract uint GetUnitDamage();

        public abstract void HandleCombatComplete();

        public virtual void AddItemToInventory(Item item) 
        {
            if (!Inventory.TryAdd(item)) 
            {
                Console.WriteLine($"Inventory of {Name} is full");
                Inventory.ReplaceItem(item);
            }
        }

        public void AddItemsFromUnitToInventory(Unit unit)
        {
            for (int i = 0; i < unit.Inventory.Items.Count; i++) 
            {
                if (!Inventory.TryAdd(unit.Inventory.Items[i])) 
                {
                    //inventory is full
                    return;
                }
            }
        }





    }
}
