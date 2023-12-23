using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;
using Microsoft.EntityFrameworkCore;
using VirtualPetCareApi;
using VirtualPetCareApi.Database;
using VirtualPetCareApi.Dtos;
using VirtualPetCareApi.Interface;
using VirtualPetCareApi.Models;
using VirtualPetCareApi.Repositories;
using VirtualPetCareApi.Validation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();

builder.Services.AddDbContext<GameDbContext>(options =>
                                                options.UseNpgsql(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddAutoMapper(typeof(User));
builder.Services.AddAutoMapper(typeof(Pet));
builder.Services.AddAutoMapper(typeof(HealthStatus));
builder.Services.AddAutoMapper(typeof(Activity));
builder.Services.AddAutoMapper(typeof(Food));
builder.Services.AddAutoMapper(typeof(Training));
builder.Services.AddAutoMapper(typeof(SocialInteraction));

builder.Services.AddControllers();

builder.Services.AddSingleton<IValidator<UserDto>, UserValidation>();
builder.Services.AddSingleton<IValidator<PetDto>, PetValidation>();
builder.Services.AddSingleton<IValidator<HealthStatusDto>, HealthStatusValidation>();
builder.Services.AddSingleton<IValidator<ActivityDto>, ActivityValidation>();
builder.Services.AddSingleton<IValidator<FoodDto>, FoodValidation>();
builder.Services.AddSingleton<IValidator<TrainingDto>, TrainingValidation>();
builder.Services.AddSingleton<IValidator<SocialInteractionDto>, SocialInteractionValidation>();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
