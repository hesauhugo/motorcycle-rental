using MotorcycleRental.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorcycleRental.Core.Services
{
    public interface IAuthService
    {
        string ComputeSha256Hash(string password);
    }

    public interface IAuthUserService:IAuthService {
        string GenerateJwtToken(User user);
    }

    public interface IAuthCustomerService : IAuthService
    {
        string GenerateJwtToken(Customer customer);
    }

}
