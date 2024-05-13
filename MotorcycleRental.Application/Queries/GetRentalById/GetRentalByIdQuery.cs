using MediatR;
using MotorcycleRental.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorcycleRental.Application.Queries.GetRentalById
{
    public class GetRentalByIdQuery:IRequest<RentalViewModel>
    {
        public GetRentalByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
