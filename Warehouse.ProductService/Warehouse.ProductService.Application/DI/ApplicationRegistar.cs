﻿using Microsoft.Extensions.DependencyInjection;
using Warehouse.ProductService.Application.Contracts.Services;
using Warehouse.ProductService.Application.Mapper;
using Warehouse.ProductService.Application.Services;

namespace Warehouse.ProductService.Application.DI
{
    public static class ApplicationRegistar
    {
        public static void AddApplicationDependencies(this IServiceCollection services)
        {
            services.AddTransient<IProductService, Services.ProductService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddAutoMapper(typeof(EntityModelProfile), typeof(ModelDTOProfile));
        }
    }
}