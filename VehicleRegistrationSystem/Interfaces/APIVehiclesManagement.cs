using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IVehiclesManagament
    {
        public void VehiclesManagementF(Dictionary<int, string> Brands,
          Dictionary<int, string> Models,
          Dictionary<int, int> Years,
          Dictionary<int, string> Colors,
          Dictionary<int, string> LicensePlateNumbers,
          Dictionary<int, string> FuelTypes,
          List<int> Ids);

        public void ViewAllVehicles(Dictionary<int, string> getBrands, 
            Dictionary<int, string> getModels, 
            Dictionary<int, int> getYears, 
            Dictionary<int, string> getColors, 
            Dictionary<int, string> getLicensePlateNumbers, 
            Dictionary<int, string> getFuelTypes, 
            List<int> getIds);
    }
}
