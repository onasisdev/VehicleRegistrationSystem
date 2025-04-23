using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    internal interface IInsuranceManagement
    {
        public void InsuranceManagementFunction(
            Dictionary<int, string> InsuranceCompanieNames,
            Dictionary<int, string> InsurancePolicyNumbers, 
            Dictionary<int, DateOnly> InsuranceStartDates, 
            Dictionary<int, DateOnly> InsuranceExpirationDates, 
            List<int> InsuranceIds
            );

        public void ViewAllInsurances(
            Dictionary<int, string> InsuranceCompanieNames,
            Dictionary<int, string> InsurancePolicyNumbers,
            Dictionary<int, DateOnly> InsuranceStartDates,
            Dictionary<int, DateOnly> InsuranceExpirationDates,
            List<int> InsuranceIds
            );
    }
}
