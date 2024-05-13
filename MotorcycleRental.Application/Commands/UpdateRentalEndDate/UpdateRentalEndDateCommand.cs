using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MotorcycleRental.Application.Commands.UpdateRentalEndDate
{
    public class UpdateRentalEndDateCommand:IRequest<Unit>
    {
        public int Id { get; private set; }
        public DateTime EndDate { get; set; }

        public void SetId(int Id)
        {
            this.Id = Id;
        }
    }
}
