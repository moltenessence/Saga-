﻿using AutoMapper;
using MassTransit;
using Microsoft.Extensions.Logging;
using Warehouse.Contracts.DTOs;
using WareHouse.IntegrationEvents;
using WareHouse.OrderService.Application.Contracts.Handlers;
using WareHouse.OrderService.Application.Contracts.Services;

namespace Warehouse.OrderService.Application.IntegrationEvents.Handlers
{
    public class ProductInStockHandler : IIntegrationEventHandler<ProductInStockIntegrationEvent>
    {
        private readonly IOrderService _orderService;
        private readonly ILogger<ProductInStockHandler> _logger;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IMapper _mapper;

        public ProductInStockHandler(IOrderService orderService, ILogger<ProductInStockHandler> logger, IPublishEndpoint publishEndpoint, IMapper mapper)
        {
            ArgumentNullException.ThrowIfNull(orderService);
            ArgumentNullException.ThrowIfNull(logger);
            ArgumentNullException.ThrowIfNull(publishEndpoint);
            ArgumentNullException.ThrowIfNull(mapper);

            _orderService = orderService;
            _logger = logger;
            _publishEndpoint = publishEndpoint;
            _mapper = mapper;
        }

        public async Task Process(ProductInStockIntegrationEvent @event, CancellationToken cancellationToken = default)
        {
            var product = @event.Payload;
            var order = await _orderService.GetById(product.OrderId, cancellationToken);

            _logger.LogInformation("Approve order: {id} process for product id: {productId}", product.OrderId, product.Id);

            await _publishEndpoint.Publish(new OrderFinishedIntegrationEvent(_mapper.Map<OrderDTO>(order)));

            _logger.LogInformation("Finished order process for product id: {id}", product.Id);
        }
    }
}
