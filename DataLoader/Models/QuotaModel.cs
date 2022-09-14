using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLoader.Models
{
    internal class QuotaModel
    {
        public Guid Id { get; set; }
        public string? vehicleRegistrationNumber { get; set; }
        public double? maxQuota { get; set; }
        public double? remainingQuota { get; set; }
    }
}
