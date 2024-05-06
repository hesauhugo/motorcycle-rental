using MediatR;
using MotorcycleRental.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorcycleRental.Application.Queries
{
    public class GetMotorcycleByIdQuery:IRequest<MotorcycleViewModel>
    {
        public GetMotorcycleByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get;private set; }
    }
}
