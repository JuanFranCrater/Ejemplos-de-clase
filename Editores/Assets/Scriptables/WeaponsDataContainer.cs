using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Scriptables
{
    [CreateAssetMenu(fileName = "WeaponsData", menuName = "DataObject/WeaponsData")]
    public class WeaponsDataContainer : ScriptableObject
    {
        public List<WeaponsData> Weapons;
        public WeaponsData GetWeapon(string id)
        {
            bool found = false;

            WeaponsData weapon = null;

            for (int i = 0; i < Weapons.Count && !found; i++)
            {
                if (Weapons[i].ID == id)
                {
                    weapon = Weapons[i];
                    found = true;
                }
            }
            return weapon;
        }
    }
}