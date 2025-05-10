using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IMaintenancesManagement
    {
        public void MaintenancesManagementF(
            Dictionary<int, DateOnly> MaintenanceDates, 
            Dictionary<int, string> MaintenanceServiceTypes, 
            Dictionary<int, string> MaintenanceWorkshopNames, 
            Dictionary<int, string> MaintenanceOwnerFullNames, 
            Dictionary<int, string> MaintenanceOwnerSocialIds, 
            List<int> MaintenanceIds 
            );

        public void ViewAllMaintenances(
            Dictionary<int, DateOnly> getMaintenanceDates,
            Dictionary<int, string> getMaintenanceServiceTypes,
            Dictionary<int, string> getMaintenanceWorkshopNames,
            Dictionary<int, string> getMaintenanceOwnerFullNames,
            Dictionary<int, string> getMaintenanceOwnerSocialIds,
            List<int> getMaintenanceIds
            );

    }
}
