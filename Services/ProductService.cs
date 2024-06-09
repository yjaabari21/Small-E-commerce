using System;
using System.Linq;
using HelloWorld.Data;

namespace HelloWorld.Services
{
    public class ProductService : Repository<Product>, IProductService
    {
        public ProductService() : base(new MyDBEntities())
        {
        }

        public Product GetByName(String name)
        {
            return Table.Where(a => a.Name == name).FirstOrDefault();
        }

    }
}
