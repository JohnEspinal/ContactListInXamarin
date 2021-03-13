using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ContactListApp.Models
{
    public class ContactGroupCollection : ObservableCollection<ContactData>
    {
        public ContactGroupCollection(string key)
        {
            Key = key;
        }

        public string Key { get; }
    }
}
