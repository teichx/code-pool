using ProtoBuf.Grpc.Server;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCodeFirstGrpc();
builder.Services.AddCodeFirstGrpcReflection();

var app = builder.Build();

app.MapCodeFirstGrpcReflectionService();

app.Run();
