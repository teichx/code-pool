using ProtoBuf.Grpc.Server;
using CodePool.Location.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCodeFirstGrpc();
builder.Services.AddCodeFirstGrpcReflection();

var app = builder.Build();

app.MapGrpcService<LocationService>();
app.MapCodeFirstGrpcReflectionService();

app.Run();
