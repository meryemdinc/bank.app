
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bank.app.application.DTOs.CardDTOs;
using bank.app.application.Interfaces;
using AutoMapper;

namespace bank.app.workers.Workers
{
    public class CardActivityWorker : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<CardActivityWorker> _logger;

        public CardActivityWorker(IServiceProvider serviceProvider, ILogger<CardActivityWorker> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("CardActivityWorker çalışıyor: {time}", DateTimeOffset.Now);

                using (var scope = _serviceProvider.CreateScope())
                {
                    var cardService = scope.ServiceProvider.GetRequiredService<ICardService>();
                    var mapper = scope.ServiceProvider.GetRequiredService<IMapper>();

                    var cards = await cardService.GetAllAsync();
                    var now = DateTime.UtcNow;

                    var expiredCards = cards
                        .Where(c => c.IsActive && (c.ExpiryYear < now.Year ||
                            (c.ExpiryYear == now.Year && c.ExpiryMonth < now.Month)))
                        .ToList();

                    foreach (var card in expiredCards)
                    {
                        var updateDto = new UpdateCardDto
                        {
                            Id = card.Id,
                            CardNumber = card.CardNumber,
                            ExpiryMonth = card.ExpiryMonth,
                            ExpiryYear = card.ExpiryYear,
                            CCV = card.CCV,
                            IsActive = false,
                            AccountId = card.AccountId,
                            CardTypeId = card.CardTypeId
                        };

                        await cardService.UpdateAsync(updateDto);
                        _logger.LogInformation($"Kart pasif hale getirildi. ID: {card.Id}");
                    }
                }

                // 24 saatte bir çalışsın
                await Task.Delay(TimeSpan.FromDays(1), stoppingToken);
            }
        }
    }
}
