using CovidVaccinationSystem.Core.Interfaces;
using CovidVaccinationSystem.Data.Contexts;
using CovidVaccinationSystem.Data.Repositories;
using CovidVaccinationSystem.Services;
using CovidVaccinationSystem.Services.Interfaces;
using CovidVaccinationSystem.Services.Validation;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

// Register FluentValidation
builder.Services.AddValidatorsFromAssemblyContaining<PatientValidator>();

// Add services to the container
builder.Services.AddControllers().AddFluentValidation();
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IVaccinationEntryRepository, VaccinationEntryRepository>();
builder.Services.AddScoped<IVaccinationEntryService, VaccinationEntryService>();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
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
