using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace RepositoryLayer
{
    public interface IBookingRepository
    {
        List<Booking> GetAll();
        Booking Get(int id);
        int Insert(Booking booking);
        int Update(Booking booking);
        int Delete(int id);
    }
}
