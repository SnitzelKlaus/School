using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBanker
{
    public abstract class CardOwner
    {
        private string _name;
        private string _age;
        private string _socialSecurityNumber;

        public string Name { get => _name; set => _name = value; }
        public string Age { get => _age; set => _age = value; }
        public string SocialSecutiryNumber { get => _socialSecurityNumber; set => _socialSecurityNumber = value; }


    }
}
