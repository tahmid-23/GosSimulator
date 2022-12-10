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
    public static class JSONDialogueParser
    {
        private static List<Conversation> SerializeJSON(string jsonName)
        {
            string filepath = "Dialogues/" + jsonName;
            string jsonString = Resources.Load<TextAsset>(filepath).ToString();
            // String jsonString = Resources.LoadAll<TextAsset>("Dialogues/")[0].ToString();
            JArray jArray = JArray.Parse(jsonString);
            
            List<Conversation> list = new List<Conversation>();

            foreach (JObject jObject in jArray)
            {
                JArray fieldsList = (JArray) jObject["fields"];
                List<Response> rlist = new List<Response>();
                JArray responseList = (JArray) jObject["responses"];
                if (!(responseList is null))
                {
                    foreach (JObject r in responseList)
                    {
                        rlist.Add(new Response((string) r["response"], (int) r["id"]));
                    }
                }
                list.Add(new Conversation((int) jObject["id"], fieldsList.ToObject<List<string>>(), rlist));
            }

            // IList<Conversation> texts = JsonSerializer.Deserialize<IList<Conversation>>(jsonString);
            return list;
        }

        public static Conversation GetDialogueByID(string jsonName, int id)
        {
            return SerializeJSON(jsonName)[id - 1];
        }
    }
}