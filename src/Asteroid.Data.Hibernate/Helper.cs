using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;

namespace Asteroid.Data.Hibernate
{
    public class Helper
    {
        const char DELIMITER = ';';
        const char DELIMITER_KEY_VALUE = '=';
        const string KEY_USER = "User";
        const string KEY_PASSWORD = "Password";

        private static string GetPath()
        {
            var a = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
            //AppDomain.CurrentDomain.BaseDirectory;
            string codeBase = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string patha = Uri.UnescapeDataString(uri.Path);
            string path = Path.GetDirectoryName(patha);

            return path;
        }

        public static Configuration GetConfiguration(string configName)
        {

            var configuration = new Configuration();
            var path = GetPath();

            configuration.Configure(System.IO.Path.Combine(path, configName + ".config"));

            var temp = configuration
                .GetProperty(NHibernate.Cfg.Environment.ConnectionString);

            temp = RebuildConnectionString(temp);

            configuration
                .SetProperty(NHibernate.Cfg.Environment.ConnectionString, temp);

            return configuration;
        }

        private static string RebuildConnectionString(string connectionString)
        {
            throw new NotImplementedException();
        }

        private static string GetDecryptedText(string encryptedText,
            string certificateName)
        {
            throw new NotImplementedException();
        }

        private static void GetEncryptedPassword(string userName,
            string path,
            out string encryptedText,
            out string publicCertificateName)
        {
            throw new NotImplementedException();
        }
    }
}
