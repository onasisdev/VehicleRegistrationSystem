namespace Entities
{
    public abstract class MaintenanceManagamentBase
    {
        public virtual Dictionary<int, DateOnly> MaintenanceDates { get; set; }
        public virtual Dictionary<int, string> MaintenanceServiceTypes { get; set; }
        public virtual Dictionary<int, string> MaintenanceWorkshopNames { get; set; }
        public virtual Dictionary<int, string> MaintenanceOwnerFullNames { get; set; }
        public virtual Dictionary<int, string> MaintenanceOwnerSocialIds { get; set; }
        public virtual List<int> MaintenanceIds { get; set; }


       
    }
}


