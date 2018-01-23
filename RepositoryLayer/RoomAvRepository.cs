using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace RepositoryLayer
{
    public class RoomAvRepository : IRoomAvRepository
    {
        private DataContext context;

        public RoomAvRepository() { this.context = new DataContext(); }

        public List<RoomAv> GetAll()
        {
            return context.Roomavs.ToList(); 
        }

        public RoomAv Get(int id)
        {
            return this.context.Roomavs.SingleOrDefault(r => r.RoomAvId == id);
        }

        /*  public List<Room> GetByAvailability(bool availability)
          {
              List<Room> list = new List<Room>();
              Room r = (Room)from room in this.context.Rooms.ToList()
                             where room.Avaivalbility == availability
                             select room;
              list.Add(r);
              return list;
          }*/

        public int Insert(RoomAv room)
        {
            this.context.Roomavs.Add(room);
            return this.context.SaveChanges();
        }

        public int Update(RoomAv room)
        {
            RoomAv roomToUpdate = this.context.Roomavs.SingleOrDefault(r => r.RoomAvId == room.RoomAvId);

            roomToUpdate.RoomId= room.RoomId;
            roomToUpdate.Availability = room.Availability;


            return this.context.SaveChanges();
        }

        public int Delete(int id)
        {
            RoomAv roomToDelete = this.context.Roomavs.SingleOrDefault(r => r.RoomAvId == id);
            this.context.Roomavs.Remove(roomToDelete);

            return this.context.SaveChanges();
        }
    }
}
