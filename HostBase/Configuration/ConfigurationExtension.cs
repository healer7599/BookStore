using HostBase.Constant;
using Entity.ConfigModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostBase.Configuration
{
    public static class ConfigurationExtension
    {

        #region "Declare"

        private static string ROOT_FOLDER = "ROOT_FOLDER";
        private static string _rootFolder = null;
        private static string _configFolder = null;

        #endregion

        #region "Sub/Func"

        /// <summary>
        /// Lấy đường dẫn thư mục gốc
        /// </summary>
        /// <returns></returns>
        public static string GetRootFolder()
        {
            if (string.IsNullOrEmpty(_rootFolder))
            {
                string basePath = AppContext.BaseDirectory;
                string rootFolder = Environment.GetEnvironmentVariable(ROOT_FOLDER) ?? "";

                _rootFolder = Path.Combine(basePath, rootFolder);
            }

            return _rootFolder;
        }

        /// <summary>
        /// Lấy đường dẫn thư mục config
        /// </summary>
        /// <returns></returns>
        public static string GetConfigFolder()
        {
            if (string.IsNullOrEmpty(_configFolder))
            {
                string rootFolder = GetRootFolder();

                _configFolder = Path.Combine(rootFolder, "");
            }

            return _configFolder;
        }

        /// <summary>
        /// Đọc cấu hình app
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="files"></param>
        /// <returns></returns>
        public static IHostBuilder ConfigureAppsettings(this IHostBuilder builder, IEnumerable<string> files)
        {
            string configFolder = GetConfigFolder();
            string filePath = Path.Combine(configFolder, ConfigFileName.Default);

            AddFileConfig(builder, filePath);

            foreach (var fileName in files)
            {
                filePath = Path.Combine(configFolder, fileName);

                AddFileConfig(builder, filePath);
            }

            return builder;
        }

        /// <summary>
        /// inject app config 
        /// </summary>
        /// <typeparam name="TConfig"></typeparam>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection InjectConfig<TConfig>(this IServiceCollection services, IConfiguration configuration)
            where TConfig : DefaultConfig
        {
            Type type = typeof(TConfig);

            return services;
        }

        #endregion

        #region "Private"

        /// <summary>
        /// Thêm file config
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="filePath"></param>
        private static void AddFileConfig(IHostBuilder builder, string filePath)
        {
            if (File.Exists(filePath))
            {
                builder.ConfigureAppConfiguration((builderContext, config) =>
                {
                    config.AddJsonFile(filePath);
                });
            }
        }

        #endregion
    }
}
