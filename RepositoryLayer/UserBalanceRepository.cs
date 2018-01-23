using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace RepositoryLayer
{
    public class UserBalanceRepository : IUserBalanceRepository
    {
        private DataContext context;

        public UserBalanceRepository() { this.context = new DataContext(); }

        public List<UserBalance> GetAll()
        {
            return this.context.UserBalances.ToList();
        }

        public UserBalance Get(int id)
        {
            return this.context.UserBalances.SingleOrDefault(e => e.UserBalanceId == id);
        }

        public UserBalance GetByCustomer(int id)
        {
            return this.context.UserBalances.SingleOrDefault(e => e.CustomerId == id);
        }

        public int Insert(UserBalance userBalance)
        {
            this.context.UserBalances.Add(userBalance);
            return this.context.SaveChanges();
        }

        public int Update(UserBalance userBalance)
        {
            UserBalance userBalanceToUpdate = this.context.UserBalances.SingleOrDefault(e => e.UserBalanceId == userBalance.UserBalanceId);
            userBalanceToUpdate.Paid = userBalance.Paid;
            userBalanceToUpdate.RemainingAcount = userBalance.RemainingAcount;

            return this.context.SaveChanges();
        }

        public int Delete(int id)
        {
            UserBalance UserBalanceToDelete = this.context.UserBalances.SingleOrDefault(e => e.UserBalanceId == id);
            this.context.UserBalances.Remove(UserBalanceToDelete);

            return this.context.SaveChanges();
        }
    }
}
