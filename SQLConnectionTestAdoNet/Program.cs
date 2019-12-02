﻿using System;
using System.Data;
using System.Data.SqlClient;

namespace SQLConnectionTestAdoNet
{
    class Program
    {
        static void Main()
        {
            string connectionString = "Data Source=RADCHENKO-LT;Initial Catalog=HR; Integrated Security=true";

            // Provide the query string with a parameter placeholder.
            string queryString =
                "SELECT first_name, last_name, salary from dbo.employees WHERE salary > @pricePoint ORDER BY salary DESC;";

            // Specify the parameter value.
            int paramValue = 2000;

            // Create and open the connection in a using block. This
            // ensures that all resources will be closed and disposed
            // when the code exits.
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@pricePoint", paramValue);

                // Open the connection in a try/catch block. 
                // Create and execute the DataReader, writing the result
                // set to the console window.
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    DataTable myTable = new DataTable();
                    myTable.Load(reader);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.ReadLine();
            }
        }
    }
}