using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase;
using Entities;
using Interfaces;

namespace Logic
{
    public class InsurancesManagementLogic : IInsurancesManagement
    {

        public void ViewAllInsurances(
            Dictionary<int, string> getInsuranceCompanieNames,
            Dictionary<int, string> getInsurancePolicyNumbers,
            Dictionary<int, DateOnly> getInsuranceStartDates,
            Dictionary<int, DateOnly> getInsuranceExpirationDates,
            List<int> getInsuranceIds
            )
        {
            Console.WriteLine("");

            Console.WriteLine("Seguros: ");


            foreach (var insuranceId in getInsuranceIds)
            {
                Console.WriteLine($"""
                    id: {insuranceId}   Compañía aseguradora: {getInsuranceCompanieNames[insuranceId]}   Número de póliza: {getInsurancePolicyNumbers[insuranceId]}   Fecha de inicio: {getInsuranceStartDates[insuranceId]}   Fecha de vencimiento: {getInsuranceExpirationDates[insuranceId]}
                    """);
            }

            Console.WriteLine("");
        }

        protected static void ConnectAndInsertElementsToDataBase(
            Dictionary<int, string> getInsuranceCompanieNames,
            Dictionary<int, string> getInsurancePolicyNumbers,
            Dictionary<int, DateOnly> getInsuranceStartDates,
            Dictionary<int, DateOnly> getInsuranceExpirationDates,
            List<int> getInsuranceIds
          )
        
        {
            int Id = getInsuranceIds.Count;

            Database database = new Database();


            using (SqlConnection conn = new SqlConnection(database.ConnectionToDatabase))
            {

                conn.Open();
                string sql = "INSERT INTO Seguro (NombreDeCompania, NumeroDePoliza, FechaDeInicio, FechaDeVencimiento) VALUES (@NombreDeCompania, @NumeroDePoliza, @FechaDeInicio, @FechaDeVencimiento)";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@NombreDeCompania", getInsuranceCompanieNames[Id]);
                cmd.Parameters.AddWithValue("@NumeroDePoliza", getInsurancePolicyNumbers[Id]);
                cmd.Parameters.AddWithValue("@FechaDeInicio", getInsuranceStartDates[Id].ToString());
                cmd.Parameters.AddWithValue("@FechaDeVencimiento", getInsuranceExpirationDates[Id].ToString());
                
                cmd.ExecuteNonQuery();
            }
        }

        public void InsuranceManagementF(
            Dictionary<int, string> InsuranceCompanieNames,
            Dictionary<int, string> InsurancePolicyNumbers,
            Dictionary<int, DateOnly> InsuranceStartDates,
            Dictionary<int, DateOnly> InsuranceExpirationDates,
            List<int> InsuranceIds
            )
        {

            int getId;

            Database database = new Database();
            

            Console.WriteLine("""
                Favor escoja la acción que desea realizar:
                1.Agregar un nuevo registro de seguro
                2.Editar la informacion de seguros existentes
                3.Mostrar los seguros próximos a vencer
                4.Consultar el historial de seguros
                5.Eliminar seguros vencidos

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

                    ConnectAndInsertElementsToDataBase(
                        InsuranceCompanieNames,InsurancePolicyNumbers, 
                        InsuranceStartDates,InsuranceExpirationDates, 
                        InsuranceIds);

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
                        ViewAllInsurances(InsuranceCompanieNames, InsurancePolicyNumbers, 
                            InsuranceStartDates, InsuranceExpirationDates,
                            InsuranceIds);

                        Console.WriteLine("Favor seleccione el id del registro de seguro que desee modificar: ");
                        getId = Convert.ToInt32(Console.ReadLine());


                        foreach (var insuranceId in InsuranceIds)
                        {
                            if (insuranceId == getId)
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

                                        using (SqlConnection conn = new SqlConnection(database.ConnectionToDatabase))
                                        {
                                            conn.Open();
                                            string updateQuery = "UPDATE Seguro SET NombreDeCompania = @NombreDeCompania WHERE Id = @Id ";
                                            SqlCommand cmd = new SqlCommand(updateQuery, conn);

                                            cmd.Parameters.AddWithValue("@Id", insuranceId);
                                            cmd.Parameters.AddWithValue("@NombreDeCompania", InsuranceCompanieNames[insuranceId]);

                                            cmd.ExecuteNonQuery();
                                        }

                                        break;

                                    
                                    case 2:

                                        InsurancePolicyNumbers[insuranceId] = newElementFromInsurances;

                                        using (SqlConnection conn = new SqlConnection(database.ConnectionToDatabase))
                                        {
                                            conn.Open();
                                            string updateQuery = "UPDATE Seguro SET NumeroDePoliza = @NumeroDePoliza WHERE Id = @Id ";
                                            SqlCommand cmd = new SqlCommand(updateQuery, conn);

                                            cmd.Parameters.AddWithValue("@Id", insuranceId);
                                            cmd.Parameters.AddWithValue("@NumeroDePoliza", InsurancePolicyNumbers[insuranceId]);

                                            cmd.ExecuteNonQuery();
                                        }

                                        break;

                                    
                                    case 3:

                                        InsuranceStartDates[insuranceId] = DateOnly.Parse(newElementFromInsurances);

                                        using (SqlConnection conn = new SqlConnection(database.ConnectionToDatabase))
                                        {
                                            conn.Open();
                                            string updateQuery = "UPDATE Seguro SET FechaDeInicio = @FechaDeInicio WHERE Id = @Id ";
                                            SqlCommand cmd = new SqlCommand(updateQuery, conn);

                                            cmd.Parameters.AddWithValue("@Id", insuranceId);
                                            cmd.Parameters.AddWithValue("@FechaDeInicio", InsuranceStartDates[insuranceId].ToString());

                                            cmd.ExecuteNonQuery();
                                        }

                                        break;

                                    
                                    case 4:

                                        InsuranceExpirationDates[insuranceId] = DateOnly.Parse(newElementFromInsurances);

                                        using (SqlConnection conn = new SqlConnection(database.ConnectionToDatabase))
                                        {
                                            conn.Open();
                                            string updateQuery = "UPDATE Seguro SET FechaDeVencimiento = @FechaDeVencimiento WHERE Id = @Id ";
                                            SqlCommand cmd = new SqlCommand(updateQuery, conn);

                                            cmd.Parameters.AddWithValue("@Id", insuranceId);
                                            cmd.Parameters.AddWithValue("@FechaDeVencimiento", InsuranceExpirationDates[insuranceId].ToString());

                                            cmd.ExecuteNonQuery();
                                        }

                                        break;
                                }
                            }
                        }
                    }

                    else if (userInsuranceManagementSelection == 2)
                    {
                        
                        ViewAllInsurances(InsuranceCompanieNames, InsurancePolicyNumbers, 
                            InsuranceStartDates, InsuranceExpirationDates, InsuranceIds);

                        Console.WriteLine("Favor seleccione el id del registro de seguro que desee modificar: ");
                        getId = Convert.ToInt32(Console.ReadLine());


                        foreach (var insuranceId in InsuranceIds)
                        {
                            if (insuranceId == getId)
                            {
                                Console.WriteLine("Favor ingrese la nueva compañía aseguradora: ");
                                getAllNewElementsFromInsurances = Console.ReadLine();
                                InsuranceCompanieNames[insuranceId] = getAllNewElementsFromInsurances;

                                Console.WriteLine("Favor ingrese el nuevo número de póliza: ");
                                getAllNewElementsFromInsurances = Console.ReadLine();
                                InsurancePolicyNumbers[insuranceId] = getAllNewElementsFromInsurances;

                                Console.WriteLine("Favor ingrese la nueva fecha de inicio en el formato (aaaa-mm-dd): ");
                                getAllNewElementsFromInsurances = Console.ReadLine();
                                InsuranceStartDates[insuranceId] = DateOnly.Parse(getAllNewElementsFromInsurances);

                                Console.WriteLine("Favor ingrese la nueva fecha de vencimiento en el formato (aaaa-mm-dd): ");
                                getAllNewElementsFromInsurances = Console.ReadLine();
                                InsuranceExpirationDates[insuranceId] = DateOnly.Parse(getAllNewElementsFromInsurances);

                                using (SqlConnection conn = new SqlConnection(database.ConnectionToDatabase))
                                {
                                    conn.Open();
                                    string updateQuery = "UPDATE Seguro SET NombreDeCompania = @NombreDeCompania, NumeroDePoliza = @NumeroDePoliza, FechaDeInicio = @FechaDeInicio, FechaDeVencimiento = @FechaDeVencimiento WHERE Id = @Id ";
                                    SqlCommand cmd = new SqlCommand(updateQuery, conn);

                                    cmd.Parameters.AddWithValue("@Id", insuranceId);
                                    cmd.Parameters.AddWithValue("@NombreDeCompania", InsuranceCompanieNames[insuranceId]);
                                    cmd.Parameters.AddWithValue("@NumeroDePoliza", InsurancePolicyNumbers[insuranceId]);
                                    cmd.Parameters.AddWithValue("@FechaDeInicio", InsuranceStartDates[insuranceId].ToString());
                                    cmd.Parameters.AddWithValue("@FechaDeVencimiento", InsuranceExpirationDates[insuranceId].ToString());
                                    
                                    cmd.ExecuteNonQuery();
                                }
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


                        if (getInsuranceDate.Year == 2025 && getInsuranceDate.Month >= 11 && getInsuranceDate.Day >= 20)
                        {
                            Console.WriteLine($"""
                                id: {insuranceId}   Compañía aseguradora: {InsuranceCompanieNames[insuranceId]}   Número de póliza: {InsurancePolicyNumbers[insuranceId]}   Fecha de inicio: {InsuranceStartDates[insuranceId]}   Fecha de vencimiento: {InsuranceExpirationDates[insuranceId]}
                                """);
                        }
                    }

                    break;


                case 4:
                    
                    ViewAllInsurances(InsuranceCompanieNames, InsurancePolicyNumbers, 
                        InsuranceStartDates, InsuranceExpirationDates,
                        InsuranceIds);

                    break;


                case 5:
                    
                    bool isInsuranceExpired = false;

                    foreach (var insuranceId in InsuranceIds.ToArray())
                    {
                        DateOnly getInsuranceExpirationDateToRemoveIt = InsuranceExpirationDates[insuranceId];


                        if (getInsuranceExpirationDateToRemoveIt.Year == 2025 && getInsuranceExpirationDateToRemoveIt.Month == 12 && getInsuranceExpirationDateToRemoveIt.Day == 30)
                        {
                            InsuranceCompanieNames.Remove(insuranceId);
                            InsurancePolicyNumbers.Remove(insuranceId);
                            InsuranceStartDates.Remove(insuranceId);
                            InsuranceExpirationDates.Remove(insuranceId);

                            InsuranceIds.Remove(insuranceId);

                            isInsuranceExpired = true;

                            using (SqlConnection conn = new SqlConnection(database.ConnectionToDatabase))
                            {
                                conn.Open();
                                string deleteQuery = "DELETE FROM Seguro WHERE Id = @Id";
                                SqlCommand cmd = new SqlCommand(deleteQuery, conn);

                                cmd.Parameters.AddWithValue("@Id", insuranceId);

                                cmd.ExecuteNonQuery();
                            }
                        }
                    }

                    if (isInsuranceExpired == true)
                    {
                        Console.WriteLine("Seguros vencidos eliminados satisfactoriamente.");
                    }

                    break;
            }

            if (userInsuranceManagementSelection > 5 || userInsuranceManagementSelection == 0)
            {
                Console.WriteLine("Debe ingresar una de las opciones.");
            }
        }
    }
}

