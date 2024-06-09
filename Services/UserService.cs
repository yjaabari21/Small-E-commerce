using System;
using System.Data.Entity;
using System.Linq;
using HelloWorld.Data;

namespace HelloWorld.Services
{
    public class UserService : Repository<User>, IUserService
    {
        public UserService() : base(new MyDBEntities())
        {
        }

        public User GetByEmail(string email)
        {
            return Table.Where(a => a.Email == email).FirstOrDefault();
        }
    }
}