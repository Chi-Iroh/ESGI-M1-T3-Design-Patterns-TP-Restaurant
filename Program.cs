using RestaurantApi;
using RestaurantApi.Models;
using RestaurantApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<OrderRepository>();
builder.Services.AddSingleton<RestaurantData>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

var repository = app.Services.GetRequiredService<OrderRepository>();
var restaurantData = app.Services.GetRequiredService<RestaurantData>();

app.MapGet("/", () => "Restaurant API is running. See /swagger for details.");

// Example endpoint to illustrate routing and repository usage.
// This is NOT a reference implementation, just a starting point.
app.MapGet("/api/orders", () => Results.Ok(repository.GetAll()));

app.MapPut("/api/orders/{id}/state", (string id) =>
{
    Order? order = repository.GetById(id);
    if (order is null)
    {
        return Results.NotFound();
    }
    string? currentState = order.NextState();
    if (currentState is null)
    {
        return Results.UnprocessableEntity("Order already finished !");
    }
    return Results.Ok($"Order {id} has state {currentState}");
});

app.MapGet("/api/orders/{id}", (string id) =>
{
    Order? order = repository.GetById(id);
    if (order is null)
    {
        return Results.NotFound();
    }
    return Results.Ok(order);
});

app.MapPost("/api/orders", (Order order) => {
    order.Attach(new KitchenListener());
    order.Attach(new InvoiceListener());
    order.Attach(new RoomListener());

    repository.Add(order);
    return Results.Ok(order.Id);
});

app.MapGet("/api/menu", () => Results.Ok(restaurantData.Menus()));

app.Run();
