using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank.app.workers.Workers
{
    public class EmailSenderWorker : BackgroundService
    {
        private readonly ILogger<EmailSenderWorker> _logger;

        public EmailSenderWorker(ILogger<EmailSenderWorker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("EmailSenderWorker çalışmaya başladı.");

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("EmailSenderWorker çalışıyor: {time}", DateTimeOffset.Now);

                // Buraya email gönderme veya başka işlem kodu eklenebilir
                // Ancak şu anda projenizde ilgili servis yok

                await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
            }

            _logger.LogInformation("EmailSenderWorker durduruluyor.");
        }
    }
}
