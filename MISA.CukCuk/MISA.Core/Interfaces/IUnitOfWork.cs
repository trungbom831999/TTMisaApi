using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Interfaces
{
    public interface IUnitOfWork
    {
        ICustomerRepository Customer { get; }
        ICustomerGroupRepository CustomerGroup { get; }
    }
}
