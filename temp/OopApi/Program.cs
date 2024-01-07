using OopModel;

var builder = WebApplication.CreateBuilder(args);
var svc = builder.Services;
svc.AddAuthentication();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
svc.AddEndpointsApiExplorer();
svc.AddSwaggerGen();
svc.AddDbContext<dbCtx>();
//builder.Services.AddDbContext<dbCtx>((s,o) => {  } );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.FnTblBase<dbCtx,Unggas>();
app.FnTblBase<dbCtx, KakiEmpat>();

app.Run();

