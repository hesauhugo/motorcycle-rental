using MediatR;
using Microsoft.Extensions.Configuration;
using MotorcycleRental.Core.Repositories;
using MotorcycleRental.Core.Storage.LocalStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorcycleRental.Infrastructure.Storage.Local
{
    public class LocalStorage : ILocalStorage
    {
        private readonly string _filePath;
        public LocalStorage(IConfiguration configuration)
        {
            _filePath = configuration["FilePath"];
        }
        public void UpLoadImage(byte[] image, string fileName)
        {
            
            string directory = Path.Combine(_filePath, "cnh-images");
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            string path = Path.Combine(directory, fileName);
            File.WriteAllBytes(path, image);

        }
    }
}
