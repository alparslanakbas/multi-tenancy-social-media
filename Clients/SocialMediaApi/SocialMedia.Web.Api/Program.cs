using Microsoft.AspNetCore.Mvc;
using SocialMedia.Web.Api.Infrastructure.MultiTenant.Extensions;
using SocialMedia.Web.Api.Infrastructure.MultiTenant.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMultiTenancy();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/{tenantId}/get-tenantId/", ([FromServices] IMultiTenantService service) =>
{
    return $"Tenant: {service.GetCurrentTenantId()}";
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseMultiTenancy();
app.Run();
