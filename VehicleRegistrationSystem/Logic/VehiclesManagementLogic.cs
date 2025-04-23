using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Interfaces;
using System.Data.SqlClient;
using DataBase;

namespace Logic
{

    
    public class VehiclesManagementLogic : IVehiclesManagament
    {
    
        
        public void ViewAllVehicles(Dictionary<int, string> getBrands,
            Dictionary<int, string> getModels,
            Dictionary<int, int> getYears,
            Dictionary<int, string> getColors,
            Dictionary<int, string> getLicensePlateNumbers,
            Dictionary<int, string> getFuelTypes,
            List<int> getIds)
        {
            Console.WriteLine("Vehículos:");

            foreach (var id in getIds)
            {
                Console.WriteLine($"""
                        id: {id}   Marca: {getBrands[id]}   Modelo: {getModels[id]}   Año: {getYears[id]}   Color: {getColors[id]}   Número de placa: {getLicensePlateNumbers[id]}   Tipo de combustible: {getFuelTypes[id]}
                        """);
            }
        }

        protected static void ConnectAndInsertElementsToDataBase(
            Dictionary<int, string> getBrands,
            Dictionary<int, string> getModels,
            Dictionary<int, int> getYears,
            Dictionary<int, string> getColors,
            Dictionary<int, string> getLicensePlateNumbers,
            Dictionary<int, string> getFuelTypes,
            List<int> getIds
          )
            
        {
            int Id = getIds.Count;
            

            Database database = new Database();

            using (SqlConnection conn = new SqlConnection(database.ConnectionToDatabase))
            {
                
                conn.Open();
                string sql = "INSERT INTO Vehiculo (Marca, Modelo, Anio, Color, NumeroDePlaca, TipoDeCombustible) VALUES (@Marca, @Modelo, @Anio, @Color, @NumeroDePlaca, @TipoDeCombustible)";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@Marca", getBrands[Id]);
                cmd.Parameters.AddWithValue("@Modelo", getModels[Id]);
                cmd.Parameters.AddWithValue("@Anio", getYears[Id]);
                cmd.Parameters.AddWithValue("@Color", getColors[Id]);
                cmd.Parameters.AddWithValue("@NumeroDePlaca", getLicensePlateNumbers[Id]);
                cmd.Parameters.AddWithValue("@TipoDeCombustible", getFuelTypes[Id]);

                cmd.ExecuteNonQuery();
            }
        }

        public void VehiclesManagementF(
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
                4.Consultar el historial de vehículos.
                5.Eliminar vehículos

                """);

            int userVehicleStorageSelection = Convert.ToInt32(Console.ReadLine());
            int getId = 0;
            

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

                    ConnectAndInsertElementsToDataBase(Brands, Models, 
                        Years, Colors,LicensePlateNumbers,
                        FuelTypes, Ids);

                    break;


                case 2:
                    Database database = new Database();

                    var getAllNewElements = string.Empty;

                    Console.WriteLine("""
                        Favor escoja la acción que desee realizar:
                        1.Editar una información de un vehículo ya existente
                        2.Editar toda la información de un vehículo ya existente

                        """);

                    userVehicleStorageSelection = Convert.ToInt32(Console.ReadLine());

                    if (userVehicleStorageSelection == 1)
                    {

                        ViewAllVehicles(Brands, Models, Years, Colors, LicensePlateNumbers, FuelTypes, Ids);

                        Console.WriteLine("Favor seleccione el id del vehículo que desee modificar: ");
                        getId = Convert.ToInt32(Console.ReadLine());


                        foreach (var id in Ids)
                        {
                            if (id == getId)
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

                                        using (SqlConnection conn = new SqlConnection(database.ConnectionToDatabase))
                                        {

                                            conn.Open();
                                            string sql = "UPDATE Vehiculo SET Marca = @Marca WHERE Id = @Id ";
                                            SqlCommand cmd = new SqlCommand(sql, conn);

                                            cmd.Parameters.AddWithValue("@Id", id);
                                            cmd.Parameters.AddWithValue("@Marca", Brands[id]);
                                            
                                            cmd.ExecuteNonQuery();
                                        }

                                        break;

                                    case 2:

                                        Models[id] = newElement;

                                        using (SqlConnection conn = new SqlConnection(database.ConnectionToDatabase))
                                        {

                                            conn.Open();
                                            string sql = "UPDATE Vehiculo SET Modelo = @Modelo WHERE Id = @Id ";
                                            SqlCommand cmd = new SqlCommand(sql, conn);

                                            cmd.Parameters.AddWithValue("@Id", id);
                                            cmd.Parameters.AddWithValue("@Modelo", Models[id]);

                                            cmd.ExecuteNonQuery();
                                        }

                                        break;

                                    case 3:

                                        Years[id] = Convert.ToInt32(newElement);

                                        using (SqlConnection conn = new SqlConnection(database.ConnectionToDatabase))
                                        {

                                            conn.Open();
                                            string sql = "UPDATE Vehiculo SET Anio = @Anio WHERE Id = @Id ";
                                            SqlCommand cmd = new SqlCommand(sql, conn);

                                            cmd.Parameters.AddWithValue("@Id", id);
                                            cmd.Parameters.AddWithValue("@Anio", Years[id]);

                                            cmd.ExecuteNonQuery();
                                        }

                                        break;

                                    case 4:

                                        Colors[id] = newElement;

                                        using (SqlConnection conn = new SqlConnection(database.ConnectionToDatabase))
                                        {

                                            conn.Open();
                                            string sql = "UPDATE Vehiculo SET Color = @Color WHERE Id = @Id ";
                                            SqlCommand cmd = new SqlCommand(sql, conn);

                                            cmd.Parameters.AddWithValue("@Id", id);
                                            cmd.Parameters.AddWithValue("@Color", Colors[id]);

                                            cmd.ExecuteNonQuery();
                                        }

                                        break;

                                    case 5:

                                        LicensePlateNumbers[id] = newElement;

                                        using (SqlConnection conn = new SqlConnection(database.ConnectionToDatabase))
                                        {

                                            conn.Open();
                                            string sql = "UPDATE Vehiculo SET NumeroDePlaca = @NumeroDePlaca WHERE Id = @Id ";
                                            SqlCommand cmd = new SqlCommand(sql, conn);

                                            cmd.Parameters.AddWithValue("@Id", id);
                                            cmd.Parameters.AddWithValue("@NumeroDePlaca", LicensePlateNumbers[id]);

                                            cmd.ExecuteNonQuery();
                                        }



                                        break;

                                    case 6:

                                        FuelTypes[id] = newElement;

                                        using (SqlConnection conn = new SqlConnection(database.ConnectionToDatabase))
                                        {

                                            conn.Open();
                                            string sql = "UPDATE Vehiculo SET TipoDeCombustible = @TipoDeCombustible WHERE Id = @Id ";
                                            SqlCommand cmd = new SqlCommand(sql, conn);

                                            cmd.Parameters.AddWithValue("@Id", id);
                                            cmd.Parameters.AddWithValue("@TipoDeCombustible", FuelTypes[id]);

                                            cmd.ExecuteNonQuery();
                                        }

                                        break;
                                }
                            }
                        }
                    }

                    else if (userVehicleStorageSelection == 2)
                    {

                        ViewAllVehicles(Brands, Models, Years, Colors, LicensePlateNumbers, FuelTypes, Ids);

                        Console.WriteLine("Favor seleccione el id del vehículo que desee modificar todos sus datos: ");
                        getId = Convert.ToInt32(Console.ReadLine());


                        foreach (var id in Ids)
                        {
                            if (id == getId)
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

                               

                                using (SqlConnection conn = new SqlConnection(database.ConnectionToDatabase))
                                {

                                    conn.Open();
                                    string sql = "UPDATE Vehiculo SET Marca = @Marca, Modelo = @Modelo, Anio = @Anio, Color = @Color, NumeroDePlaca = @NumeroDePlaca, TipoDeCombustible = @TipoDeCombustible  WHERE Id = @Id ";
                                    SqlCommand cmd = new SqlCommand(sql, conn);

                                    cmd.Parameters.AddWithValue("@Id", id);
                                    cmd.Parameters.AddWithValue("@Marca", Brands[id]);
                                    cmd.Parameters.AddWithValue("@Modelo", Models[id]);
                                    cmd.Parameters.AddWithValue("@Anio", Years[id]);
                                    cmd.Parameters.AddWithValue("@Color", Colors[id]);
                                    cmd.Parameters.AddWithValue("@NumeroDePlaca", LicensePlateNumbers[id]);
                                    cmd.Parameters.AddWithValue("@TipoDeCombustible", FuelTypes[id]);

                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                    }

                    break;


                case 3:

                    Console.WriteLine("Favor ingrese el número de placa, marca o modelo del vehículo que desee buscar:");
                    var SearchCriteria = Console.ReadLine().ToLower();

                    foreach (var id in Ids)
                    {
                        if (LicensePlateNumbers[id].ToLower().Contains(SearchCriteria) || Brands[id].ToLower().Contains(SearchCriteria) || Models[id].ToLower().Contains(SearchCriteria))
                        {
                            Console.WriteLine($"""
                                id: {id}   Marca: {Brands[id]}   Modelo: {Models[id]}   Año: {Years[id]}   Color: {Colors[id]}   Número de placa: {LicensePlateNumbers[id]}   Tipo de combustible: {FuelTypes[id]}
                                """);
                        }
                    }

                    break;


                case 4:

                    ViewAllVehicles(Brands, Models, Years, Colors, LicensePlateNumbers, FuelTypes, Ids);
                    
                    break;

                case 5:

                    bool isCarRemoved = false;

                    ViewAllVehicles(Brands, Models, Years, Colors, LicensePlateNumbers, FuelTypes, Ids);

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

                            isCarRemoved = true;
                        }
                    }

                    if (isCarRemoved == true)
                    {
                        Console.WriteLine("Registro de vehículo eliminado satisfacoriamente.");
                    }

                    break;
            }

            if (userVehicleStorageSelection > 5 || userVehicleStorageSelection == 0)
            {
                Console.WriteLine("Debe ingresar una de las opciones.");
            }
        }
    }
}