namespace Entities
{
    public abstract class InsuranceManagementBase
    {
        public virtual Dictionary<int, string> InsuranceCompanieNames { get; set; }
        public virtual Dictionary<int, string> InsurancePolicyNumbers { get; set; }
        public virtual Dictionary<int, DateOnly> InsuranceStartDates { get; set; }
        public virtual Dictionary<int, DateOnly> InsuranceExpirationDates { get; set; }
        public virtual List<int> InsuranceIds { get; set; }

        public abstract void ViewAllInsurances();
    }
}


