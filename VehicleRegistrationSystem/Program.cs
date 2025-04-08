using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace VehicleRegistrationSystem
{
    public class Program
    {

        static void Main(string[] args)
        {

            VehicleStorage vehicleStorage = new VehicleStorage();
            vehicleStorage.userActionSelection();

        }

    }

    public class VehicleStorage
    {

        public Dictionary<int, string> Brand = new Dictionary<int, string>();
        public Dictionary<int, string> Model = new Dictionary<int, string>();
        public Dictionary<int, int> Year = new Dictionary<int, int>();
        public Dictionary<int, string> Color = new Dictionary<int, string>();
        public Dictionary<int, string> LicensePlateNumber = new Dictionary<int, string>();
        public Dictionary<int, string> FuelType = new Dictionary<int, string>();

        public List<int> Id = new List<int>();


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
                        VehicleStorageFunction(Brand, Model, Year, Color, LicensePlateNumber, FuelType, Id);
                        
                        break;

                    case 5:
                        running = false;

                        break;
                }
            }
        }

        
        public void VehicleStorageFunction(Dictionary<int, string> Brands, Dictionary<int, string> Models, Dictionary<int, int> Years, Dictionary<int, string> Colors, Dictionary<int, string> LicensePlateNumbers, Dictionary<int, string> FuelTypes, List<int> Ids)
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

                    int getId;

                    var getAllElements = string.Empty;

                    Console.WriteLine("""
                        Favor escoja la acción que desea realizar:
                        1.Editar una información de un vehículo ya existente.
                        2.Editar toda la información de un vehículo ya existente.

                        """);

                    userVehicleStorageSelection = Convert.ToInt32(Console.ReadLine());

                    if (userVehicleStorageSelection == 1)
                    {
                        Console.WriteLine("Vehículos:");
                        foreach (var id in Ids)
                        {
                            Console.WriteLine($"""
                                id: {id}   Marca: {Brands[id]}   Modelo: {Models[id]}   Año: {Years[id]}   Color: {Colors[id]}   Número de placa: {LicensePlateNumbers[id]}   Tipo de combustible: {LicensePlateNumbers[id]}
                                """);
                        }

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

                        Console.WriteLine("Vehículos:");

                        foreach (var id in Ids)
                        {
                            Console.WriteLine($"""
                                id: {id}   Marca: {Brands[id]}   Modelo: {Models[id]}   Año: {Years[id]}   Color: {Colors[id]}   Número de placa: {LicensePlateNumbers[id]}   Tipo de combustible: {LicensePlateNumbers[id]}
                                """);
                        }

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
            }
        }
    }
}
