var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Register Dependencies (Short-term manual registration until DI scanning is added)
// Infrastructure
// Note: We need a concrete implementation of ICartRepository. 
// Since we don't have the Infrastructure project hooked up fully yet, 
// I will create a Dummy/InMemory one for now or assume it will be provided.

// Mock Repository for Compilation/Runtime until Infrastructure layer is ready
// Mock Repository for Compilation/Runtime until Infrastructure layer is ready
builder.Services.AddSingleton<FoodDeliveryPlatform.Application.Cart.Abstractions.ICartRepository, FoodDeliveryPlatform.Api.Infrastructure.InMemoryCartRepository>();
builder.Services.AddSingleton<FoodDeliveryPlatform.Application.Orders.Abstractions.IOrderRepository, FoodDeliveryPlatform.Api.Infrastructure.InMemoryOrderRepository>();
builder.Services.AddSingleton<FoodDeliveryPlatform.SharedKernel.Abstractions.IServiceBus, FoodDeliveryPlatform.Api.Infrastructure.MockServiceBus>();

// Handlers
builder.Services.AddTransient<FoodDeliveryPlatform.SharedKernel.Abstractions.ICommandHandler<FoodDeliveryPlatform.Application.Cart.Commands.AddItemToCart.AddItemToCartCommand>, FoodDeliveryPlatform.Application.Cart.Commands.AddItemToCart.AddItemToCartHandler>();
builder.Services.AddTransient<FoodDeliveryPlatform.SharedKernel.Abstractions.ICommandHandler<FoodDeliveryPlatform.Application.Cart.Commands.RemoveItemFromCart.RemoveItemFromCartCommand>, FoodDeliveryPlatform.Application.Cart.Commands.RemoveItemFromCart.RemoveItemFromCartHandler>();
builder.Services.AddTransient<FoodDeliveryPlatform.SharedKernel.Abstractions.ICommandHandler<FoodDeliveryPlatform.Application.Cart.Commands.ClearCart.ClearCartCommand>, FoodDeliveryPlatform.Application.Cart.Commands.ClearCart.ClearCartHandler>();
// REMOVED: builder.Services.AddTransient<FoodDeliveryPlatform.SharedKernel.Abstractions.ICommandHandler<FoodDeliveryPlatform.Application.Cart.Commands.Checkout.CheckoutCartCommand>, FoodDeliveryPlatform.Application.Cart.Commands.Checkout.CheckoutCartHandler>();
builder.Services.AddTransient<FoodDeliveryPlatform.SharedKernel.Abstractions.ICommandHandler<FoodDeliveryPlatform.Application.Orders.Commands.CreateOrder.CreateOrderCommand>, FoodDeliveryPlatform.Application.Orders.Commands.CreateOrder.CreateOrderHandler>();

builder.Services.AddTransient<FoodDeliveryPlatform.SharedKernel.Abstractions.IQueryHandler<FoodDeliveryPlatform.Application.Cart.Queries.GetCart.GetCartQuery, FoodDeliveryPlatform.Application.Cart.Dtos.CartDto?>, FoodDeliveryPlatform.Application.Cart.Queries.GetCart.GetCartHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


