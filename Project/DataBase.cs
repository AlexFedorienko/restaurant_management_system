using System;
using System.Data.SqlClient;

namespace Project
{
    internal class DataBase
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=mssql-194469-0.cloudclusters.net,10050;Initial Catalog=FoodDelivery;User ID=user;Password=Ytrewq321;Encrypt=True;TrustServerCertificate=True;");

        public void openConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                try
                {
                    sqlConnection.Open();
                    Console.WriteLine("Соединение успешно открыто.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка при открытии соединения: " + ex.Message);
                }
            }
        }

        public void closeConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    sqlConnection.Close();
                    Console.WriteLine("Соединение успешно закрыто.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка при закрытии соединения: " + ex.Message);
                }
            }
        }

        public SqlConnection getConnection()
        {
            return sqlConnection;
        }
    }
}
