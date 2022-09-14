namespace Quota.DataAccess
{
    public class Quotas
    {
        public Guid Id { get; set; }
        public string? vehicleRegistrationNumber { get; set; }
        public double? maxQuota { get; set; }
        public double? remainingQuota { get; set; }
    }
}
