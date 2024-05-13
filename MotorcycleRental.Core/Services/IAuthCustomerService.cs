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
        string GenerateJwtToken(string email, string role);
    }

    public interface IAuthCustomerService : IAuthService
    {
        string GenerateJwtToken(string cnh);
    }

}
