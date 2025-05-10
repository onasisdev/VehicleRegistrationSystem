using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
    {
        public class VehiclesManagement : VehiclesManagementBase
        {
        public override Dictionary<int, string> Brands { get; set; }
        public override Dictionary<int, string> Models { get; set; }
        public override Dictionary<int, int> Years { get; set; }
        public override Dictionary<int, string> Colors { get; set; }
        public override Dictionary<int, string> LicensePlateNumbers { get; set; }
        public override Dictionary<int, string> FuelTypes { get; set; }
        public override List<int> Ids { get; set; }

        public VehiclesManagement()
        {
            this.Brands = new Dictionary<int, string>();
            this.Models = new Dictionary<int, string>();
            this.Years = new Dictionary<int, int>();
            this.Colors = new Dictionary<int, string>();
            this.LicensePlateNumbers = new Dictionary<int, string>();
            this.FuelTypes = new Dictionary<int, string>();
            this.Ids = new List<int>();
        }
    }
}
