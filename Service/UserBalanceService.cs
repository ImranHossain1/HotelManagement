using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using RepositoryLayer;

namespace Service
{
    public class UserBalanceService : IUserBalanceService
    {
        private UserBalanceRepository repo = new UserBalanceRepository();

        public List<UserBalance> GetAll()
        {
            return repo.GetAll();
        }

        public UserBalance Get(int id)
        {
            return repo.Get(id);
        }

        public UserBalance GetByCustomer(int id)
        {
            return repo.Get(id);
        }

        public int Insert(UserBalance ub)
        {
            return repo.Insert(ub);
        }

        public int Update(UserBalance ub)
        {
            return repo.Update(ub);
        }

        public int Delete(int id)
        {
            return repo.Delete(id);
        }
    }
}
