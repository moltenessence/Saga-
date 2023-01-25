﻿using Warehouse.Contracts.DTOs;
using WareHouse.IntegrationEvents;

namespace Warehouse.ProductService.Application.IntegrationEvents.Events
{
    public record OrderApprovedIntegrationEvent : IntegrationEvent<OrderDTO>
    {
        public OrderApprovedIntegrationEvent(OrderDTO Payload) : base(Payload) { }
    }
}
