var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("HotelListingDbConnectionString");

builder.Services.AddDbContext<HotelListListingDbContext>(options => {
    options.UseSqlServer(connectionString);
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



//開放API的跨域特性，允許任意來源且不限定header以及method
builder.Services.AddCors( options => 
    options.AddPolicy("AllowAll",
    builder => builder.AllowAnyHeader()
    .AllowAnyOrigin()
    .AllowAnyMethod())
    );

//使用Serilog讀取配置文件(appsettings.json)來進行記錄並輸出到控制台
builder.Host.UseSerilog((ctx, lc) => lc.WriteTo.Console().ReadFrom.Configuration(ctx.Configuration));

//註冊AutoMapper
builder.Services.AddAutoMapper(typeof(MapperConfig));

//register GenericRepository<T> with type IGenericRepository<T>
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
//register CountryRepository to container with type: ICountryRepository
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
//register HotelRepository to container with type: IHotelRepository
builder.Services.AddScoped<IHotelRepository, HotelRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
