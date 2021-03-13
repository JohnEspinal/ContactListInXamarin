using System;
using System.Collections.Generic;
using System.Text;

namespace ContactListApp.Models
{
    public class ContactData
    {
        public ContactData(string name, string phoneNumber)
        {
            Name = name;
            PhoneNumber = phoneNumber;
        }

        public string Name { get; }
        public string PhoneNumber { get; }
    }
}
