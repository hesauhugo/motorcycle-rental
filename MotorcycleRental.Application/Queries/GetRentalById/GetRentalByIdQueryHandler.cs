using MediatR;
using MotorcycleRental.Application.ViewModels;
using MotorcycleRental.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorcycleRental.Application.Queries.GetRentalById
{
    public class GetRentalByIdQueryHandler : IRequestHandler<GetRentalByIdQuery, RentalViewModel>
    {
        private readonly IRentalRepository _rentalRepository;

        public GetRentalByIdQueryHandler(IRentalRepository rentalRepository)
        {
            _rentalRepository = rentalRepository;
        }

        public async Task<RentalViewModel> Handle(GetRentalByIdQuery request, CancellationToken cancellationToken)
        {
            var query = await _rentalRepository.GetByIdAsync(request.Id);
            var viewModel = new RentalViewModel();
            viewModel.FromEntity(query);
            return viewModel;

        }

    }
}
