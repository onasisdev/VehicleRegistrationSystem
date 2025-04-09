using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace VehicleRegistrationSystem
{
    public class Program
    {

        static void Main(string[] args)
        {

            MainVehicleRegistrationSystem mainVehicleRegistrationSystem = new MainVehicleRegistrationSystem();
            mainVehicleRegistrationSystem.userActionSelection();
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
        public int getId { get; set; }


        public Dictionary<int, string> OwnerFullNames = new Dictionary<int, string>();
        public Dictionary<int, int> OwnerSocialIds = new Dictionary<int, int>();
        public Dictionary<int, string> OwnerAddresses = new Dictionary<int, string>();
        public Dictionary<int, int> OwnerPhoneNumbers = new Dictionary<int, int>();
        public Dictionary<int, string> OwnerEmails = new Dictionary<int, string>();
        public List<int> OwnerIds = new List<int>();


        public void userActionSelection()
        {
            bool running = true;


            while (running)
            {
                Console.WriteLine("""
                Favor escoja la acción que desea realizar:
                1.Almacenar vehículos
                2.Gestionar Propietarios
                3.Gestionar Seguros
                4.Registrar mantenimientos
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

                    case 5:

                        running = false;

                        break;
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

            Console.WriteLine("");
        }

        public void VehicleStorageFunction(
            Dictionary<int, string>Brands, 
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
                1.Agregar un nuevo vehículo.
                2.Editar la informacion de vehiculos existentes.
                3.Buscar vehículos por número de placa, marca o modelo.
                4.Eliminar vehículos.

                """);
            
            int userVehicleStorageSelection = Convert.ToInt32(Console.ReadLine());
            
            
            switch (userVehicleStorageSelection)
            {
                case 1:
                    int Id = Ids.Count() + 1;
                    Ids.Add(Id);

                    Console.WriteLine("Favor ingrese la marca del vehículo que desea almacenar: ");
                    var Brand = Console.ReadLine();
                    Brands.Add(Id, Brand);


                    Console.WriteLine("Favor ingrese el modelo del vehículo que desea almacenar: ");
                    var Model = Console.ReadLine();
                    Models.Add(Id, Model);


                    Console.WriteLine("Favor ingrese el año del vehículo que desea almacenar: ");
                    var Year = Convert.ToInt32(Console.ReadLine());
                    Years.Add(Id, Year);


                    Console.WriteLine("Favor ingrese el color del vehículo que desea almacenar: ");
                    var Color = Console.ReadLine();
                    Colors.Add(Id, Color);


                    Console.WriteLine("Favor ingrese el número de placa del vehículo que desea almacenar: ");
                    var LicensePlateNumber = Console.ReadLine();
                    LicensePlateNumbers.Add(Id, LicensePlateNumber);


                    Console.WriteLine("Favor ingrese el tipo de combustible del vehículo que desea almacenar: ");
                    var FuelType = Console.ReadLine();
                    FuelTypes.Add(Id, FuelType);

                    break;

                
                case 2:

                    var getAllElements = string.Empty;

                    Console.WriteLine("""
                        Favor escoja la acción que desea realizar:
                        1.Editar una información de un vehículo ya existente.
                        2.Editar toda la información de un vehículo ya existente.

                        """);

                    userVehicleStorageSelection = Convert.ToInt32(Console.ReadLine());

                    if (userVehicleStorageSelection == 1)
                    {
                        ViewAllCars(Brands, Models, Years, Colors, LicensePlateNumbers, Ids);

                        Console.WriteLine("Favor seleccione el id del carro que desea cambiar: ");
                        getId = Convert.ToInt32(Console.ReadLine());


                        foreach (var id in Ids)
                        {
                            if (id == getId)
                            {
                                Console.WriteLine("Favor seleccione uno de los datos que desee cambiar:");

                                Console.WriteLine("1.Marca 2.Modelo 3.Año 4.Color 5.Número de placa 6.Tipo de combustible");
                                int getElementToModifyCar = Convert.ToInt32(Console.ReadLine());

                                Console.WriteLine("Ingrese el nuevo elemtno:");
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

                        Console.WriteLine("Favor seleccione el id del vehículo que desea cambiar todos sus datos: ");
                        getId = Convert.ToInt32(Console.ReadLine());


                        foreach (var id in Ids)
                        {
                            if (id == getId)
                            {
                                Console.WriteLine("Favor ingrese la nueva marca: ");
                                getAllElements = Console.ReadLine();
                                Brands[id] = getAllElements;

                                Console.WriteLine("Favor ingrese el nuevo modelo: ");
                                getAllElements = Console.ReadLine();
                                Models[id] = getAllElements;

                                Console.WriteLine("Favor ingrese el nuevo año: ");
                                getAllElements = Console.ReadLine();
                                Years[id] = Convert.ToInt32(getAllElements);

                                Console.WriteLine("Favor ingrese el nuevo color: ");
                                getAllElements = Console.ReadLine();
                                Colors[id] = getAllElements;

                                Console.WriteLine("Favor ingrese el nuevo número de placa: ");
                                getAllElements = Console.ReadLine();
                                LicensePlateNumbers[id] = getAllElements;

                                Console.WriteLine("Favor ingrese el nuevo tipo de combustible: ");
                                getAllElements = Console.ReadLine();
                                FuelTypes[id] = getAllElements;
                            }
                        }
                    }
                    break;

                case 3:

                    Console.WriteLine("Favor ingrese el número de placa, marca o modelo del vehíçulo que desee buscar:");
                    var searchCriteria = Console.ReadLine();

                    foreach (var id in Ids)
                    {
                        if (LicensePlateNumbers[id].ToLower().Contains(searchCriteria) || Brands[id].ToLower().Contains(searchCriteria) || Models[id].ToLower().Contains(searchCriteria))
                            {
                            Console.WriteLine($"""
                                id: {id}   Marca: {Brands[id]}   Modelo: {Models[id]}   Año: {Years[id]}   Color: {Colors[id]}   Número de placa: {LicensePlateNumbers[id]}   Tipo de combustible: {LicensePlateNumbers[id]}
                                """);
                        }
                    }

                    break;

                case 4:

                    ViewAllCars(Brands, Models, Years, Colors, LicensePlateNumbers, Ids);

                    Console.WriteLine("Favor ingrese el id del vehículo que desee eliminar");
                    getId = Convert.ToInt32(Console.ReadLine());
                    
                    
                    foreach (var id in Ids.ToArray())
                    {
                        if (id == getId)
                        {
                            Brands.Remove(id);
                            Models.Remove(id);
                            Years.Remove(id);
                            Colors.Remove(id);
                            LicensePlateNumbers.Remove(id);
                            FuelTypes.Remove(id);
                            Ids.Remove(id);
                        }
                    }
                    
                    break;
            }    
        }
    }

    public class OwnersManagament : MainVehicleRegistrationSystem
    {
      
        public void OwnersManagamentFunction(
            Dictionary<int, string> OwnerFullNames,
            Dictionary<int, int> OwnerSocialIds, 
            Dictionary<int, string> OwnerAddresses, 
            Dictionary<int, int> OwnerPhoneNumbers ,
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
                1.Agregar un nuevo propietario.
                2.Asociar uno o más vehículos a un propietario.
                3.Editar la información de los propietarios.
                4.Buscar propietarios por nombre o cédula.
                5.Eliminar propietarios.

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
                    var OwnerSocialId = Convert.ToInt32(Console.ReadLine());
                    OwnerSocialIds.Add(OwnerId, OwnerSocialId);

                    Console.WriteLine("Favor ingrese la dirección del propietario: ");
                    var OwnerAddress = Console.ReadLine();
                    OwnerAddresses.Add(OwnerId, OwnerAddress);

                    Console.WriteLine("Favor ingrese el teléfono del propietario: ");
                    var OwnerPhoneNumber = Convert.ToInt32(Console.ReadLine());
                    OwnerPhoneNumbers.Add(OwnerId, OwnerPhoneNumber);

                    Console.WriteLine("Favor ingrese el correo electrónico del propietario: ");
                    var OwnerEmail = Console.ReadLine();
                    OwnerEmails.Add(OwnerId, OwnerEmail);

                    break;


                case 2:

                    List<int> getCarIds = new List<int>();
                    List<int> getOwnerIds = new List<int>();


                    ViewAllCars(Brands, Models, Years, Colors, LicensePlateNumbers, Ids);

                    Console.WriteLine("Ingrese el id del vehículo para asociarlo con un propietario: ");
                    getCarIds.Add(Convert.ToInt32(Console.ReadLine()));

                    
                    ViewAllOwners(OwnerFullNames, OwnerSocialIds, OwnerAddresses, OwnerPhoneNumbers, OwnerEmails, OwnerIds);

                    Console.WriteLine("Ingrese el id del propietario: ");
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
            }
        }

        private static void ViewAllOwners(Dictionary<int, string> OwnerFullNames, Dictionary<int, int> OwnerSocialIds, Dictionary<int, string> OwnerAddresses, Dictionary<int, int> OwnerPhoneNumbers, Dictionary<int, string> OwnerEmails, List<int> OwnerIds)
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
}





