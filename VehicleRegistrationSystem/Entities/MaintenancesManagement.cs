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

        public MaintenanceManagament ()
        {
            this.MaintenanceDates = new Dictionary<int, DateOnly>();
            this.MaintenanceServiceTypes = new Dictionary<int, string>();
            this.MaintenanceWorkshopNames = new Dictionary<int, string>();
            this.MaintenanceOwnerFullNames = new Dictionary<int, string>();
            this.MaintenanceOwnerSocialIds = new Dictionary<int, string>();
            this.MaintenanceIds = new List<int>();
        }

       



    }
}


