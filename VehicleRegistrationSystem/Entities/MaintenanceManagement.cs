namespace Entities
{
    public class MaintenanceManagament : MaintenanceManagamentBase
    {
        public override Dictionary<int, DateOnly> MaintenanceDates { get; set; }
        public override Dictionary<int, string> MaintenanceServiceTypes { get; set; }
        public override Dictionary<int, string> MaintenanceWorkshopNames { get; set; }
        public override Dictionary<int, string> MaintenanceOwnerFullNames { get; set; }
        public override Dictionary<int, string> MaintenanceOwnerSocialIds { get; set; }
        public override List<int> MaintenanceIds { get; set; }

        public MaintenanceManagament (Dictionary<int, DateOnly> maintenanceDates, Dictionary<int, string> maintenanceServiceTypes, Dictionary<int, string> maintenanceWorkshopNames, Dictionary<int, string> maintenanceOwnerFullNames, Dictionary<int, string> maintenanceOwnerSocialIds, List<int> MaintenanceIds)
        {
            this.MaintenanceDates = maintenanceDates;
            this.MaintenanceServiceTypes = maintenanceServiceTypes;
            this.MaintenanceWorkshopNames = maintenanceWorkshopNames;
            this.MaintenanceOwnerFullNames = maintenanceOwnerFullNames;
            this.MaintenanceOwnerSocialIds = maintenanceOwnerSocialIds;
            this.MaintenanceIds = MaintenanceIds;
        }
    }
}


