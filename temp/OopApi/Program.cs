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


//EpFnRef.FnMap<dbCtx, Unggas>(app, "ung", "aaa");
//EpFnRef.FnMap<dbCtx, Unggas>(app, "bur", "aaa");
app.FnTblBase<dbCtx, Unggas>("ung", "aaa");
app.FnTblBase<dbCtx, Unggas>("bur", "bbb");

// app.FnTblBase<dbCtx, KakiEmpat>();
var grpref = app.MapGroup("ref").WithTags("Public").WithOpenApi();
grpref.FnRefTblBase<dbCtx, Unggas>();
grpref.FnRefTblBase<dbCtx, KakiEmpat>();
var grpmas = app.MapGroup("mas").WithTags("Privat").WithOpenApi(); // .AddEndpointFilterFactory(QueryPrivateTodos);
grpmas.FnRefTblBase<dbCtx, Unggas>();
grpmas.FnRefTblBase<dbCtx, KakiEmpat>();
app.Run();

EndpointFilterDelegate QueryPrivateTodos(EndpointFilterFactoryContext factoryContext, EndpointFilterDelegate next)
{
    var dbContextIndex = -1;

    foreach (var argument in factoryContext.MethodInfo.GetParameters())
    {
        if (argument.ParameterType == typeof(dbCtx))
        {
            dbContextIndex = argument.Position;
            break;
        }
    }

    // Skip filter if the method doesn't have a TodoDb parameter.
    if (dbContextIndex < 0)
    {
        return next;
    }

    return async invocationContext =>
    {
        var dbContext = invocationContext.GetArgument<dbCtx>(dbContextIndex);
        dbContext.IsPrivate = true;

        try
        {
            return await next(invocationContext);
        }
        finally
        {
            // This should only be relevant if you're pooling or otherwise reusing the DbContext instance.
            dbContext.IsPrivate = false;
        }
    };
}
