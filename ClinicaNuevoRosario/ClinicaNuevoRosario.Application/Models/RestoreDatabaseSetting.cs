namespace ClinicaNuevoRosario.Application.Models
{
    public class RestoreDatabaseSetting
    {
        public string DatabaseName { get; set; }
        public string ConnectionString { get; set; }
        public string SqlServerPath { get; set; }
        public string LocalFolder { get; set; }

        public RestoreDatabaseSetting(string databaseName, string connectionString, string sqlServerPath, string localFolder)
        {
            DatabaseName = databaseName;
            ConnectionString = connectionString;
            SqlServerPath = sqlServerPath;
            LocalFolder = localFolder;

        }
    }
}
