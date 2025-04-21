namespace Entities
{
    public class InsuranceManagement : InsuranceManagementBase
    {
        public override Dictionary<int, string> InsuranceCompanieNames { get; set; }
        public override Dictionary<int, string> InsurancePolicyNumbers { get; set; }
        public override Dictionary<int, DateOnly> InsuranceStartDates { get; set; }
        public override Dictionary<int, DateOnly> InsuranceExpirationDates { get; set; }
        public override List<int> InsuranceIds { get; set; }

        public InsuranceManagement(Dictionary<int, string> insuranceCompanieNames, Dictionary<int, string> insurancePolicyNumbers, Dictionary<int, DateOnly> insuranceStartDates, Dictionary<int, DateOnly> insuranceExpirationDates, List<int> insuranceIds) 
        { 
            this.InsuranceCompanieNames = insuranceCompanieNames;
            this.InsurancePolicyNumbers = insurancePolicyNumbers;
            this.InsuranceStartDates = insuranceStartDates;
            this.InsuranceExpirationDates = insuranceExpirationDates;
            this.InsuranceIds = insuranceIds;

        }

    }
}


