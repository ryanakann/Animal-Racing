using System.Collections.Generic;
using Core.Interfaces;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Core
{
    public static class SaveManager
    {
        private static Dictionary<string, string> _dataDict;

        public static void InitDict()
        {
            if (_dataDict == null) _dataDict = new Dictionary<string, string>();
        }
        
        public static void SaveObject(string id, string data)
        {
            if (_dataDict.ContainsKey(id))
            {
                _dataDict[id] = data;
            }
            else
            {
                _dataDict.Add(id, data);
            }
        }

        public static string LoadObject(string id) => _dataDict.ContainsKey(id) ? _dataDict[id] : null;

        public static void SaveGame()
        {
            using (var stream = File.Create(Path.Combine(Application.persistentDataPath, "data.dat"))) 
            { 
                BinaryFormatter bf = new BinaryFormatter(); 
                bf.Serialize(stream, _dataDict);
            }
        }

        public static void LoadGame()
        {
            using (var stream = File.Open(Path.Combine(Application.persistentDataPath, "data.dat"), FileMode.Open)) 
            { 
                BinaryFormatter bf = new BinaryFormatter();
                _dataDict = (Dictionary<string, string>) bf.Deserialize(stream);
            }
        }
    }
}
