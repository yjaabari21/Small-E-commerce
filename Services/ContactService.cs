using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HelloWorld.Data;

namespace HelloWorld.Services
{
    public class ContactService : Repository<Contact> , IContactService
    {
        public ContactService() : base(new MyDBEntities())
        { 
        }
    }
}