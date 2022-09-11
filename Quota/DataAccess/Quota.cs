namespace Quota.DataAccess
{
    public class Quota
    {
        public Guid Id { get; set; }
        public string? vehicleRegistrationNumber { get; set; }
        public double? maxQuota { get; set; }
        public double? remainingQuota { get; set; }
    }
}
