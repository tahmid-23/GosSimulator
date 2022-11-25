using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace NPCData
{
    public static class SaveNPCDialogue
    {
        public static void SaveDialogue(NPCDialogueData _npcDialogueData, string filename)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            string path = Application.persistentDataPath + filename;
            FileStream stream = new FileStream(path, FileMode.Create);
            
            formatter.Serialize(stream, _npcDialogueData);
            
            stream.Close();
        }

        public static NPCDialogueData LoadNPCDialogue(string filename)
        {
            if (File.Exists(filename))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(filename, FileMode.Open);
                
                NPCDialogueData data = formatter.Deserialize(stream) as NPCDialogueData;
                stream.Close();

                return data;
            }
            else
            {
                Debug.LogError("Save file not found in " + filename);
                return null;
            }
        }
    }
}