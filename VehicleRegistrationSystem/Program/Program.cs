using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using DataBase;
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
                Console.WriteLine("El formato ingresado es incorrecto, favor vuelva a intentar nuevamente.");
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

            VehiclesManagement vehiclesManagement = new VehiclesManagement();
            VehiclesManagementLogic vehiclesManagementLogic = new VehiclesManagementLogic();

            OwnersManagement ownersManagement = new OwnersManagement();
            OwnersManagementLogic ownersManagamentLogic = new OwnersManagementLogic();

            InsurancesManagement insurancesManagement = new InsurancesManagement();
            InsurancesManagementLogic insurancesManagementLogic = new InsurancesManagementLogic();


            

            

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
                        try
                        {
                            vehiclesManagementLogic.VehiclesManagementF(
                                vehiclesManagement.Brands,
                                vehiclesManagement.Models,
                                vehiclesManagement.Years,
                                vehiclesManagement.Colors,
                                vehiclesManagement.LicensePlateNumbers,
                                vehiclesManagement.FuelTypes,
                                vehiclesManagement.Ids
                            );

                        }
                        
                        catch (FormatException)
                        {

                            Console.WriteLine("El formato ingresado es incorrecto, favor vuelva a intentar nuevamente.");

                            vehiclesManagement.Brands.Remove(vehiclesManagement.Ids.Count());
                            vehiclesManagement.Models.Remove(vehiclesManagement.Ids.Count());
                            vehiclesManagement.Years.Remove(vehiclesManagement.Ids.Count());
                            vehiclesManagement.Colors.Remove(vehiclesManagement.Ids.Count());
                            vehiclesManagement.LicensePlateNumbers.Remove(vehiclesManagement.Ids.Count());
                            vehiclesManagement.FuelTypes.Remove(vehiclesManagement.Ids.Count());
                            vehiclesManagement.Ids.Remove(vehiclesManagement.Ids.Count());

                        }


                        break;


                    case 2:
                        
                        ownersManagamentLogic.OwnersManagementF(
                            ownersManagement.OwnerFullNames,
                            ownersManagement.OwnerSocialIds,
                            ownersManagement.OwnerAddresses,
                            ownersManagement.OwnerPhoneNumbers,
                            ownersManagement.OwnerEmails,
                            ownersManagement.OwnerIds,
                            
                            vehiclesManagement.Brands,
                            vehiclesManagement.Models,
                            vehiclesManagement.Years,
                            vehiclesManagement.Colors,
                            vehiclesManagement.LicensePlateNumbers,
                            vehiclesManagement.FuelTypes,
                            vehiclesManagement.Ids
                            );
                        
                        break;


                    case 3:
                        
                        try
                        
                        {
                            insurancesManagementLogic.InsuranceManagementF(
                                insurancesManagement.InsuranceCompanieNames,
                                insurancesManagement.InsurancePolicyNumbers,
                                insurancesManagement.InsuranceStartDates,
                                insurancesManagement.InsuranceExpirationDates,
                                insurancesManagement.InsuranceIds
                                );
                        }

                        catch (FormatException)
                        {
                            
                            Console.WriteLine("El formato ingresado es incorrecto, favor vuelva a intentar nuevamente.");

                            insurancesManagement.InsuranceCompanieNames.Remove(insurancesManagement.InsuranceIds.Count());
                            insurancesManagement.InsurancePolicyNumbers.Remove(insurancesManagement.InsuranceIds.Count());
                            insurancesManagement.InsuranceStartDates.Remove(insurancesManagement.InsuranceIds.Count());
                            insurancesManagement.InsuranceExpirationDates.Remove(insurancesManagement.InsuranceIds.Count());
                            insurancesManagement.InsuranceIds.Remove(insurancesManagement.InsuranceIds.Count());
                        }

                        break;


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













