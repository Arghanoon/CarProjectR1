using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyDatabase;
using System.IO;

namespace Bussiness.Setting
{
    public static class Settings
    {
        public static string ConnectionStringFilePath { get { return MyUtility.Basic.AssemblyDirectory + "\\Config.dat"; } }

        public static bool SaveConnectionString(string connectionString)
        {
            try
            {
                File.WriteAllText(ConnectionStringFilePath, MyUtility.String.Encript(connectionString));

                return true;
            }
            catch (Exception ex)
            {
                BaseClass.log(ex);

                return false;
            }
        }
    }
}
