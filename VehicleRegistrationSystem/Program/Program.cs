

using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using Entities;
using Interfaces;


namespace Logic
{
  
    public class Program
    {

        static void Main(string[] args)
        {
            try
            {
                UserActionSelectionLogic userActionSelectionLogic = new UserActionSelectionLogic();
                userActionSelectionLogic.UserActionSelection();


            }

            catch (FormatException)
            {
                Console.WriteLine("El formato ingresado es incorrecto.");
            }
        }
    }
    public class UserActionSelectionLogic
    {
        public string SearchCriteria = string.Empty;
        public int GetId = 0;

        public void UserActionSelection()
        {
            bool running = true;

            VehicleManagement vehicleManagament = new VehicleManagement();

            VehicleStorageLogic vehicleStorageLogic = new VehicleStorageLogic();

            while (running)
            {
                Console.WriteLine("""
                Bienvenido a nuestro sistema de registro de vehículos!

                Favor escoja la acción que desee realizar:
                1.Gestionar vehículos
                2.Gestionar Propietarios
                3.Gestionar Seguros
                4.Gestionar mantenimientos
                5.Salir

                """);

                int userModulesSelection = Convert.ToInt32(Console.ReadLine());

                switch (userModulesSelection)
                {
                    case 1:

                        

                        vehicleStorageLogic.VehicleStorage(
                            vehicleManagament.Brands,
                            vehicleManagament.Models,
                            vehicleManagament.Years,
                            vehicleManagament.Colors,
                            vehicleManagament.LicensePlateNumbers,
                            vehicleManagament.FuelTypes,
                            vehicleManagament.Ids
                        );



                        //vehicleStorageLogic.VehicleStorage(Brands, Models, Years, Colors, LicensePlateNumbers, FuelTypes, Ids);







                        break;


                    //case 2:
                    //    OwnersManagament ownersManagament = new OwnersManagament();

                    //    ownersManagament.OwnersManagamentFunction(
                    //        OwnerFullNames, OwnerSocialIds, OwnerAddresses, OwnerPhoneNumbers, OwnerEmails, OwnerIds,
                    //        Brands, Models, Years, Colors, LicensePlateNumbers, FuelTypes, Ids
                    //        );


                    //    break;


                    //case 3:
                    //    InsuranceManagement insuranceManagement = new InsuranceManagement();

                    //    insuranceManagement.InsuranceManagementFunction(
                    //        InsuranceCompanieNames, InsurancePolicyNumbers, InsuranceStartDates, InsuranceExpirationDates,
                    //        InsuranceIds);

                    //    break;


                    //case 4:
                    //    MaintenanceManagement maintenanceManagement = new MaintenanceManagement();

                    //    maintenanceManagement.MaintenanceManagementFunction(
                    //        MaintenanceDates, MaintenanceServiceTypes, MaintenanceWorkshopNames,
                    //        MaintenanceOwnerFullNames, MaintenanceOwnerSocialIds,
                    //        MaintenanceIds);

                    //    break;


                    case 5:

                        running = false;

                        break;
                }

                if (userModulesSelection > 5 || userModulesSelection == 0)
                {
                    Console.WriteLine("Debe ingresar una de las opciones.");
                }
            }
        }
    }
}













