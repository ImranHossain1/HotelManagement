using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace Service
{
    public interface ICustomerService
    {
        List<Customer> GetAll();
        Customer Get(int id);
        int Insert(Customer customer);
        int Update(Customer customer);
        int Delete(int id);
    }
}
