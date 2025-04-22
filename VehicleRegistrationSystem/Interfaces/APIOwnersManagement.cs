using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IOwnersManagement
    {
        public void OwnersManagamentF(
            Dictionary<int, string> OwnerFullNames,
            Dictionary<int, string> OwnerSocialIds,
            Dictionary<int, string> OwnerAddresses,
            Dictionary<int, string> OwnerPhoneNumbers,
            Dictionary<int, string> OwnerEmails,
            List<int> OwnerIds,

            Dictionary<int, string> Brands,
            Dictionary<int, string> Models,
            Dictionary<int, int> Years,
            Dictionary<int, string> Colors,
            Dictionary<int, string> LicensePlateNumbers,
            Dictionary<int, string> FuelTypes,
            List<int> Ids
            );

        public void ViewAllOwners(
            Dictionary<int, string> OwnerFullNames, 
            Dictionary<int, string> OwnerSocialIds, 
            Dictionary<int, string> OwnerAddresses, 
            Dictionary<int, string> OwnerPhoneNumbers, 
            Dictionary<int, string> OwnerEmails, 
            List<int> OwnerIds);
    }
}
