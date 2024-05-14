using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorcycleRental.Core.Entities.RentalStrategy
{
    public interface IRentalPlanStrategy
    {
        decimal CalculateTotal(int daysUsed);
    }
}
