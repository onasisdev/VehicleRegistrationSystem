using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IVehicleStorage
    {
        public void VehicleStorage(Dictionary<int, string> Brands,
          Dictionary<int, string> Models,
          Dictionary<int, int> Years,
          Dictionary<int, string> Colors,
          Dictionary<int, string> LicensePlateNumbers,
          Dictionary<int, string> FuelTypes,
          List<int> Ids);

        public void ViewAllVehicles(Dictionary<int, string> Brands, 
            Dictionary<int, string> Models, 
            Dictionary<int, int> Years, 
            Dictionary<int, string> Colors, 
            Dictionary<int, string> LicensePlateNumbers, 
            Dictionary<int, string> FuelTypes, 
            List<int> Ids);
        
            
        

    }
}
