using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Scriptables
{
    [Serializable]
    public class WeaponsData 
    {
        public string ID;
        public string LocalizedName;
        public Sprite IconSprite;
        public int Damage;

        public override string ToString()
        {
            return ID + " : " + LocalizedName + " : " + IconSprite.ToString() + " : " + Damage;
        }
    }
}