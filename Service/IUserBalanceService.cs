using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace Service
{
    public interface IUserBalanceService
    {
        List<UserBalance> GetAll();
        UserBalance Get(int id);
        int Insert(UserBalance book);
        int Update(UserBalance book);
        int Delete(int id);
    }
}
