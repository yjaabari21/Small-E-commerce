using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelloWorld.Data;

namespace HelloWorld.Services
{
    internal interface IContactService : IRepository<Contact> 
    {
    }
}
