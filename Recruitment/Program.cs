using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Recruitment.Api;
using Recruitment.Core.DbAccess;
using Recruitment.Core.Products;
using Recruitment.Core.Validation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<RecruitmentDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IValidator<AddProductDto>, AddProductDtoValidator>();
builder.Services.AddScoped<IValidator<UpdateProductDto>, UpdateProductDtoValidator>();
builder.Services.AddScoped<IAddValidation, AddValidation>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
