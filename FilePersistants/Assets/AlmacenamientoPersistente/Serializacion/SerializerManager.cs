using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using Utils;
using System.Xml.Serialization;
using System.Xml;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Serialization
{
    public class SerializerManager : Singleton<SerializerManager>
    {
        public PlayerData Player;

        private PlayerData CreatePlayer()
        {
            return new PlayerData("JaviCepa", CharacterClass.Mage);
        }

        public void Serialize(PlayerData playerData, SerializationMode mode)
        {
            switch (mode)
            {
                case SerializationMode.Binary:
                    SerializeBinary(playerData);
                    break;
                case SerializationMode.XML:
                    SerializeXML(playerData);
                    break;
                case SerializationMode.JSON:
                    SerializeJSON(playerData);
                    break;
            }
        }
        public PlayerData Deserialize(SerializationMode mode)
        {
            PlayerData playerData;
            switch (mode)
            {
                case SerializationMode.Binary:
                    playerData = DeserializeBinary("playerDataBIN.dat");
                    break;
                case SerializationMode.XML:
                    playerData = DeserializeXML("playerDataBIN.xml");
                    break;
                case SerializationMode.JSON:
                    playerData = DeserializeJSON("playerDataJSON.json");
                    break;
                default:
                    playerData = null;
                    break;
            }
            return playerData;
        }

        #region BINARY
        public void BinaryTest()
        {
            PlayerData currentPlayer = CreatePlayer();

            Serialize(currentPlayer, SerializationMode.Binary);

            Player = Deserialize(SerializationMode.Binary);

            Debug.Log("PhysicalDPs: " + Player.PhysicalDPS);
            Debug.Log("Player Token: " + Player.GetToken());
        }

        private void SerializeBinary()
        {
            Serialize(Player, SerializationMode.Binary);
        }

        private void SerializeBinary(PlayerData playerData)
        {
            //Abrimos el archivo
            FileStream fs = new FileStream("PlayerDataBIN.dat", FileMode.Create);

            //Declaramos el serializador
            BinaryFormatter formater = new BinaryFormatter();

            //Serializamos los datos en el fichero
            formater.Serialize(fs, playerData);

            //Cerramos el archivo
            fs.Close();
        }

        private PlayerData DeserializeBinary(string file)
        {
            //Abrir el fichero con los datos
            FileStream fs = new FileStream(file, FileMode.Open);

            //Declaramos el serializador
            BinaryFormatter formatter = new BinaryFormatter();

            //Deserializamos el fichero
            PlayerData playerData = (PlayerData)formatter.Deserialize(fs);

            //Cerramos el archivo
            fs.Close();

            return playerData;
        }

        private void DeserializeBinary()
        {
            Player = DeserializeBinary("PlayerDataBIN.dat");
        }

        #endregion

        #region XML
        public void XMLTest()
        {
            PlayerData currentPlayer = CreatePlayer();

            Serialize(currentPlayer, SerializationMode.XML);

            Player = Deserialize(SerializationMode.XML);

            Debug.Log("PhysicalDPs: " + Player.PhysicalDPS);
            Debug.Log("Player Token: " + Player.GetToken());
        }
        private void SerializeXML(PlayerData playerData)
        {
            //Abrimos el archivo
            StreamWriter fs = new StreamWriter("PlayerDataBIN.xml");

            //Declaramos el serializador
            XmlSerializer serializer = new XmlSerializer(typeof(PlayerData));

            //Serializamos los datos en el fichero
            serializer.Serialize(fs, playerData);

            //Cerramos el archivo
            fs.Close();
        }

        private PlayerData DeserializeXML(string file)
        {
            //Abrimos el archivo
            FileStream fs = new FileStream(file, FileMode.Open);

            ///Declaramos el serializador
            XmlSerializer serializer = new XmlSerializer(typeof(PlayerData));

            //Deserializamos el fichero
            PlayerData playerData = (PlayerData)serializer.Deserialize(fs);

            //Cerramos el archivo
            fs.Close();

            //Para desearializar Datos que no han sido guardados
            playerData.RecalculateInternalData();

            return playerData;
        }

        public void NavigateXML(string file)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(file);

            XmlNodeList nameNodes = doc.DocumentElement.SelectNodes("//Name");

            if (nameNodes != null)
            {
                foreach (XmlNode node in nameNodes)
                {
                    Debug.Log(node.Name + ": " + node.InnerText);
                }
            }

            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                string name = node.Name;
                string text = node.InnerText;
                string value = node.ChildNodes[0].InnerText;
                string attr = node.Attributes["rarity"]?.InnerText;
                Debug.Log(name + " : " + value + " - " + attr + "[" + text + "]");
            }

        }
        #endregion

        #region JSON
        public void JSONTest()
        {
            PlayerData currentPlayer = CreatePlayer();

            Serialize(currentPlayer, SerializationMode.JSON);

            Player = Deserialize(SerializationMode.JSON);

            Debug.Log("PhysicalDPs: " + Player.PhysicalDPS);
            Debug.Log("Player Token: " + Player.GetToken());
        }
        private void SerializeJSON(PlayerData playerData)
        {
            // Abrimos el archivo
            StreamWriter writer = new StreamWriter("playerDataJSON.json");
            
            //Serializamos
            string playerJSON = JsonUtility.ToJson(playerData);

            // Escribimos los datos en el fichero
            writer.Write(playerJSON);

            //Cerramos el archivo
            writer.Close();

        }

        private PlayerData DeserializeJSON(string file)
        {
            StreamReader fs = new StreamReader(file);

            PlayerData player = JsonUtility.FromJson<PlayerData>(fs.ReadToEnd());
            //Si hereda de monobehaviour
            PlayerData player2 = new PlayerData();
            JsonUtility.FromJsonOverwrite(fs.ReadToEnd(), player2);

            player.RecalculateInternalData();
            fs.Close();

            return player;

        }
        #endregion

        #if UNITY_EDITOR
        [CustomEditor(typeof(SerializerManager))]
        public class SerializerEditor : Editor
        {
            public override void OnInspectorGUI()
            {
                DrawDefaultInspector();

                GUIStyle style = new GUIStyle();
                style.fontStyle = FontStyle.Bold;
                style.alignment = TextAnchor.MiddleCenter;

                GUILayout.Label("");
                GUILayout.Label("Serializer tools", style);
                GUILayout.Label("");

                if (GUILayout.Button("Serializer And Desearializer by Binary Test"))
                {
                    Instance.BinaryTest();
                }
                if (GUILayout.Button("Serializer And Desearializer by XML Test"))
                {
                    Instance.XMLTest();
                }
                if (GUILayout.Button("Serializer And Desearializer by JSON Test"))
                {
                    Instance.JSONTest();
                }
                if (GUILayout.Button("Navigate XML"))
                {
                    Instance.NavigateXML("WeaponsData.xml");
                }
            }
        }
        #endif
    }
}
