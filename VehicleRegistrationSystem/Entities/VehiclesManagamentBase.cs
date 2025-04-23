namespace Entities
{
    public abstract class VehiclesManagementBase
    {
        public virtual Dictionary<int, string> Brands { get; set; }
        public virtual Dictionary<int, string> Models { get; set; }
        public virtual Dictionary<int, int> Years { get; set; }
        public virtual Dictionary<int, string> Colors { get; set; }
        public virtual Dictionary<int, string> LicensePlateNumbers { get; set; }
        public virtual Dictionary<int, string> FuelTypes { get; set; }
        public virtual List<int> Ids { get; set; }


        

        

        
    }
}


