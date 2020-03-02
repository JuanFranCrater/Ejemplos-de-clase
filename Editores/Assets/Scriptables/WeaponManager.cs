using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scriptables
{
    public class WeaponManager : MonoBehaviour
    {
        public WeaponsDataContainer CurrentWeaponsData;

        private void Start()
        {
            PrintData();
        }

        private void PrintData()
        {
            foreach (WeaponsData weapon in CurrentWeaponsData.Weapons)
            {
                Debug.Log(weapon.ToString());

            }
        }

        public WeaponsData GetWeapon(string id)
        {
            return CurrentWeaponsData.GetWeapon(id);
        }
    }
}