using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace Serialization
{ 
public class PreferencesManager : Singleton<PreferencesManager>
{
        public int Mouse;

        public bool Muted = false;
        public float Size;
        public string Profilename;

        public const string KEY_MOUSE = "mouse";
        public const string KEY_MUTED = "muted";
        public const string KEY_SIZE = "size";
        public const string KEY_PROFILE_NAME = "profileName";

        public void SavePrefs()
        {
            PlayerPrefs.SetInt(KEY_MOUSE, Mouse);
            PlayerPrefs.SetFloat(KEY_SIZE, Size);
            PlayerPrefs.SetString(KEY_MUTED, Muted.ToString());
            PlayerPrefs.SetString(KEY_PROFILE_NAME, Profilename);

            PlayerPrefs.Save();
        }

        public void LoadPrefs() {

            Mouse = PlayerPrefs.GetInt(KEY_MOUSE);
            Size = PlayerPrefs.GetFloat(KEY_SIZE);
            Profilename = PlayerPrefs.GetString(KEY_PROFILE_NAME);
            bool.TryParse(PlayerPrefs.GetString(KEY_MUTED), out Muted);
        }
    }
}
