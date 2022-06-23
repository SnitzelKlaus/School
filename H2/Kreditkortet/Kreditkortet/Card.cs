using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kreditkortet
{
    public class Card
    {
        public string Number { get => _number; set => _number = value; }
        public bool IsValid { get => _isValid; set => _isValid = value; }

        private string _number;
        private bool _isValid;

        public Card(string number)
        {
            Number = number;
        }
    }
}
