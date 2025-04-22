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

        public MaintenanceManagament (Dictionary<int, DateOnly> maintenanceDates, Dictionary<int, string> maintenanceServiceTypes, Dictionary<int, string> maintenanceWorkshopNames, Dictionary<int, string> maintenanceOwnerFullNames, Dictionary<int, string> maintenanceOwnerSocialIds, List<int> maintenanceIds)
        {
            this.MaintenanceDates = maintenanceDates;
            this.MaintenanceServiceTypes = maintenanceServiceTypes;
            this.MaintenanceWorkshopNames = maintenanceWorkshopNames;
            this.MaintenanceOwnerFullNames = maintenanceOwnerFullNames;
            this.MaintenanceOwnerSocialIds = maintenanceOwnerSocialIds;
            this.MaintenanceIds = maintenanceIds;
        }

        public override void ViewAllMaintenances()
        {
            Console.WriteLine("");

            Console.WriteLine("Mantenimientos: ");

            foreach (var maintenanceId in MaintenanceIds)
            {
                Console.WriteLine($"""
                    id: {maintenanceId}   Fecha del mantenimiento: {MaintenanceDates[maintenanceId]}   Tipo de servicio: {MaintenanceServiceTypes[maintenanceId]}   Nombre del taller: {MaintenanceWorkshopNames[maintenanceId]} Nombre completo del propietario: {MaintenanceOwnerFullNames[maintenanceId]}   Cédula del propietario: {MaintenanceOwnerSocialIds[maintenanceId]}
                    """);
            }

            Console.WriteLine("");
        }



    }
}


