using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using Entities;
using Logic;
using System.Data.SqlClient;
using DataBase;

namespace Logic
{
    public class MaintenancesManagementLogic : IMaintenancesManagement
    {

        public void ViewAllMaintenances(
            Dictionary<int, DateOnly> getMaintenanceDates,
            Dictionary<int, string> getMaintenanceServiceTypes,
            Dictionary<int, string> getMaintenanceWorkshopNames,
            Dictionary<int, string> getMaintenanceOwnerFullNames,
            Dictionary<int, string> getMaintenanceOwnerSocialIds,
            List<int> getMaintenanceIds
            )
        {
            Console.WriteLine("");

            Console.WriteLine("Mantenimientos: ");

            foreach (var maintenanceId in getMaintenanceIds)
            {
                Console.WriteLine($"""
                    id: {maintenanceId}   Fecha del mantenimiento: {getMaintenanceDates[maintenanceId]}   Tipo de servicio: {getMaintenanceServiceTypes[maintenanceId]}   Nombre del taller: {getMaintenanceWorkshopNames[maintenanceId]} Nombre completo del propietario: {getMaintenanceOwnerFullNames[maintenanceId]}   Cédula del propietario: {getMaintenanceOwnerSocialIds[maintenanceId]}
                    """);
            }

            Console.WriteLine("");
        }

        protected static void ConnectAndInsertElementsToDataBase(
            Dictionary<int, DateOnly> getMaintenanceDates,
            Dictionary<int, string> getMaintenanceServiceTypes,
            Dictionary<int, string> getMaintenanceWorkshopNames,
            Dictionary<int, string> getMaintenanceOwnerFullNames,
            Dictionary<int, string> getMaintenanceOwnerSocialIds,
            List<int> getMaintenanceIds
          )

        {
            int Id = getMaintenanceDates.Count;

            Database database = new Database();

            
            using (SqlConnection conn = new SqlConnection(database.ConnectionToDatabase))
            {
                conn.Open();
                string sql = "INSERT INTO Mantenimiento (FechaDeMantenimiento, TipoDeServicio, NombreDeTaller, NombreCompletoPropietario, CedulaDelPropietario) VALUES (@FechaDeMantenimiento, @TipoDeServicio, @NombreDeTaller, @NombreCompletoPropietario, @CedulaDelPropietario)";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@FechaDeMantenimiento", getMaintenanceDates[Id].ToString());
                cmd.Parameters.AddWithValue("@TipoDeServicio", getMaintenanceServiceTypes[Id]);
                cmd.Parameters.AddWithValue("@NombreDeTaller", getMaintenanceWorkshopNames[Id]);
                cmd.Parameters.AddWithValue("@NombreCompletoPropietario", getMaintenanceOwnerFullNames[Id]);
                cmd.Parameters.AddWithValue("@CedulaDelPropietario", getMaintenanceOwnerSocialIds[Id]);

                cmd.ExecuteNonQuery();
            }
        }

        public void MaintenancesManagementF(
            Dictionary<int, DateOnly> MaintenanceDates,
            Dictionary<int, string> MaintenanceServiceTypes,
            Dictionary<int, string> MaintenanceWorkshopNames,
            Dictionary<int, string> MaintenanceOwnerFullNames,
            Dictionary<int, string> MaintenanceOwnerSocialIds,
            List<int> MaintenanceIds
            )
        {
            int getId;

            Database database = new Database();
            

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

                    ConnectAndInsertElementsToDataBase(MaintenanceDates, MaintenanceServiceTypes, 
                        MaintenanceWorkshopNames, MaintenanceOwnerFullNames, 
                        MaintenanceOwnerSocialIds, MaintenanceIds);

                    break;


                case 2:
                    ViewAllMaintenances(MaintenanceDates, MaintenanceServiceTypes, 
                        MaintenanceWorkshopNames, MaintenanceOwnerFullNames, 
                        MaintenanceOwnerSocialIds, MaintenanceIds);

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
                        ViewAllMaintenances(MaintenanceDates, MaintenanceServiceTypes,
                            MaintenanceWorkshopNames, MaintenanceOwnerFullNames, 
                            MaintenanceOwnerSocialIds, MaintenanceIds);

                        Console.WriteLine("Favor seleccione el id del registro de mantenimiento que desee modificar: ");
                        getId = Convert.ToInt32(Console.ReadLine());


                        foreach (var maintenanceId in MaintenanceIds)
                        {
                            if (maintenanceId == getId)
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

                                        using (SqlConnection conn = new SqlConnection(database.ConnectionToDatabase))
                                        {
                                            conn.Open();
                                            string updateQuery = "UPDATE Mantenimiento SET FechaDeMantenimiento = @FechaDeMantenimiento WHERE Id = @Id ";
                                            SqlCommand cmd = new SqlCommand(updateQuery, conn);

                                            cmd.Parameters.AddWithValue("@Id", maintenanceId);
                                            cmd.Parameters.AddWithValue("@FechaDeMantenimiento", MaintenanceDates[maintenanceId].ToString());

                                            cmd.ExecuteNonQuery();
                                        }

                                        break;

                                    
                                    case 2:

                                        MaintenanceServiceTypes[maintenanceId] = newElementFromMaintenance;

                                        using (SqlConnection conn = new SqlConnection(database.ConnectionToDatabase))
                                        {
                                            conn.Open();
                                            string updateQuery = "UPDATE Mantenimiento SET TipoDeServicio = @TipoDeServicio WHERE Id = @Id ";
                                            SqlCommand cmd = new SqlCommand(updateQuery, conn);

                                            cmd.Parameters.AddWithValue("@Id", maintenanceId);
                                            cmd.Parameters.AddWithValue("@TipoDeServicio", MaintenanceServiceTypes[maintenanceId]);

                                            cmd.ExecuteNonQuery();
                                        }

                                        break;

                                    
                                    case 3:

                                        MaintenanceWorkshopNames[maintenanceId] = newElementFromMaintenance;

                                        using (SqlConnection conn = new SqlConnection(database.ConnectionToDatabase))
                                        {
                                            conn.Open();
                                            string updateQuery = "UPDATE Mantenimiento SET NombreDeTaller = @NombreDeTaller WHERE Id = @Id ";
                                            SqlCommand cmd = new SqlCommand(updateQuery, conn);

                                            cmd.Parameters.AddWithValue("@Id", maintenanceId);
                                            cmd.Parameters.AddWithValue("@NombreDeTaller", MaintenanceWorkshopNames[maintenanceId]);

                                            cmd.ExecuteNonQuery();
                                        }

                                        break;

                                    
                                    case 4:

                                        MaintenanceOwnerFullNames[maintenanceId] = newElementFromMaintenance;

                                        
                                        using (SqlConnection conn = new SqlConnection(database.ConnectionToDatabase))
                                        {
                                            conn.Open();
                                            string updateQuery = "UPDATE Mantenimiento SET NombreCompletoPropietario = @NombreCompletoPropietario WHERE Id = @Id ";
                                            SqlCommand cmd = new SqlCommand(updateQuery, conn);

                                            cmd.Parameters.AddWithValue("@Id", maintenanceId);
                                            cmd.Parameters.AddWithValue("@NombreCompletoPropietario", MaintenanceOwnerFullNames[maintenanceId]);

                                            cmd.ExecuteNonQuery();
                                        }

                                        break;

                                    
                                    case 5:

                                        MaintenanceOwnerSocialIds[maintenanceId] = newElementFromMaintenance;

                                        
                                        using (SqlConnection conn = new SqlConnection(database.ConnectionToDatabase))
                                        {
                                            conn.Open();
                                            string updateQuery = "UPDATE Mantenimiento SET CedulaDelPropietario = @CedulaDelPropietario WHERE Id = @Id ";
                                            SqlCommand cmd = new SqlCommand(updateQuery, conn);

                                            cmd.Parameters.AddWithValue("@Id", maintenanceId);
                                            cmd.Parameters.AddWithValue("@CedulaDelPropietario", MaintenanceOwnerSocialIds[maintenanceId]);

                                            cmd.ExecuteNonQuery();
                                        }

                                        break;
                                }
                            }
                        }
                    }

                    else if (userMaintenanceManagementSelection == 2)
                    {

                        ViewAllMaintenances(MaintenanceDates, MaintenanceServiceTypes,
                            MaintenanceWorkshopNames, MaintenanceOwnerFullNames, MaintenanceOwnerSocialIds,
                            MaintenanceIds);

                        Console.WriteLine("Favor seleccione el id del registro de mantenimiento que desea modificar: ");
                        getId = Convert.ToInt32(Console.ReadLine());


                        foreach (var maintenanceId in MaintenanceIds)
                        {
                            if (maintenanceId == getId)
                            {
                                Console.WriteLine("Favor ingrese la nueva fecha de mantenimiento en el formato (aaaa-mm-dd): ");
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


                                using (SqlConnection conn = new SqlConnection(database.ConnectionToDatabase))
                                {
                                    conn.Open();
                                    string updateQuery = "UPDATE Mantenimiento SET FechaDeMantenimiento = @FechaDeMantenimiento, TipoDeServicio = @TipoDeServicio, NombreDeTaller = @NombreDeTaller, NombreCompletoPropietario = @NombreCompletoPropietario, CedulaDelPropietario = @CedulaDelPropietario WHERE Id = @Id ";
                                    SqlCommand cmd = new SqlCommand(updateQuery, conn);

                                    cmd.Parameters.AddWithValue("@Id", maintenanceId);
                                    cmd.Parameters.AddWithValue("@FechaDeMantenimiento", MaintenanceDates[maintenanceId].ToString());
                                    cmd.Parameters.AddWithValue("@TipoDeServicio", MaintenanceServiceTypes[maintenanceId]);
                                    cmd.Parameters.AddWithValue("@NombreDeTaller", MaintenanceWorkshopNames[maintenanceId]);
                                    cmd.Parameters.AddWithValue("@NombreCompletoPropietario", MaintenanceOwnerFullNames[maintenanceId]);
                                    cmd.Parameters.AddWithValue("@CedulaDelPropietario", MaintenanceOwnerSocialIds[maintenanceId]);

                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                    }


                    else if (userMaintenanceManagementSelection == 3)
                    {
                        ViewAllMaintenances(MaintenanceDates, MaintenanceServiceTypes,
                            MaintenanceWorkshopNames, MaintenanceOwnerFullNames, MaintenanceOwnerSocialIds,
                            MaintenanceIds);


                        Console.WriteLine("Favor ingrese el id del registro de mantenimiento que desee eliminar: ");
                        getId = Convert.ToInt32(Console.ReadLine());

                        foreach (var maintenanceId in MaintenanceIds.ToArray())
                        {
                            if (maintenanceId == getId)
                            {
                                MaintenanceDates.Remove(maintenanceId);
                                MaintenanceServiceTypes.Remove(maintenanceId);
                                MaintenanceWorkshopNames.Remove(maintenanceId);
                                MaintenanceWorkshopNames.Remove(maintenanceId);
                                MaintenanceOwnerSocialIds.Remove(maintenanceId);

                                MaintenanceIds.Remove(maintenanceId);

                                isMaintenanceRemoved = true;

                                
                                using (SqlConnection conn = new SqlConnection(database.ConnectionToDatabase))
                                {
                                    conn.Open();
                                    string deleteQuery = "DELETE FROM Mantenimiento WHERE Id = @Id";
                                    SqlCommand cmd = new SqlCommand(deleteQuery, conn);

                                    cmd.Parameters.AddWithValue("@Id", maintenanceId);

                                    cmd.ExecuteNonQuery();
                                }
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
    }
}
