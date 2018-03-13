using System;

namespace RQM.Data.Request
{
    public class DatabaseConnection
    {
        public string GetConnectionString()
        {


            string connectionString = "Server=UAT-SQL2012.RESTONUAT.local;Database=DevOps;User Id=devops_user;Password=e93006799694c7-1F;";

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException("No connection string in appsettings.json");
            }

            return connectionString;
        }
    }
}
