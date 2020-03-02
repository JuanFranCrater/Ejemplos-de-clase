using System;

namespace Data
{
    public class PlayerData 
    {
        public string ID;

        public int Health;
        public int Armor;

        public CharacterClass PlayerClass;
        public CharacterStats PlayerStats;

        private int PhysicalDPS;

        private string PlayerToken = "DefaultToken";

        public PlayerData(string id, CharacterClass charClass)
        {
            Init(id, 100, 10, charClass, null);
        } 

        public PlayerData(string id, int health, int armor, CharacterClass charClass, CharacterStats stats)
        {
            Init(id, health, armor, charClass, stats);
        }

        private void Init(string id, int health, int armor, CharacterClass charClass, CharacterStats stats)
        {
            InitVariableData(id, health, armor, charClass, stats);
            InitInternalData();
        }

        private void InitVariableData(string id, int health, int armor, CharacterClass charClass, CharacterStats stats = null)
        {
            this.ID = id;
            this.Health = health;
            this.Armor = armor;
            this.PlayerClass = charClass;
            this.PlayerStats = (stats == null ? InitPlayerStats(charClass) : stats);
        }

        private void InitInternalData()
        {
            this.PhysicalDPS = CalculatePhysicalDPS();
            this.PlayerToken = PlayerClass.ToString() + PhysicalDPS;
        }

        public void RecalculateInternalData()
        {
            PhysicalDPS = CalculatePhysicalDPS();
        }

        private int CalculatePhysicalDPS()
        {
            return (PlayerStats.Strength * 5 + PlayerStats.Dexterity * 2 + PlayerStats.Wisdom);
        }

        public string GetToken()
        {
            return PlayerToken;
        }

        private CharacterStats InitPlayerStats(CharacterClass charClass)
        {
            CharacterStats stats;

            switch (charClass)
            {
                case CharacterClass.Warrior:
                    stats = new CharacterStats(5, 3, 1);
                    break;

                case CharacterClass.Archer:
                    stats = new CharacterStats(2, 5, 2);
                    break;

                case CharacterClass.Mage:
                    stats = new CharacterStats(1, 3, 5);
                    break;

                default:
                    stats = new CharacterStats(1, 1, 1);
                    break;
            }

            return stats;
        }

    }
}