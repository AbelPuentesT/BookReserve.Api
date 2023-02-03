using BookReserve.Core.Interfaces;
using BookReserve.Core.Services;
using BookReserve.Infrastructure.Data;
using BookReserve.Infrastructure.Filters;
using Microsoft.EntityFrameworkCore;
using PolizaSOAT.Core.Interfaces;
using PolizaSOAT.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<BookReserveContext>(options =>
                options
                .UseSqlServer(builder.Configuration.GetConnectionString("BookReserve")));
builder.Services.AddTransient<IBookService, BookService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IReserveService, ReserveService>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers(options => options.Filters.Add<GlobalExceptionFilters>());
builder.Services.AddMvc(options => { options.Filters.Add<ValidationFilter>(); });


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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
