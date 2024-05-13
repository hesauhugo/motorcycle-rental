using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorcycleRental.Core.Storage.LocalStorage
{
    public interface ILocalStorage
    {
        void UpLoadImage(byte[] image,string fileName);
    }
}
