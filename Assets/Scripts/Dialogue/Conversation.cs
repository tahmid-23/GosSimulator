using System;
using System.Collections.Generic;

namespace Dialogue
{
    public class Conversation
    {
        private int _id { get; set; }
        private List<String> _fields { get; set; }

        private List<Response> _responses;

        public Conversation(int id, List<String> fields) : this(id, fields, new List<Response>())
        {
        }

        public Conversation(int id, List<String> fields, List<Response> responses)
        {
            _id = id;
            _fields = fields;
            _responses = responses;
        }

        public int GetID()
        {
            return _id;
        }

        public List<String> GetFields()
        {
            return _fields;
        }

        public List<Response> GetResponses()
        {
            return _responses;
        }
    }
}