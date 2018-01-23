using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace RepositoryLayer
{
    public interface IRoomAvRepository
    {
        List<RoomAv> GetAll();
        RoomAv Get(int id);
        int Insert(RoomAv room);
        int Update(RoomAv room);
        int Delete(int id);
    }
}

