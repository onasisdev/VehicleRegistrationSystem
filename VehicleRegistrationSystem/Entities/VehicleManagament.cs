using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
    {
        public class VehicleManagement : VehicleManagementBase
        {
        public override Dictionary<int, string> Brands { get; set; }
        public override Dictionary<int, string> Models { get; set; }
        public override Dictionary<int, int> Years { get; set; }
        public override Dictionary<int, string> Colors { get; set; }
        public override Dictionary<int, string> LicensePlateNumbers { get; set; }
        public override Dictionary<int, string> FuelTypes { get; set; }
        public override List<int> Ids { get; set; }

        public VehicleManagement(Dictionary<int, string> brands, Dictionary<int, string> models, Dictionary<int, int> years, Dictionary<int, string> colors, Dictionary<int, string> licensePlateNumbers, Dictionary<int, string> fuelTypes, List<int> ids, int getId)
            {
                this.Brands = brands;
                this.Models = models;
                this.Years = years;
                this.Colors = colors;
                this.LicensePlateNumbers = licensePlateNumbers;
                this.FuelTypes = fuelTypes;
                this.Ids = ids;
             
            }
        }
    }
