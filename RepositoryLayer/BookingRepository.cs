using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace RepositoryLayer
{
    public class BookingRepository : IBookingRepository
    {
        private DataContext context;

        public BookingRepository() { this.context = new DataContext(); }

        public List<Booking> GetAll()
        {
            return this.context.Bookings.ToList();
        }

        public Booking Get(int id)
        {
            return this.context.Bookings.SingleOrDefault(e => e.BookingId == id);
        }

        public int Insert(Booking booking)
        {
            this.context.Bookings.Add(booking);
            return this.context.SaveChanges();
        }

        public int Update(Booking booking)
        {
            Booking bookingToUpdate = this.context.Bookings.SingleOrDefault(e => e.BookingId == booking.BookingId);

            bookingToUpdate.CustomerId = booking.CustomerId;
            bookingToUpdate.RoomAvId = booking.RoomAvId;
            bookingToUpdate.TotalCost = booking.TotalCost;


            return this.context.SaveChanges();
        }

        public int Delete(int id)
        {
            Booking bookingToDelete = this.context.Bookings.SingleOrDefault(e => e.BookingId == id);
            this.context.Bookings.Remove(bookingToDelete);

            return this.context.SaveChanges();
        }
    }
}
