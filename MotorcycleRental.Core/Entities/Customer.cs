using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorcycleRental.Core.Entities
{
    public class Customer:BaseEntity
    {
        public Customer(int id, string fullName, string cnpj, DateTime birthDate, string cnh, string tipoCnh):base(id)
        {
            FullName = fullName;
            Cnpj = cnpj;
            BirthDate = birthDate;
            Cnh = cnh;
            TipoCnh = tipoCnh;
        }

        public Customer(string fullName, string cnpj, DateTime birthDate, string cnh, string tipoCnh)
        {
            FullName = fullName;
            Cnpj = cnpj;
            BirthDate = birthDate;
            Cnh = cnh;
            TipoCnh = tipoCnh;
        }

        protected Customer() { }
        public string FullName { get; private set; }
        public string Cnpj { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string Cnh { get; private set; }
        public string TipoCnh { get; private set; }


    }
}
