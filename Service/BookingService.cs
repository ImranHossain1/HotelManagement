using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using RepositoryLayer;

namespace Service
{
    public class BookingService : IBookingService
    {
        private BookingRepository repo = new BookingRepository();

        public List<Booking> GetAll()
        {
            return repo.GetAll();
        }

        public Booking Get(int id)
        {
            return repo.Get(id);
        }

        public int Insert(Booking booking)
        {
            return repo.Insert(booking);
        }

        public int Update(Booking booking)
        {
            return repo.Update(booking);
        }

        public int Delete(int id)
        {
            return repo.Delete(id);
        }
    }
}
