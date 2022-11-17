using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using UnityEngine;

namespace Dialogue
{
    public class JSONDialogueParser
    {
        public static void SerializeJSON()
        {
            String jsonString = File.ReadAllText("../../Resources/Dialogues/JPIntro.json");
            List<WholeJSON> texts = JsonConvert.DeserializeObject<List<WholeJSON>>(jsonString);
            
            Console.WriteLine(texts);
        }

        static void Main(string[] args)
        {
            SerializeJSON();
        }
    }

    class WholeJSON
    {
        private IList<Conversation> conversations;
    }

    class Conversation
    {
        private int id;
        private List<String> fields;
    }
}