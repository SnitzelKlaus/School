using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymetricalEncryption.Models
{
    public class Message
    {
        public Message(int id, string text, string iv, string key)
        {
            _id = id;
            _text = text;
            _iv = iv;
            _key = key;
        }

        private int _id;
        private string _text;
        private string _iv;
        private string _key;

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
            }
        }

        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
            }
        }

        public string IV
        {
            get { return _iv; }
            set
            {
                _iv = value;
            }
        }

        public string Key
        {
            get { return _key; }
            set
            {
                _key = value;
            }
        }
    }
}
