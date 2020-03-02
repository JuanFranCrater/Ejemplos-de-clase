using System;
using UnityEngine;

namespace Serialization
{
    [Serializable]
    public class PlayerData
    {
        public string ID;
        public int Health;
        public int Armor;
        public int PhysicalDPS;

        public CharacterClass PlayerClass;

        public CharacterStats PlayerStats;

        private string PlayerToken = "DefaultToken";

        public PlayerData(string id, CharacterClass charClass)
        {
            this.ID = id;
            this.Health = 100;
            this.Armor = 10;
            this.PlayerClass = charClass;
            this.PlayerStats = InitPlayerStats(charClass);
            this.PhysicalDPS = CalculatePhysicalDPS();
            this.PlayerToken = PlayerClass.ToString() + PhysicalDPS;
        }
        public PlayerData()
        { }

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
                case CharacterClass.Archer:
                    stats = new CharacterStats(2, 5, 1);
                    break;
                case CharacterClass.Mage:
                    stats = new CharacterStats(1, 3, 5);
                    break;
                case CharacterClass.Warrior:
                    stats = new CharacterStats(5, 3, 1);
                    break;
                default:
                    stats = new CharacterStats(1, 1, 1);
                    break;
            }
            return stats;
        }

        public void RecalculateInternalData()
        {
            this.PhysicalDPS = CalculatePhysicalDPS();
            this.PlayerToken = PlayerClass.ToString() + PhysicalDPS;
        }
    }
}
