using Data;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Tools
{
   

    public class PlayerEditor : EditorWindow
    {
        #region Player Variables
        string m_PlayerID = "You can find me in AllPlayers.txt";

        int m_PlayerHealth = 100;
        int m_PlayerArmor = 50;

        CharacterClass m_CharClass;
        CharacterStats m_Stats;

        int m_Str;
        int m_Dex;
        int m_Int;

        float m_Overpowered = 1;
        bool m_IsImmortal = false;

        #endregion

        #region Editor Variables 
        
        bool m_CustomStats = false;
        bool m_AdminMode = false;

        string m_KeyID = "\"ID\"";
        string m_KeyHealth = "\"Health\"";
        string m_KeyArmor = "\"Armor\"";
        string m_KeyClass = "\"Class\"";
        //string m_KeyStats = "\"Stats\"";

        #endregion

        [MenuItem("Game/PlayerEditor")]
        public static void ShowWindow()
        {
            //Show existing window instance. If one doesn't exits, make one!
            EditorWindow window = EditorWindow.GetWindow(typeof(PlayerEditor));
            window.minSize = new Vector2(400, 350);
            window.titleContent = new GUIContent("Creador de personajes");
        }

        private void OnGUI()
        {
            ShowBaseSettings();

            ShowSpecialSettings();

            ShowAdminSettings();

            ShowPlayerJSON();

            ShowButtons();

        }

        #region Base
        private void ShowBaseSettings()
        {
            ShowHeader("Base Settings");
            ShowPlayerFields();
        }

        private void ShowPlayerFields()
        {
            m_PlayerID = EditorGUILayout.TextField("Player ID: ", m_PlayerID);
            m_PlayerHealth = EditorGUILayout.IntField("Health: ", m_PlayerHealth);
            m_PlayerArmor = EditorGUILayout.IntField("Armor: ", m_PlayerArmor);
            m_CharClass = (CharacterClass)EditorGUILayout.EnumPopup("Class: ", m_CharClass);

        }
        #endregion

        #region Special
        private void ShowSpecialSettings()
        {
            ShowCustomStats();
        }

        private void ShowCustomStats()
        {
            m_CustomStats = EditorGUILayout.Toggle("Edit Stats: ", m_CustomStats);

            if (m_CustomStats)
            {
                ShowCustomStatsFields();
            }
            else
            { 
                ResetCustomStats();
            }
        }

        private void ResetCustomStats()
        {
            m_Str = 0;
            m_Dex = 0;
            m_Int = 0;
        }

        private void ShowCustomStatsFields()
        {
            m_Str = EditorGUILayout.IntField("Strength: ", m_Str);
            m_Dex = EditorGUILayout.IntField("Desxterity: ", m_Dex);
            m_Int = EditorGUILayout.IntField("Wisdom: ", m_Int);
        }
        #endregion

        #region Admin
        private void ShowAdminSettings()
        {
            m_AdminMode = EditorGUILayout.BeginToggleGroup("Edit Stats: ", m_AdminMode);
            m_Overpowered = EditorGUILayout.Slider("Overpowered: ", m_Overpowered, 0, 3);
            m_IsImmortal = EditorGUILayout.Toggle("Make Immortal: ", m_IsImmortal);
            EditorGUILayout.EndToggleGroup();
        }
        #endregion

        #region JSON
        private void ShowPlayerJSON()
        {
            ShowHeader("Player JSON");
            EditorGUILayout.TextArea(GenerateJSON(), TextAreaStyle(), GUILayout.Height(50));
        }

        private string GenerateJSON()
        {
            string playerJSON = "{"
                +m_KeyID+ ":" + "\"" + m_PlayerID + "\"" + "," 
                +m_KeyHealth + ":" + "\"" + m_PlayerHealth + "\"" + "," 
                +m_KeyArmor + ":" + "\"" + m_PlayerArmor + "\"" + "," 
                +m_KeyClass + ":" + "\"" + m_CharClass.ToString() + "\"" 
                +"}";

            return playerJSON;
        }
        #endregion

        #region Buttons
        private void ShowButtons()
        {
            ShowHeader("Buttons");
            ExportJSONButton();
        }

        private void ExportJSONButton()
        {
            if (GUILayout.Button("Export Player Data"))
            {
                Debug.Log(GenerateJSON());
            }
        }
        #endregion

        #region Utils

        private void ShowHeader(string name)
        {
            GUILayout.Space(10);
            GUILayout.Label(name, HeaderStyle());
            GUILayout.Space(10);
        }

        private GUIStyle HeaderStyle()
        {
            GUIStyle style = new GUIStyle();
            style.fontStyle = FontStyle.Bold;
            style.alignment = TextAnchor.MiddleCenter;

            return style;
        }
        private GUIStyle TextAreaStyle()
        {
            GUIStyle style = EditorStyles.textArea;

            style.wordWrap = true;

            return style;
        }

        #endregion
    }
}
