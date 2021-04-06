using MISA.Core.Entities;
using MISA.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Services
{
    public class CustomerService : BaseService<Customer>, ICustomerService
    {
        public CustomerService(IBaseRepository<Customer> baseRepository) : base(baseRepository)
        {

        }


    }
}
