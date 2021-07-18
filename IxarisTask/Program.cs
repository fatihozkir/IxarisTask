using IxarisTask.Abstracts;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace IxarisTask
{
    class Program
    {
        static void Main(string[] args)
        {
            #region AppConfig
            IServiceCollection services = new ServiceCollection();
            Startup startup = new Startup();
            startup.ConfigureServices(services);
            IServiceProvider serviceProvider = services.BuildServiceProvider();

            IFileManagerService fileManagerService = serviceProvider.GetService<IFileManagerService>();
            ITransferService transferService = serviceProvider.GetService<ITransferService>();
            IAccountService accountService = serviceProvider.GetService<IAccountService>();
            #endregion

            string directoryPath = AppSettingsDefaults.DirectoryPath;

            var path = $"{directoryPath}transfers.txt";
            var fileExistance = fileManagerService.CheckFileExistance(path);
            if (!fileExistance)
            {
                throw new ApplicationException($"There is no file to be processed!");
            }

            var transfers = fileManagerService.ReadFile(path);

            if (transfers == null || transfers.Count <= 0) Console.WriteLine("There are no transfers to be shown!");

            var transferList = transferService.ConvertToTransferList(transfers);
            var accounts = accountService.ExtractAccounts(transferList);
            var finalBalances = accountService.GetAllFinalBalances(ref accounts, transferList);
            Console.WriteLine("#Balances");
            finalBalances.ForEach(balance =>
            {
                Console.WriteLine($"{balance.Id} - {balance.TotalBalance}");
            });
           
                        
            var highestBalancedAccount = accountService.GetHighestBalancedAccount(ref accounts);
            Console.WriteLine("\n#Bank Account with highest balance");
            Console.WriteLine($"{highestBalancedAccount.Id}");
           
            
            var frequentlyUsedSourceAccount = accountService.GetFrequentlyUsedSourceAccount(ref accounts);
            Console.WriteLine("\n#Frequently used source bank account");
            Console.WriteLine(frequentlyUsedSourceAccount.Id);

            Console.Read();

        }
    }
}
