using Microsoft.AspNetCore.Http;
using MotorcycleRental.Core.Entities;

namespace MotorcycleRental.Application.ViewModels
{
    public class CustomerViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Cnpj { get; set; }
        public DateTime BirthDate { get; set; }
        public string Cnh { get; set; }
        public string TipoCnh { get; set; }
        public IFormFile? CnhFoto { get; set; }

        public void FromEntity(Customer customerEntity)
        {

            this.Id = customerEntity.Id;
            this.FullName = customerEntity.FullName;
            this.Cnpj = customerEntity.Cnpj;
            this.BirthDate = customerEntity.BirthDate;
            this.Cnh = customerEntity.Cnh;
            this.TipoCnh = customerEntity.CnhKind;
        }
    }
}
