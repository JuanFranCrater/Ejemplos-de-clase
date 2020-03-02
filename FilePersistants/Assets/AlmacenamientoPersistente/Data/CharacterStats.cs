using System;

namespace Serialization
{
    [Serializable]
    public class CharacterStats
    {
        public int Strength; 
        public int Dexterity;
        public int Wisdom;

        public CharacterStats(int str, int dex, int wis)
        {
            Strength = str;
            Dexterity = dex;
            Wisdom = wis;
        }
        public CharacterStats()
        { 
        }
    }
}