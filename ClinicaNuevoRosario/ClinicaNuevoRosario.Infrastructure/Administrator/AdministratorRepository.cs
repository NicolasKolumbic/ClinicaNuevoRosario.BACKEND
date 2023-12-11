using ClinicaNuevoRosario.Application.Contracts.Persistence;
using ClinicaNuevoRosario.Application.Models;
using Microsoft.Data.SqlClient;
using System.Data;



namespace ClinicaNuevoRosario.Infrastructure.Administrator
{
    internal class DatabaseFileList
    {
        public string DataName { get; set; }
        public string LogName { get; set; }
    }
    public class AdministratorRepository : IAdministratorRepository
    {
        public async Task<MemoryStream> GenerateBackup(string connectionString, string filename)
        {

            var localPath = Path.Combine("C:/Backups", $"{filename}");

            using (var connection = new SqlConnection(connectionString))
            {
                var sql = @"BACKUP DATABASE @databaseName TO DISK = @localDatabasePath";

                connection.Open();

                using (var command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandTimeout = 7200;
                    command.Parameters.AddWithValue("@databaseName", "ClinicaNuevoRosario");
                    command.Parameters.AddWithValue("@localDatabasePath", localPath);


                    command.ExecuteNonQuery();
                }

                var memory = new MemoryStream();
                using (var stream = new FileStream(localPath, FileMode.Open))
                {
                    await stream.CopyToAsync(memory);
                }
                memory.Position = 0;

                return memory;

            }
        }

        public Task<int> RestoreDatabase(RestoreDatabaseSetting setting) {


            // get file list data
            var fileList = GetDatabaseFileList(setting.ConnectionString, setting.LocalFolder);

            using (var connection = new SqlConnection(setting.ConnectionString))
            {
                connection.Open();
                try
                {

                    setSingleUser(connection, setting.DatabaseName);

                    // execute the database restore
                    var dataPath = Path.Combine(setting.SqlServerPath, "DATA");
                    var fileListDataPath = Path.Combine(dataPath, $"{fileList.DataName}.mdf");
                    var fileListLogPath = Path.Combine(dataPath, $"{fileList.LogName}.ldf");

                    var sql = @"RESTORE DATABASE @databaseName 
                            FROM DISK = @localDatabasePath 
                            WITH MOVE @fileListDataName to @fileListDataPath,
                            MOVE @fileListLogName to @fileListLogPath";
                    using (var command = new SqlCommand(sql, connection))
                    {
                        command.CommandTimeout = 7200;
                        command.CommandType = CommandType.Text;
                        command.Parameters.AddWithValue("@databaseName", setting.DatabaseName);
                        command.Parameters.AddWithValue("@localDatabasePath", setting.LocalFolder);
                        command.Parameters.AddWithValue("@fileListDataName", fileList.DataName);
                        command.Parameters.AddWithValue("@fileListDataPath", fileListDataPath);
                        command.Parameters.AddWithValue("@fileListLogName", fileList.LogName);
                        command.Parameters.AddWithValue("@fileListLogPath", fileListLogPath);

                        command.ExecuteNonQuery();
                    }

                    // set database to multi user
                    sql = @"declare @database varchar(max) = quotename(@databaseName)
                    EXEC('ALTER DATABASE ' + @database + ' SET MULTI_USER')";
                    using (var command = new SqlCommand(sql, connection))
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.AddWithValue("@databaseName", setting.DatabaseName);

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }

            return Task.FromResult(1);
        }


        private DatabaseFileList GetDatabaseFileList(string connectionString, string localDatabasePath)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var sql = @"RESTORE FILELISTONLY FROM DISK = @localDatabasePath";
                connection.Open();

                using (var command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@localDatabasePath", localDatabasePath);

                    using (var reader = command.ExecuteReader())
                    {
                        var result = new DatabaseFileList();
                        while (reader.Read())
                        {
                            var type = reader["Type"].ToString();
                            switch (type)
                            {
                                case "D":
                                    result.DataName = reader["LogicalName"].ToString();
                                    break;
                                case "L":
                                    result.LogName = reader["LogicalName"].ToString();
                                    break;
                            }
                        }

                        return result;
                    }
                }
            }
        }

        private void setSingleUser(SqlConnection connection, string databaseName)
        {
            // set database to single user

            var sql = @"declare @database varchar(max) = quotename(@databaseName)
                        EXEC('ALTER DATABASE ' + @database + ' SET OFFLINE WITH ROLLBACK IMMEDIATE')
                        EXEC('ALTER DATABASE ' + @database + ' SET ONLINE')
                        EXEC('ALTER DATABASE ' + @database + ' SET SINGLE_USER WITH ROLLBACK IMMEDIATE')";
            using (var command = new SqlCommand(sql, connection))
            {
                try
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@databaseName", databaseName);

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
               
            }
        }

    }
}
