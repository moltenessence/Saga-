﻿using WarehouseService.Application.Contracts.Repositories;
using WarehouseService.Domain.Entities;

namespace Warehouse.ProductService.Application.Contracts.Repositories
{
    public interface ICategoryRepository : IGenericRepository<CategoryEntity>
    {
    }
}