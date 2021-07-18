using IxarisTask.Abstracts;
using IxarisTask.Concretes;
using Microsoft.Extensions.DependencyInjection;

namespace IxarisTask
{
    public class Startup
    {
        /// <summary>
        /// Add services to the application and configure service provider
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IFileManagerService, FileManagerService>();
            services.AddSingleton<ITransferService, TransferService>();
            services.AddSingleton<IAccountService, AccountService>();
        }
    }
}
