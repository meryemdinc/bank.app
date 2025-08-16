using bank.app.application.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank.app.workers.Workers
{
    public class TransactionWorker : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<TransactionWorker> _logger;

        public TransactionWorker(IServiceProvider serviceProvider, ILogger<TransactionWorker> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("TransactionWorker started at: {time}", DateTimeOffset.Now);

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using (var scope = _serviceProvider.CreateScope())
                    {
                        var transactionService = scope.ServiceProvider.GetRequiredService<ITransactionService>();

                        // Örnek: Tüm transaction'ları al
                        var transactions = await transactionService.GetAllAsync();

                        foreach (var transaction in transactions)
                        {
                            // Burada işlem yapmak istediğin herhangi bir logic ekleyebilirsin
                            _logger.LogInformation("Transaction ID {id}, Amount {amount}, Date {date}",
                                transaction.Id, transaction.Amount, transaction.TransactionDate);
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "TransactionWorker error: {message}", ex.Message);
                }

                // Örnek: 24 saatte bir çalışacak şekilde ayar
                await Task.Delay(TimeSpan.FromDays(1), stoppingToken);
            }
        }
    }
}
