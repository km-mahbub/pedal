using Pedal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pedal.Repositories.Interfaces;

namespace Pedal.Repositories
{
    public class CustomerRepository: Repository<Customer>, ICustomerRepository
    {
    }
}
