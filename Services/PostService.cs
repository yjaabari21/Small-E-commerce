using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HelloWorld.Data;

namespace HelloWorld.Services
{
    public class PostService : Repository<Posts>, IPostService
    {
        public PostService() : base(new MyDBEntities())
        {
        }
    }
}