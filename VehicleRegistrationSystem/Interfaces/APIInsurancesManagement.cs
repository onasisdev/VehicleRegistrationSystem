using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IInsurancesManagement
    {
        public void InsuranceManagementF(
            Dictionary<int, string> getInsuranceCompanieNames,
            Dictionary<int, string> getInsurancePolicyNumbers,
            Dictionary<int, DateOnly> getInsuranceStartDates,
            Dictionary<int, DateOnly> getInsuranceExpirationDates,
            List<int> getInsuranceIds
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
