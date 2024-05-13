﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorcycleRental.Core.Entities
{
    public class Customer:BaseEntity
    {
        public Customer(int id, string fullName, string cnpj, DateTime birthDate, string cnh, string cnhKind):base(id)
        {
            FullName = fullName;
            Cnpj = cnpj;
            BirthDate = birthDate;
            Cnh = cnh;
            CnhKind = cnhKind;
        }

        public Customer(string fullName, string cnpj, DateTime birthDate, string cnh, string cnhKind)
        {
            FullName = fullName;
            Cnpj = cnpj;
            BirthDate = birthDate;
            Cnh = cnh;
            CnhKind = cnhKind;
        }

        protected Customer() { }
        public string FullName { get; private set; }
        public string Cnpj { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string Cnh { get; private set; }
        public string CnhKind { get; private set; }


    }
}
