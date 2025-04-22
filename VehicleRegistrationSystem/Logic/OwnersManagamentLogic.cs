using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using Entities;

namespace Logic
{
    public class OwnersManagamentLogic : IOwnersManagement
    {


        VehicleManagementLogic vehicleManagementLogic = new VehicleManagementLogic();
        VehicleManagement vehicleManagement = new VehicleManagement();



        public void ViewAllOwners(Dictionary<int, string> OwnerFullNames, Dictionary<int, string> OwnerSocialIds, Dictionary<int, string> OwnerAddresses, Dictionary<int, string> OwnerPhoneNumbers, Dictionary<int, string> OwnerEmails, List<int> OwnerIds)
        {
            Console.WriteLine("");

            Console.WriteLine("Propietarios: ");

            foreach (var ownerId in OwnerIds)
            {
                Console.WriteLine($"""
                    id: {ownerId}   Nombre completo: {OwnerFullNames[ownerId]}   Cédula: {OwnerSocialIds[ownerId]}   Dirección: {OwnerAddresses[ownerId]}   Teléfono: {OwnerPhoneNumbers[ownerId]}   Correo electrónico: {OwnerEmails[ownerId]}
                    """);
            }

            Console.WriteLine("");
        }


        public void OwnersManagamentF(
                Dictionary<int, string> OwnerFullNames,
                Dictionary<int, string> OwnerSocialIds,
                Dictionary<int, string> OwnerAddresses,
                Dictionary<int, string> OwnerPhoneNumbers,
                Dictionary<int, string> OwnerEmails,
                List<int> OwnerIds,

                Dictionary<int, string> Brands,
                Dictionary<int, string> Models,
                Dictionary<int, int> Years,
                Dictionary<int, string> Colors,
                Dictionary<int, string> LicensePlateNumbers,
                Dictionary<int, string> FuelTypes,
                List<int> Ids
                )
            {
            int getId;

           
           

            
            


            Console.WriteLine("""
                Favor escoja la acción que desea realizar: 
                1.Agregar un nuevo registro de propietario
                2.Asociar uno o más vehículos a un propietario
                3.Editar la información de los propietarios
                4.Buscar propietarios por nombre o cédula
                5.Consultar el historial de propietarios
                6.Eliminar propietarios

                """);

                int userOwnersManagamentSelection = Convert.ToInt32(Console.ReadLine());


                switch (userOwnersManagamentSelection)
                {
                    case 1:

                        int OwnerId = OwnerIds.Count() + 1;
                        OwnerIds.Add(OwnerId);

                        Console.WriteLine("Favor ingrese el nombre del propietario: ");
                        var OwnerFullName = Console.ReadLine();
                        OwnerFullNames.Add(OwnerId, OwnerFullName);

                        Console.WriteLine("Favor ingrese la cédula del propietario: ");
                        var OwnerSocialId = Console.ReadLine();
                        OwnerSocialIds.Add(OwnerId, OwnerSocialId);

                        Console.WriteLine("Favor ingrese la dirección del propietario: ");
                        var OwnerAddress = Console.ReadLine();
                        OwnerAddresses.Add(OwnerId, OwnerAddress);

                        Console.WriteLine("Favor ingrese el teléfono del propietario: ");
                        var OwnerPhoneNumber = Console.ReadLine();
                        OwnerPhoneNumbers.Add(OwnerId, OwnerPhoneNumber);

                        Console.WriteLine("Favor ingrese el correo electrónico del propietario: ");
                        var OwnerEmail = Console.ReadLine();
                        OwnerEmails.Add(OwnerId, OwnerEmail);


                        

                        break;


                    case 2:

                        List<int> getCarIds = new List<int>();
                        List<int> getOwnerIds = new List<int>();




                    vehicleManagementLogic.ViewAllVehicles(Brands, Models, Years, Colors, LicensePlateNumbers, FuelTypes, Ids);




                    Console.WriteLine("Favor ingrese el id del vehículo para asociarlo con un propietario: ");
                        getCarIds.Add(Convert.ToInt32(Console.ReadLine()));
                    
                    ViewAllOwners(OwnerFullNames, OwnerSocialIds, OwnerAddresses, OwnerPhoneNumbers, OwnerEmails, OwnerIds);

                    Console.WriteLine("Favor ingrese el id del propietario: ");
                        getOwnerIds.Add(Convert.ToInt32(Console.ReadLine()));

                        Console.WriteLine("¿Desea asociar más vehículos a un propietario?  1.Sí  2.No");
                        int wantToContinue = Convert.ToInt32(Console.ReadLine());


                        while (wantToContinue != 2)
                        {
                        vehicleManagementLogic.ViewAllVehicles(Brands, Models, Years, Colors, LicensePlateNumbers, FuelTypes, Ids);

                        Console.WriteLine("Ingrese el id de un vehículo para asociarlo con un propietario: ");
                            getCarIds.Add(Convert.ToInt32(Console.ReadLine()));

                            Console.WriteLine("Ingrese el id del propietario: ");
                            getOwnerIds.Add(Convert.ToInt32(Console.ReadLine()));

                            Console.WriteLine("¿Desea asociar más vehículos a un propietario?  1.Sí  2.No");
                            wantToContinue = Convert.ToInt32(Console.ReadLine());
                        }

                        if (wantToContinue == 2)
                        {
                            Console.WriteLine("Vehiculo(s) asociados a propietarios: ");

                            Console.WriteLine("Vehiculo(s):");

                            foreach (var id in Ids)
                            {
                                if (getCarIds.Contains(id))
                                {
                                    Console.WriteLine($"""
                                        id: {id}   Marca: {Brands[id]}   Modelo: {Models[id]}   Año: {Years[id]}   Color: {Colors[id]}   Número de placa: {LicensePlateNumbers[id]}   Tipo de combustible: {LicensePlateNumbers[id]}
                                        """);
                                }
                            }


                            Console.WriteLine("Propietario:");

                            foreach (var ownerId in OwnerIds)
                            {
                                if (getOwnerIds.Contains(ownerId))
                                {
                                    Console.WriteLine($"""
                                        id: {ownerId}   Nombre completo: {OwnerFullNames[ownerId]}   Cédula: {OwnerSocialIds[ownerId]}   Dirección: {OwnerAddresses[ownerId]}   Teléfono: {OwnerPhoneNumbers[ownerId]}   Correo electrónico: {OwnerEmails[ownerId]}
                                        """);
                                }
                            }
                        }

                        break;


                    case 3:

                        var getAllNewElementsFromOwners = string.Empty;

                        Console.WriteLine("""
                        Favor escoja la acción que desea realizar:
                        1.Editar una información de un propietario
                        2.Editar toda la información de un propietario

                        """);

                        userOwnersManagamentSelection = Convert.ToInt32(Console.ReadLine());

                        if (userOwnersManagamentSelection == 1)
                        {
                        ViewAllOwners(OwnerFullNames, OwnerSocialIds, OwnerAddresses, OwnerPhoneNumbers, OwnerEmails, OwnerIds);

                        Console.WriteLine("Favor seleccione el id del registro de propietario que desee modificar: ");
                            getId = Convert.ToInt32(Console.ReadLine());


                            foreach (var ownerId in OwnerIds)
                            {
                                if (ownerId == getId)
                                {
                                    Console.WriteLine("Favor seleccione uno de los datos que desee modificar:");

                                    Console.WriteLine("1.Nombre completo 2.Cédula 3.Dirección 4.Teléfono 5.correo electrónico");

                                    int getElementToModifyOwner = Convert.ToInt32(Console.ReadLine());

                                    Console.WriteLine("Favor ingrese el nuevo elemento:");
                                    var newElementFromOwners = Console.ReadLine();


                                    switch (getElementToModifyOwner)
                                    {
                                        case 1:

                                            OwnerFullNames[ownerId] = newElementFromOwners;

                                            break;

                                        case 2:

                                            OwnerSocialIds[ownerId] = newElementFromOwners;

                                            break;

                                        case 3:

                                            OwnerAddresses[ownerId] = newElementFromOwners;

                                            break;

                                        case 4:

                                            OwnerPhoneNumbers[ownerId] = newElementFromOwners;

                                            break;

                                        case 5:

                                            OwnerEmails[ownerId] = newElementFromOwners;

                                            break;
                                    }
                                }
                            }
                        }

                        else if (userOwnersManagamentSelection == 2)
                        {

                        ViewAllOwners(OwnerFullNames, OwnerSocialIds, OwnerAddresses, OwnerPhoneNumbers, OwnerEmails, OwnerIds);

                        Console.WriteLine("Favor seleccione el id del registro de propietario que desee modificar: ");
                            getId = Convert.ToInt32(Console.ReadLine());


                            foreach (var ownerId in OwnerIds)
                            {
                                if (ownerId == getId)
                                {
                                    Console.WriteLine("Favor ingrese el nuevo nombre completo: ");
                                    getAllNewElementsFromOwners = Console.ReadLine();
                                    OwnerFullNames[ownerId] = getAllNewElementsFromOwners;

                                    Console.WriteLine("Favor ingrese la nueva cédula: ");
                                    getAllNewElementsFromOwners = Console.ReadLine();
                                    OwnerSocialIds[ownerId] = getAllNewElementsFromOwners;

                                    Console.WriteLine("Favor ingrese la nueva dirección: ");
                                    getAllNewElementsFromOwners = Console.ReadLine();
                                    OwnerAddresses[ownerId] = getAllNewElementsFromOwners;

                                    Console.WriteLine("Favor ingrese el nuevo número de teléfono: ");
                                    getAllNewElementsFromOwners = Console.ReadLine();
                                    OwnerPhoneNumbers[ownerId] = getAllNewElementsFromOwners;

                                    Console.WriteLine("Favor ingrese el nuevo correo electrónico: ");
                                    getAllNewElementsFromOwners = Console.ReadLine();
                                    OwnerEmails[ownerId] = getAllNewElementsFromOwners;
                                }
                            }
                        }

                        break;


                    case 4:
                        Console.WriteLine("Favor ingrese el nombre o cédula del registro de propietario que desee buscar:");
                        var SearchCriteria = Console.ReadLine().ToLower();

                        foreach (var ownerId in OwnerIds)
                        {
                            if (OwnerFullNames[ownerId].ToLower().Contains(SearchCriteria) || OwnerSocialIds[ownerId].ToString().Contains(SearchCriteria))
                            {
                                Console.WriteLine($"""
                                id: {ownerId}   Nombre completo: {OwnerFullNames[ownerId]}   Cédula: {OwnerSocialIds[ownerId]}   Dirección: {OwnerAddresses[ownerId]}   Teléfono: {OwnerPhoneNumbers[ownerId]}   Correo electrónico: {OwnerEmails[ownerId]}
                                """);
                            }
                        }

                        break;


                    case 5:
                    ViewAllOwners(OwnerFullNames, OwnerSocialIds, OwnerAddresses, OwnerPhoneNumbers, OwnerEmails, OwnerIds);

                    break;


                    case 6:

                        bool isOwnerRemoved = false;

                        ViewAllOwners(OwnerFullNames, OwnerSocialIds, OwnerAddresses, OwnerPhoneNumbers, OwnerEmails, OwnerIds);

                        Console.WriteLine("Favor ingrese el id del registro de propietario que desee eliminar: ");
                        getId = Convert.ToInt32(Console.ReadLine());


                        foreach (var ownerId in OwnerIds.ToArray())
                        {
                            if (ownerId == getId)
                            {

                                OwnerFullNames.Remove(ownerId);
                                OwnerSocialIds.Remove(ownerId);
                                OwnerAddresses.Remove(ownerId);
                                OwnerPhoneNumbers.Remove(ownerId);
                                OwnerEmails.Remove(ownerId);

                                OwnerIds.Remove(ownerId);

                                isOwnerRemoved = true;
                            }
                        }

                        if (isOwnerRemoved == true)
                        {
                            Console.WriteLine("Registro de propietario eliminado satisfactoriamente.");
                        }

                        break;
                }

                if (userOwnersManagamentSelection > 6 || userOwnersManagamentSelection == 0)
                {
                    Console.WriteLine("Debe ingresar una de las opciones.");
                }
            }

            
        }
    }

