using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLoader.Models
{
    internal class VehicleModel
    {
        public Guid Id { get; set; }
        public string? vehicleRegistrationNumber { get; set; }
        public string? registeredDate { get; set; }
        public string? chassisNumber { get; set; }
    }
}
