using System;
using System.Configuration;
using System.IO;

namespace QuickStart.DataBase
{
    public static class DataBaseHelper
    {
        private const string DataDirString = "|DataDirectory|";
        private const string DbLocationPlaceHolder = "%DbLocation%";

        private static readonly string AppDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"Telerik\WPF Demos").ToString();
        public static string GetConnectionString()
        {
            bool useAppData = false;
#if WPF461
            // For the Win 10 Store app we are moving the db to AppData.
            useAppData = true;
#endif
            var dbLocation = useAppData ? DataBaseHelper.AppDataPath : DataBaseHelper.DataDirString;
            var connectionString = 
                ConfigurationManager.ConnectionStrings["NorthwindEntities"].ConnectionString.Replace(DbLocationPlaceHolder, dbLocation);

            return connectionString;
        }
    }
}
