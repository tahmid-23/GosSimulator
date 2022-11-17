using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace Dialogue
{
    public class JSONDialogueParser
    {
        public static List<Conversation> SerializeJSON(String jsonName)
        {
            String filepath = "Dialogues/" + jsonName;
            String jsonString = Resources.Load<TextAsset>(filepath).ToString();
            // String jsonString = Resources.LoadAll<TextAsset>("Dialogues/")[0].ToString();
            JArray jArray = JArray.Parse(jsonString);

            Debug.Log(jsonString);
            List<Conversation> list = new List<Conversation>();

            foreach (JObject jObject in jArray)
            {
                JArray _fieldsList = (JArray) jObject["fields"];
                list.Add(new Conversation((int) jObject["id"], _fieldsList.ToObject<List<String>>()));
            }

            // IList<Conversation> texts = JsonSerializer.Deserialize<IList<Conversation>>(jsonString);
            return list;
        }

        public static Conversation GetDialogueByID(String jsonName, int id)
        {
            return SerializeJSON(jsonName)[id - 1];
        }
    }
}