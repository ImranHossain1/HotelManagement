using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace RepositoryLayer
{
    public class RoomRepository : IRoomRepository
    {
        private DataContext context;

        public RoomRepository() { this.context = new DataContext(); }

        public List<Room> GetAll()
        {
            return this.context.Rooms.ToList();
        }

        public Room Get(int id)
        {
            return this.context.Rooms.SingleOrDefault(r => r.RoomId == id);
        }
        public Room Get(string catagory)
        {
            return this.context.Rooms.SingleOrDefault(r => r.Catagory == catagory);
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

        public int Insert(Room room)
        {
            this.context.Rooms.Add(room);
            return this.context.SaveChanges();
        }

        public int Update(Room room)
        {
            Room roomToUpdate = this.context.Rooms.SingleOrDefault(r => r.RoomId == room.RoomId);

            roomToUpdate.Catagory = room.Catagory;
            roomToUpdate.Rent = room.Rent;
           
           
            return this.context.SaveChanges();
        }

        public int Delete(int id)
        {
            Room roomToDelete = this.context.Rooms.SingleOrDefault(r => r.RoomId == id);
            this.context.Rooms.Remove(roomToDelete);

            return this.context.SaveChanges();
        }
    }
}
