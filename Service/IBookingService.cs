using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace Service
{
    public interface IBookingService
    {
        List<Booking> GetAll();
        Booking Get(int id);
        int Insert(Booking booking);
        int Update(Booking booking);
        int Delete(int id);
    }
}
