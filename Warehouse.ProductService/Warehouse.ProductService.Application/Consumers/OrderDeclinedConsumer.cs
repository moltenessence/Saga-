﻿using MassTransit;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Warehouse.ProductService.Application.Contracts.Handlers;
using WareHouse.IntegrationEvents;

namespace Warehouse.ProductService.Application.Consumers
{
    public class OrderDeclinedConsumer : IConsumer<OrderDeclinedIntegrationEvent>
    {
        private readonly ILogger<OrderDeclinedConsumer> _logger;
        private readonly IIntegrationEventHandler<OrderDeclinedIntegrationEvent> _eventHandler;

        public OrderDeclinedConsumer(ILogger<OrderDeclinedConsumer> logger, IIntegrationEventHandler<OrderDeclinedIntegrationEvent> eventHandler)
        {
            ArgumentNullException.ThrowIfNull(logger);
            ArgumentNullException.ThrowIfNull(eventHandler);

            _logger = logger;
            _eventHandler = eventHandler;
        }

        public async Task Consume(ConsumeContext<OrderDeclinedIntegrationEvent> context)
        {
            var jsonMessage = JsonConvert.SerializeObject(context.Message);
            _logger.LogInformation("Order declined. Order: {order}", jsonMessage);

            await _eventHandler.Process(context.Message);
        }
    }
}
