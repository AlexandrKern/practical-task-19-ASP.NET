using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApi.Models;

namespace WpfApi
{
    internal interface IContacts
    {
        Contact Contact { get; }
        string Name { get;  }
        string MiddleName { get;  }
        string LastName { get; }
        int PhoneNumber { get;}
        string Address { get;  }
        string Description { get;  }
        void LoadData(List<Contact> contacts);
    }
}
