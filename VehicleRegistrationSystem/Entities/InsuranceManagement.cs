namespace Entities
{
    public class InsuranceManagement : InsuranceManagementBase
    {
        public override Dictionary<int, string> InsuranceCompanieNames { get; set; }
        public override Dictionary<int, string> InsurancePolicyNumbers { get; set; }
        public override Dictionary<int, DateOnly> InsuranceStartDates { get; set; }
        public override Dictionary<int, DateOnly> InsuranceExpirationDates { get; set; }
        public override List<int> InsuranceIds { get; set; }

        public InsuranceManagement() 
        { 
            this.InsuranceCompanieNames = new Dictionary<int, string>();
            this.InsurancePolicyNumbers = new Dictionary<int, string>();
            this.InsuranceStartDates = new Dictionary<int, DateOnly>();
            this.InsuranceExpirationDates = new Dictionary<int, DateOnly>();
            this.InsuranceIds = new List<int>();

        }
    }
}


