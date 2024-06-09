using HelloWorld.Data;

namespace HelloWorld.Services
{
    public class Offerservice : Repository<Offers>, IOfferservice
    {
        public Offerservice() : base(new MyDBEntities())
        {
        }
    }
}