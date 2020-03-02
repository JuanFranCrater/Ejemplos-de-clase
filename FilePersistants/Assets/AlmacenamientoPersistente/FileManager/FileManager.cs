using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Utils;

#if UNITY_EDITOR
    using UnityEditor;
#endif

namespace Serialization
{
    public class FileManager : Singleton<FileManager>
    {
        public string SavePath = @"C:\Users\Usuario\Desktop\FileManager";

        public string Key;
        public string Password;
        public string Text;

        #region File
        public void CreateKey(string keyID, string keyPassword)
        {
            string file = GenerateFilePath(keyID);

            if (!File.Exists(file))
            {
                File.WriteAllText(file, keyID + ":" + keyPassword);
            }

        }
        public string ReadKey(string KeyID)
        {
            string file = GenerateFilePath(KeyID);
            string content = string.Empty;

            if (File.Exists(file))
            {
                content = File.ReadAllText(file);
            }

            return content;
        }

        public string ReadFirstLine(string keyID)
        {
            string filePath = GenerateFilePath(keyID);
            string[] content;
            string line = string.Empty;

            if (File.Exists(filePath))
            {
                content = File.ReadAllLines(filePath);
                line = (content.Length > 0 ? content[0] : string.Empty);
            }

            return line;
        }

        private string GenerateFilePath(string name)
        {
            return SavePath + "\\" + name + ".txt";
        }

        #endregion

        #region TEST
        public void CreateKey()
        {
            CreateKey(Key, Password);
        }
        public void ReadKey()
        {
            Debug.Log(ReadKey(Key));
        }
        public void ReadFirstLine()
        {
            Debug.Log(ReadFirstLine(Key));
        }
        public void SlowReading()
        {
            SlowReading(Key);
        }

        public void Write()
        {
            Write(Key, Text);
        }
        #endregion

        #region STREAM
        public void SlowReading(string name)
        {
            StartCoroutine(ReadFile(GenerateFilePath(name), 1f));
        }

        public void Write(string filename, string text)
        {
            StreamWriter writer = new StreamWriter(GenerateFilePath(filename), true);

            writer.WriteLine(text);

            writer.Close();
        }

        IEnumerator ReadFile(string file, float delay)
        {
            StreamReader reader = new StreamReader(file);
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                Debug.Log(line);
                yield return new WaitForSeconds(delay);
            }
            reader.Close();
        }

           
        #endregion


       #if UNITY_EDITOR
        [CustomEditor(typeof(FileManager))]
        public class FileEditor : Editor {
            public override void OnInspectorGUI()
            {
                DrawDefaultInspector();

                GUIStyle style = new GUIStyle();
                style.fontStyle = FontStyle.Bold;
                style.alignment = TextAnchor.MiddleCenter;

                GUILayout.Label("");
                GUILayout.Label("File tools",style);
                GUILayout.Label("");

                if (GUILayout.Button("Send Key To Real World"))
                {
                    Instance.CreateKey();
                }
                if (GUILayout.Button("Read Key From Real World"))
                {
                    Instance.ReadKey();
                }
                if (GUILayout.Button("Read First Line Of Key From Real World"))
                {
                    Instance.ReadFirstLine();
                }
                if (GUILayout.Button("Read Lines Each Second Of Key From Real World"))
                {
                    Instance.SlowReading();
                }
                if (GUILayout.Button("Write Text In Key To Real World"))
                {
                    Instance.Write();
                }
            }
        }
        #endif

    }
}
