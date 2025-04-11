using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualBasic;

namespace VehicleRegistrationSystem
{
    public class Program
    {

        static void Main(string[] args)
        {
            try
            {
                MainVehicleRegistrationSystem mainVehicleRegistrationSystem = new MainVehicleRegistrationSystem();
                mainVehicleRegistrationSystem.userActionSelection();
            }

            catch (FormatException)
            {
                Console.WriteLine("El formato ingresado es incorrecto.");
            }  
        }

    }

    public class MainVehicleRegistrationSystem
    {

        public Dictionary<int, string> Brands = new Dictionary<int, string>();
        public Dictionary<int, string> Models = new Dictionary<int, string>();
        public Dictionary<int, int> Years = new Dictionary<int, int>();
        public Dictionary<int, string> Colors = new Dictionary<int, string>();
        public Dictionary<int, string> LicensePlateNumbers = new Dictionary<int, string>();
        public Dictionary<int, string> FuelTypes = new Dictionary<int, string>();
        public List<int> Ids = new List<int>();


        public Dictionary<int, string> OwnerFullNames = new Dictionary<int, string>();
        public Dictionary<int, string> OwnerSocialIds = new Dictionary<int, string>();
        public Dictionary<int, string> OwnerAddresses = new Dictionary<int, string>();
        public Dictionary<int, string> OwnerPhoneNumbers = new Dictionary<int, string>();
        public Dictionary<int, string> OwnerEmails = new Dictionary<int, string>();
        public List<int> OwnerIds = new List<int>();


        public Dictionary<int, string> InsuranceCompanieNames = new Dictionary<int, string>();
        public Dictionary<int, string> InsurancePolicyNumbers = new Dictionary<int, string>();
        public Dictionary<int, DateOnly> InsuranceStartDates = new Dictionary<int, DateOnly>();
        public Dictionary<int, DateOnly> InsuranceExpirationDates = new Dictionary<int, DateOnly>();
        public List<int> InsuranceIds = new List<int>();


        public Dictionary<int, DateOnly> MaintenanceDates = new Dictionary<int, DateOnly>();
        public Dictionary<int, string> MaintenanceServiceTypes = new Dictionary<int, string>();
        public Dictionary<int, string> MaintenanceWorkshopNames = new Dictionary<int, string>();
        public Dictionary<int, string> MaintenanceOwnerFullNames = new Dictionary<int, string>();
        public Dictionary<int, string> MaintenanceOwnerSocialIds = new Dictionary<int, string>();
        public List<int> MaintenanceIds = new List<int>();


        public int GetId { get; set; }
        public string SearchCriteria { get; set; }


        public void userActionSelection()
        {
            bool running = true;


            while (running)
            {
                Console.WriteLine("""
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
                        VehicleStorageFunction(Brands, Models, Years, Colors, LicensePlateNumbers, FuelTypes, Ids);

                        break;

                    
                    case 2:
                        OwnersManagament ownersManagament = new OwnersManagament();

                        ownersManagament.OwnersManagamentFunction(
                            OwnerFullNames, OwnerSocialIds, OwnerAddresses, OwnerPhoneNumbers, OwnerEmails, OwnerIds,
                            Brands, Models, Years, Colors, LicensePlateNumbers, FuelTypes, Ids
                            );

                        break;

                    
                    case 3:
                        InsuranceManagement insuranceManagement = new InsuranceManagement();

                        insuranceManagement.InsuranceManagementFunction(
                            InsuranceCompanieNames, InsurancePolicyNumbers, InsuranceStartDates, InsuranceExpirationDates, 
                            InsuranceIds);

                        break;

                    
                    case 4:
                        MaintenanceManagement maintenanceManagement = new MaintenanceManagement();

                        maintenanceManagement.MaintenanceManagementFunction(
                            MaintenanceDates, MaintenanceServiceTypes, MaintenanceWorkshopNames,
                            MaintenanceOwnerFullNames, MaintenanceOwnerSocialIds,
                            MaintenanceIds);

                        break;

                    
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

        public void ViewAllCars(Dictionary<int, string> Brands, Dictionary<int, string> Models, Dictionary<int, int> Years, Dictionary<int, string> Colors, Dictionary<int, string> LicensePlateNumbers, List<int> Ids)
        {
            Console.WriteLine("Vehículos:");

            foreach (var id in Ids)
            {
                Console.WriteLine($"""
                        id: {id}   Marca: {Brands[id]}   Modelo: {Models[id]}   Año: {Years[id]}   Color: {Colors[id]}   Número de placa: {LicensePlateNumbers[id]}   Tipo de combustible: {LicensePlateNumbers[id]}
                        """);
            }
        }

        public void VehicleStorageFunction(
            Dictionary<int, string> Brands,
            Dictionary<int, string> Models,
            Dictionary<int, int> Years,
            Dictionary<int, string> Colors,
            Dictionary<int, string> LicensePlateNumbers,
            Dictionary<int, string> FuelTypes,
            List<int> Ids
            )
        {

            Console.WriteLine("""
                Favor escoja la acción que desee realizar:
                1.Agregar un nuevo registro de vehículo
                2.Editar la información de vehículo existentes
                3.Buscar vehículos por número de placa, marca o modelo
                4.Eliminar vehículos

                """);

            int userVehicleStorageSelection = Convert.ToInt32(Console.ReadLine());


            switch (userVehicleStorageSelection)
            {
                case 1:

                    int Id = Ids.Count() + 1;
                    Ids.Add(Id);

                    Console.WriteLine("Favor ingrese la marca del vehículo que desee registrar: ");
                    var Brand = Console.ReadLine();
                    Brands.Add(Id, Brand);

                    Console.WriteLine("Favor ingrese el modelo del vehículo que desee registrar: ");
                    var Model = Console.ReadLine();
                    Models.Add(Id, Model);

                    Console.WriteLine("Favor ingrese el año del vehículo que desee registrar: ");
                    var Year = Convert.ToInt32(Console.ReadLine());
                    Years.Add(Id, Year);

                    Console.WriteLine("Favor ingrese el color del vehículo que desee registrar: ");
                    var Color = Console.ReadLine();
                    Colors.Add(Id, Color);

                    Console.WriteLine("Favor ingrese el número de placa del vehículo que desee registrar: ");
                    var LicensePlateNumber = Console.ReadLine();
                    LicensePlateNumbers.Add(Id, LicensePlateNumber);

                    Console.WriteLine("Favor ingrese el tipo de combustible del vehículo que desee registrar: ");
                    var FuelType = Console.ReadLine();
                    FuelTypes.Add(Id, FuelType);

                    break;

                
                case 2:

                    var getAllNewElements = string.Empty;

                    Console.WriteLine("""
                        Favor escoja la acción que desee realizar:
                        1.Editar una información de un vehículo ya existente
                        2.Editar toda la información de un vehículo ya existente

                        """);

                    userVehicleStorageSelection = Convert.ToInt32(Console.ReadLine());

                    if (userVehicleStorageSelection == 1)
                    {
                        ViewAllCars(Brands, Models, Years, Colors, LicensePlateNumbers, Ids);

                        Console.WriteLine("Favor seleccione el id del vehículo que desee modificar: ");
                        GetId = Convert.ToInt32(Console.ReadLine());


                        foreach (var id in Ids)
                        {
                            if (id == GetId)
                            {
                                Console.WriteLine("Favor seleccione uno de los datos que desee modificar:");

                                Console.WriteLine("1.Marca 2.Modelo 3.Año 4.Color 5.Número de placa 6.Tipo de combustible");
                                int getElementToModifyCar = Convert.ToInt32(Console.ReadLine());

                                Console.WriteLine("Favor ingrese el nuevo elemento:");
                                var newElement = Console.ReadLine();


                                switch (getElementToModifyCar)
                                {
                                    case 1:

                                        Brands[id] = newElement;

                                        break;

                                    case 2:

                                        Models[id] = newElement;

                                        break;

                                    case 3:

                                        Years[id] = Convert.ToInt32(newElement);

                                        break;

                                    case 4:

                                        Colors[id] = newElement;

                                        break;

                                    case 5:

                                        LicensePlateNumbers[id] = newElement;

                                        break;

                                    case 6:

                                        FuelTypes[id] = newElement;

                                        break;
                                }
                            }
                        }
                    }

                    else if (userVehicleStorageSelection == 2)
                    {

                        ViewAllCars(Brands, Models, Years, Colors, LicensePlateNumbers, Ids);

                        Console.WriteLine("Favor seleccione el id del vehículo que desee modificar todos sus datos: ");
                        GetId = Convert.ToInt32(Console.ReadLine());


                        foreach (var id in Ids)
                        {
                            if (id == GetId)
                            {
                                Console.WriteLine("Favor ingrese la nueva marca: ");
                                getAllNewElements = Console.ReadLine();
                                Brands[id] = getAllNewElements;

                                Console.WriteLine("Favor ingrese el nuevo modelo: ");
                                getAllNewElements = Console.ReadLine();
                                Models[id] = getAllNewElements;

                                Console.WriteLine("Favor ingrese el nuevo año: ");
                                getAllNewElements = Console.ReadLine();
                                Years[id] = Convert.ToInt32(getAllNewElements);

                                Console.WriteLine("Favor ingrese el nuevo color: ");
                                getAllNewElements = Console.ReadLine();
                                Colors[id] = getAllNewElements;

                                Console.WriteLine("Favor ingrese el nuevo número de placa: ");
                                getAllNewElements = Console.ReadLine();
                                LicensePlateNumbers[id] = getAllNewElements;

                                Console.WriteLine("Favor ingrese el nuevo tipo de combustible: ");
                                getAllNewElements = Console.ReadLine();
                                FuelTypes[id] = getAllNewElements;
                            }
                        }
                    }

                    break;

                
                case 3:

                    Console.WriteLine("Favor ingrese el número de placa, marca o modelo del vehículo que desee buscar:");
                    SearchCriteria = Console.ReadLine().ToLower();

                    foreach (var id in Ids)
                    {
                        if (LicensePlateNumbers[id].ToLower().Contains(SearchCriteria) || Brands[id].ToLower().Contains(SearchCriteria) || Models[id].ToLower().Contains(SearchCriteria))
                        {
                            Console.WriteLine($"""
                                id: {id}   Marca: {Brands[id]}   Modelo: {Models[id]}   Año: {Years[id]}   Color: {Colors[id]}   Número de placa: {LicensePlateNumbers[id]}   Tipo de combustible: {LicensePlateNumbers[id]}
                                """);
                        }
                    }

                    break;

                
                case 4:

                    bool isCarRemoved = false;

                    ViewAllCars(Brands, Models, Years, Colors, LicensePlateNumbers, Ids);

                    Console.WriteLine("Favor ingrese el id del vehículo que desee eliminar");
                    GetId = Convert.ToInt32(Console.ReadLine());


                    foreach (var id in Ids.ToArray())
                    {
                        if (id == GetId)
                        {
                            Brands.Remove(id);
                            Models.Remove(id);
                            Years.Remove(id);
                            Colors.Remove(id);
                            LicensePlateNumbers.Remove(id);
                            FuelTypes.Remove(id);
                            Ids.Remove(id);

                            isCarRemoved = true;
                        }
                    }

                    if (isCarRemoved == true)
                    {
                        Console.WriteLine("Registro de vehículo eliminado satisfacoriamente.");
                    }
                        

                    break;
            }

            if (userVehicleStorageSelection > 4 || userVehicleStorageSelection == 0)
            {
                Console.WriteLine("Debe ingresar una de las opciones.");
            }
        }
    }

    public class OwnersManagament : MainVehicleRegistrationSystem
    {

        public void OwnersManagamentFunction(
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

            Console.WriteLine("""
                Favor escoja la acción que desea realizar: 
                1.Agregar un nuevo registro de propietario
                2.Asociar uno o más vehículos a un propietario
                3.Editar la información de los propietarios
                4.Buscar propietarios por nombre o cédula
                5.Eliminar propietarios

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


                    ViewAllCars(Brands, Models, Years, Colors, LicensePlateNumbers, Ids);

                    Console.WriteLine("Favor ingrese el id del vehículo para asociarlo con un propietario: ");
                    getCarIds.Add(Convert.ToInt32(Console.ReadLine()));


                    ViewAllOwners(OwnerFullNames, OwnerSocialIds, OwnerAddresses, OwnerPhoneNumbers, OwnerEmails, OwnerIds);

                    Console.WriteLine("Favor ingrese el id del propietario: ");
                    getOwnerIds.Add(Convert.ToInt32(Console.ReadLine()));

                    Console.WriteLine("¿Desea asociar más vehículos a un propietario?  1.Sí  2.No");
                    int wantToContinue = Convert.ToInt32(Console.ReadLine());

                    
                    while (wantToContinue != 2)
                    {
                        ViewAllCars(Brands, Models, Years, Colors, LicensePlateNumbers, Ids);

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
                        GetId = Convert.ToInt32(Console.ReadLine());


                        foreach (var ownerId in OwnerIds)
                        {
                            if (ownerId == GetId)
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
                        GetId = Convert.ToInt32(Console.ReadLine());


                        foreach (var ownerId in OwnerIds)
                        {
                            if (ownerId == GetId)
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
                    SearchCriteria = Console.ReadLine().ToLower();

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

                    bool isOwnerRemoved = false;

                    ViewAllOwners(OwnerFullNames, OwnerSocialIds, OwnerAddresses, OwnerPhoneNumbers, OwnerEmails, OwnerIds);

                    Console.WriteLine("Favor ingrese el id del registro de propietario que desee eliminar: ");
                    GetId = Convert.ToInt32(Console.ReadLine());


                    foreach (var ownerId in OwnerIds.ToArray())
                    {
                        if (ownerId == GetId)
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

            if (userOwnersManagamentSelection > 5 || userOwnersManagamentSelection == 0)
            {
                Console.WriteLine("Debe ingresar una de las opciones.");
            }
        }

        private static void ViewAllOwners(Dictionary<int, string> OwnerFullNames, Dictionary<int, string> OwnerSocialIds, Dictionary<int, string> OwnerAddresses, Dictionary<int, string> OwnerPhoneNumbers, Dictionary<int, string> OwnerEmails, List<int> OwnerIds)
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
    }

    public class InsuranceManagement : MainVehicleRegistrationSystem
    {
        public void InsuranceManagementFunction(
            Dictionary<int, string> InsuranceCompanieNames,
            Dictionary<int, string> InsurancePolicyNumbers,
            Dictionary<int, DateOnly> InsuranceStartDates,
            Dictionary<int, DateOnly> InsuranceExpirationDates,
            List<int> InsuranceIds
            ) 
        {
            
            
            Console.WriteLine("""
                Favor escoja la acción que desea realizar:
                1.Agregar un nuevo registro de seguro
                2.Editar la informacion de seguros existentes
                3.Mostrar los seguros próximos a vencer
                4.Eliminar seguros vencidos

                """);

            int userInsuranceManagementSelection = Convert.ToInt32(Console.ReadLine());


            switch (userInsuranceManagementSelection)
            {
                case 1:

                    int InsuranceId = InsuranceIds.Count() + 1;
                    InsuranceIds.Add(InsuranceId);


                    Console.WriteLine("Favor ingrese la compañía aseguradora que desee registrar: ");
                    var InsuranceCompanieName = Console.ReadLine();
                    InsuranceCompanieNames.Add(InsuranceId, InsuranceCompanieName);

                    Console.WriteLine("Favor ingrese el número de poliza que desee registrar: ");
                    var InsurancePolicyNumber = Console.ReadLine();
                    InsurancePolicyNumbers.Add(InsuranceId, InsurancePolicyNumber);

                    Console.WriteLine("Favor ingrese la fecha de inicio que desee registrar en el formato (aaaa-mm-dd): ");
                    var InsuranceStartDate = DateOnly.Parse(Console.ReadLine());
                    InsuranceStartDates.Add(InsuranceId, InsuranceStartDate);

                    Console.WriteLine("Favor ingrese la fecha de vencimiento que desee registrar en el formato (aaaa-mm-dd): ");
                    var InsuranceExpirationDate = DateOnly.Parse(Console.ReadLine());
                    InsuranceExpirationDates.Add(InsuranceId, InsuranceExpirationDate);

                    break;


                case 2:
                    var getAllNewElementsFromInsurances = string.Empty;

                    Console.WriteLine("""
                        Favor escoja la acción que desea realizar:
                        1.Editar una información de un seguro
                        2.Editar toda la información de un seguro

                        """);

                    userInsuranceManagementSelection = Convert.ToInt32(Console.ReadLine());

                    if (userInsuranceManagementSelection == 1)
                    {
                        ViewAllInsurances(InsuranceCompanieNames, InsurancePolicyNumbers, InsuranceStartDates, InsuranceExpirationDates,
                            InsuranceIds);

                        Console.WriteLine("Favor seleccione el id del registro de seguro que desee modificar: ");
                        GetId = Convert.ToInt32(Console.ReadLine());


                        foreach (var insuranceId in InsuranceIds)
                        {
                            if (insuranceId == GetId)
                            {
                                Console.WriteLine("Favor seleccione uno de los datos que desee modificar:");

                                Console.WriteLine("1.Compañía aseguradora 2.Número de póliza 3.fecha de inicio 4.fecha de vencimiento");

                                int getElementToModifyInsurance = Convert.ToInt32(Console.ReadLine());

                                Console.WriteLine("Favor ingrese el nuevo elemento:");
                                var newElementFromInsurances = Console.ReadLine();


                                switch (getElementToModifyInsurance)
                                {
                                    case 1:

                                        InsuranceCompanieNames[insuranceId] = newElementFromInsurances;

                                        break;

                                    case 2:

                                        InsurancePolicyNumbers[insuranceId] = newElementFromInsurances;

                                        break;

                                    case 3:

                                        InsuranceStartDates[insuranceId] = DateOnly.Parse(newElementFromInsurances);

                                        break;

                                    case 4:

                                        InsuranceExpirationDates[insuranceId] = DateOnly.Parse(newElementFromInsurances);

                                        break;
                                }
                            }
                        }
                    }

                    else if (userInsuranceManagementSelection == 2)
                    {
                        
                        ViewAllInsurances(InsuranceCompanieNames, InsurancePolicyNumbers, InsuranceStartDates, InsuranceExpirationDates,
                            InsuranceIds);

                        Console.WriteLine("Favor seleccione el id del registro de seguro que desee modificar: ");
                        GetId = Convert.ToInt32(Console.ReadLine());


                        foreach (var insuranceId in InsuranceIds)
                        {
                            if (insuranceId == GetId)
                            {
                                Console.WriteLine("Favor ingrese la nueva compañía aseguradora: ");
                                getAllNewElementsFromInsurances = Console.ReadLine();
                                InsuranceCompanieNames[insuranceId] = getAllNewElementsFromInsurances;

                                Console.WriteLine("Favor ingrese el nuevo número de póliza: ");
                                getAllNewElementsFromInsurances = Console.ReadLine();
                                InsurancePolicyNumbers[insuranceId] = getAllNewElementsFromInsurances;

                                Console.WriteLine("Favor ingrese la nueva fecha de inicio : ");
                                getAllNewElementsFromInsurances = Console.ReadLine();
                                InsuranceStartDates[insuranceId] = DateOnly.Parse(getAllNewElementsFromInsurances);

                                Console.WriteLine("Favor ingrese la nueva fecha de vencimiento : ");
                                getAllNewElementsFromInsurances = Console.ReadLine();
                                InsuranceExpirationDates[insuranceId] = DateOnly.Parse(getAllNewElementsFromInsurances);
                            }
                        }
                    }

                    break;

                
                case 3:

                    //Taking in consideration that the expiration date for all the insurances is 2025-12-30.
                    Console.WriteLine("La fecha de vencimiento para los seguros es 30/12/2025.");

                    Console.WriteLine("Seguro(s) próximos a vencer: ");

                    foreach (var insuranceId in InsuranceIds)
                    {
                        DateOnly getInsuranceDate = InsuranceExpirationDates[insuranceId];


                        if (getInsuranceDate.Year == 2025 && getInsuranceDate.Month == 11 && getInsuranceDate.Day >= 20)
                        {

                            Console.WriteLine($"""
                                id: {insuranceId}   Compañía aseguradora: {InsuranceCompanieNames[insuranceId]}   Número de póliza: {InsurancePolicyNumbers[insuranceId]}   Fecha de inicio: {InsuranceStartDates[insuranceId]}   Fecha de vencimiento: {InsuranceExpirationDates[insuranceId]}
                                """);
                        }
                    }

                    break;

                
                case 4:
                    bool isInsuranceExpired = false;

                    foreach (var insuranceId in InsuranceIds.ToArray())
                    {
                        DateOnly getInsuranceDateToRemoveIt = InsuranceExpirationDates[insuranceId];


                        if (getInsuranceDateToRemoveIt.Year == 2025 && getInsuranceDateToRemoveIt.Month == 11 && getInsuranceDateToRemoveIt.Day >= 20)
                        {

                            InsuranceCompanieNames.Remove(insuranceId);
                            InsurancePolicyNumbers.Remove(insuranceId);
                            InsuranceStartDates.Remove(insuranceId);
                            InsuranceExpirationDates.Remove(insuranceId);

                            InsuranceIds.Remove(insuranceId);

                            isInsuranceExpired = true;
                        } 
                    }

                    if (isInsuranceExpired == true)
                    {
                        Console.WriteLine("Seguros vencidos eliminados satisfactoriamente.");
                    }

                    break;
            }

            if (userInsuranceManagementSelection > 4 || userInsuranceManagementSelection == 0)
            {
                Console.WriteLine("Debe ingresar una de las opciones.");
            }
        }

        private static void ViewAllInsurances(Dictionary<int, string> InsuranceCompanieNames, Dictionary<int, string> InsurancePolicyNumbers, Dictionary<int, DateOnly> InsuranceStartDates, Dictionary<int, DateOnly> InsuranceExpirationDates, List<int> InsuranceIds)
        {
            Console.WriteLine("");

            Console.WriteLine("Seguros: ");

            foreach (var insuranceId in InsuranceIds)
            {
                Console.WriteLine($"""
                    id: {insuranceId}   Compañía aseguradora: {InsuranceCompanieNames[insuranceId]}   Número de póliza: {InsurancePolicyNumbers[insuranceId]}   Fecha de inicio: {InsuranceStartDates[insuranceId]}   Fecha de vencimiento: {InsuranceExpirationDates[insuranceId]}
                    """);
            }

            Console.WriteLine("");
        }
    }

    public class MaintenanceManagement : MainVehicleRegistrationSystem
    {
        public void MaintenanceManagementFunction(
            Dictionary<int, DateOnly> MaintenanceDates,
            Dictionary<int, string> MaintenanceServiceTypes,
            Dictionary<int, string> MaintenanceWorkshopNames,
            Dictionary<int, string> MaintenanceOwnerFullNames,
            Dictionary<int, string> MaintenanceOwnerSocialIds,
            List<int> MaintenanceIds
            )
        {
            
            Console.WriteLine("""
                Favor escoja la acción que desea realizar:
                1.Agregar un nuevo registro de mantenimiento
                2.Consultar el historial de mantenimientos
                3.Editar o eliminar registros de mantenimiento

                """);

            int userMaintenanceManagementSelection = Convert.ToInt32(Console.ReadLine());


            switch (userMaintenanceManagementSelection)
            {
                case 1:

                    int MaintenanceId = MaintenanceIds.Count() + 1;
                    MaintenanceIds.Add(MaintenanceId);


                    Console.WriteLine("Favor ingrese la fecha de mantenimiento que desee registrar en el formato (aaaa-mm-dd): ");
                    var MaintenanceDate = DateOnly.Parse(Console.ReadLine());
                    MaintenanceDates.Add(MaintenanceId, MaintenanceDate);

                    Console.WriteLine("Favor ingrese el tipo de servicio que desee registrar: ");
                    var MaintenanceServiceType = Console.ReadLine();
                    MaintenanceServiceTypes.Add(MaintenanceId, MaintenanceServiceType);

                    Console.WriteLine("Favor ingrese el nombre de taller que desee registrar: ");
                    var MaintenanceWorkshopName = Console.ReadLine();
                    MaintenanceWorkshopNames.Add(MaintenanceId, MaintenanceWorkshopName);

                    Console.WriteLine("Favor ingrese el nombre completo del propietario del vehículo que recibió el mantenimiento: ");
                    var MaintenanceOwnerFullName = Console.ReadLine();
                    MaintenanceOwnerFullNames.Add(MaintenanceId, MaintenanceOwnerFullName);

                    Console.WriteLine("Favor ingrese la cédula del propietario del vehículo que recibió el mantenimiento: ");
                    var MaintenanceOwnerSocialId = Console.ReadLine();
                    MaintenanceOwnerSocialIds.Add(MaintenanceId, MaintenanceOwnerSocialId);

                    break;

                
                case 2:
                    ViewAllMaintanences(MaintenanceDates, MaintenanceServiceTypes, MaintenanceWorkshopNames, MaintenanceOwnerFullNames, MaintenanceOwnerSocialIds, MaintenanceIds);

                    break;

                
                case 3:
                    var getAllNewElementsFromMaintenances = string.Empty;

                    bool isMaintenanceRemoved = false;

                    Console.WriteLine("""
                        1.Editar una información de un registro de mantenimiento
                        2.Editar toda la información de un registro de mantenimiento
                        3.Eliminar registros de mantenimiento

                        """);

                    userMaintenanceManagementSelection = Convert.ToInt32(Console.ReadLine());

                    if (userMaintenanceManagementSelection == 1)
                    {
                        ViewAllMaintanences(MaintenanceDates, MaintenanceServiceTypes, 
                            MaintenanceWorkshopNames, MaintenanceOwnerFullNames,MaintenanceOwnerSocialIds, 
                            MaintenanceIds);

                        Console.WriteLine("Favor seleccione el id del registro de mantenimiento que desee modificar: ");
                        GetId = Convert.ToInt32(Console.ReadLine());


                        foreach (var maintenanceId  in MaintenanceIds)
                        {
                            if (maintenanceId == GetId)
                            {
                                Console.WriteLine("Favor seleccione uno de los datos que desee modificar:");

                                Console.WriteLine("""
                                    1.Fecha del mantenimiento
                                    2.Tipo de servicio
                                    3.Nombre del taller
                                    4.Nombre completo del propietario del vehículo
                                    5.Cédula del propietario del vehículo
                                    
                                    """);

                                int getElementToModifyMaintenance = Convert.ToInt32(Console.ReadLine());

                                Console.WriteLine("Favor ingrese el nuevo elemento:");
                                var newElementFromMaintenance = Console.ReadLine();


                                switch (getElementToModifyMaintenance)
                                {
                                    case 1:

                                        MaintenanceDates[maintenanceId] = DateOnly.Parse(newElementFromMaintenance);

                                        break;

                                    case 2:

                                        MaintenanceServiceTypes[maintenanceId] = newElementFromMaintenance;

                                        break;

                                    case 3:

                                        MaintenanceWorkshopNames[maintenanceId] = newElementFromMaintenance;

                                        break;

                                    case 4:

                                        MaintenanceOwnerFullNames[maintenanceId] = newElementFromMaintenance;

                                        break;

                                    case 5:

                                        MaintenanceOwnerSocialIds[maintenanceId] = newElementFromMaintenance;

                                        break;
                                }
                            }
                        }
                    }

                    else if (userMaintenanceManagementSelection == 2)
                    {

                        ViewAllMaintanences(MaintenanceDates, MaintenanceServiceTypes,
                            MaintenanceWorkshopNames, MaintenanceOwnerFullNames, MaintenanceOwnerSocialIds,
                            MaintenanceIds);

                        Console.WriteLine("Favor seleccione el id del registro de mantenimiento que desea modificar: ");
                        GetId = Convert.ToInt32(Console.ReadLine());


                        foreach (var maintenanceId in MaintenanceIds)
                        {
                            if (maintenanceId == GetId)
                            {
                                Console.WriteLine("Favor ingrese la nueva fecha de mantenimiento: ");
                                getAllNewElementsFromMaintenances = Console.ReadLine();
                                MaintenanceDates[maintenanceId] = DateOnly.Parse(getAllNewElementsFromMaintenances);

                                Console.WriteLine("Favor ingrese el nuevo tipo de servicio: ");
                                getAllNewElementsFromMaintenances = Console.ReadLine();
                                MaintenanceServiceTypes[maintenanceId] = getAllNewElementsFromMaintenances;

                                Console.WriteLine("Favor ingrese el nuevo nombre de taller: ");
                                getAllNewElementsFromMaintenances = Console.ReadLine();
                                MaintenanceWorkshopNames[maintenanceId] = getAllNewElementsFromMaintenances;

                                Console.WriteLine("Favor ingrese el nuevo nombre completo del propietario del vehículo: ");
                                getAllNewElementsFromMaintenances = Console.ReadLine();
                                MaintenanceOwnerFullNames[maintenanceId] = getAllNewElementsFromMaintenances;

                                Console.WriteLine("Favor ingrese la nueva cédula del propietario del vehículo: ");
                                getAllNewElementsFromMaintenances = Console.ReadLine();
                                MaintenanceOwnerSocialIds[maintenanceId] = getAllNewElementsFromMaintenances;
                            }
                        }
                    }

                    
                    else if (userMaintenanceManagementSelection == 3)
                    {
                        ViewAllMaintanences(MaintenanceDates, MaintenanceServiceTypes,
                            MaintenanceWorkshopNames, MaintenanceOwnerFullNames, MaintenanceOwnerSocialIds,
                            MaintenanceIds);


                        Console.WriteLine("Favor ingrese el id del registro de mantenimiento que desee eliminar: ");
                        GetId = Convert.ToInt32(Console.ReadLine());

                        foreach (var maintenanceId in MaintenanceIds.ToArray())
                        {
                            if (maintenanceId == GetId)
                            {
                                MaintenanceDates.Remove(maintenanceId);
                                MaintenanceServiceTypes.Remove(maintenanceId);
                                MaintenanceWorkshopNames.Remove(maintenanceId);
                                MaintenanceWorkshopNames.Remove(maintenanceId);
                                MaintenanceOwnerSocialIds.Remove(maintenanceId);

                                MaintenanceIds.Remove(maintenanceId);

                                isMaintenanceRemoved = true;
                            }
                        }

                        
                    }


                    if (isMaintenanceRemoved == true)
                    {
                        Console.WriteLine("Registro de mantenimiento eliminado satisfactoriamente.");
                    }
                        

                    break;
            }

            if (userMaintenanceManagementSelection > 3 || userMaintenanceManagementSelection == 0)
            {
                Console.WriteLine("Debe ingresar una de las opciones.");
            }
        }


        private static void ViewAllMaintanences(Dictionary<int, DateOnly> MaintenanceDates, Dictionary<int, string> MaintenanceServiceTypes, Dictionary<int, string> MaintenanceWorkshopNames, Dictionary<int, string> MaintenanceOwnerFullNames, Dictionary<int, string> MaintenanceOwnerSocialIds, List<int> MaintenanceIds)
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





