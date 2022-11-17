using System;
using System.Collections.Generic;

namespace Dialogue
{
    public class Conversation
    {
        private int _id { get; set; }
        private List<String> _fields { get; set; }

        public Conversation(int id, List<String> fields)
        {
            this._id = id;
            this._fields = fields;
        }

        public int GetID()
        {
            return _id;
        }

        public List<String> GetFields()
        {
            return _fields;
        }
    }
}