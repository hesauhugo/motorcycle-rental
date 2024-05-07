using MediatR;
using MotorcycleRental.Core.Entities;
using MotorcycleRental.Core.Services;
using MotorcycleRental.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorcycleRental.Application.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly MotorcycleRentalDbContext _dbContext;
        private readonly IAuthService _authService;
        public CreateUserCommandHandler(MotorcycleRentalDbContext dbContext, IAuthService authService)
        {
            _dbContext = dbContext;
            _authService = authService;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {

            var user = request.ToEntity(_authService.ComputeSha256Hash(request.Password));

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user.Id;
        }
    }
}
