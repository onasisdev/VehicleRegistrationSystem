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



        //public VehicleStorage(List<string> Brand, List<string> Model, List<int> Year, List<string> Color, List<string> LicensePlateNumber, List<string> FuelType) 
        //{ 
        //    this.Brand = Brand;
        //    this.Model = Model;
        //    this.Year = Year;
        //    this.Color = Color;
        //    this.LicensePlateNumber = LicensePlateNumber;
        //    this.FuelType = FuelType;
        //}

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
                        //case 5:
                        //    running = false;

                        //    break;
                }
            }



        }

        public void VehicleStorageFunction(Dictionary<int, string> Brands, Dictionary<int, string> Models, Dictionary<int, int> Years, Dictionary<int, string> Colors, Dictionary<int, string> LicensePlateNumbers, Dictionary<int, string> FuelTypes, List<int> Ids)
        {

            Console.WriteLine("""
                Favor escoja la acción que desea realizar: 
                1. Agregar un nuevo vehículo 
                2. Editar la informacion de vehiculos existentes
                3. Buscar vehículos por número de placa, marca o modelo.
                4. Eliminar vehículos.

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




            }


        }



    }
}
