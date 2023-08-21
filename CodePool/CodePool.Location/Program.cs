using ProtoBuf.Grpc.Server;
using CodePool.Location.Services;
using CodePool.Sharp.Extension;
using CodePool.Location.Services.Interfaces;
using ProtoBuf.Grpc.Configuration;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Google.Protobuf.Reflection;
using System.Text;
using Google.Protobuf;

GRPCExtension.GenerateProto();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ILocationService, LocationService>();
builder.Services.TryAddSingleton(BinderConfiguration.Create(binder: new ServiceBinderWithServiceResolutionFromServices(builder.Services)));
var grpcBuilder = builder.Services.AddCodeFirstGrpc(x => x.EnableDetailedErrors = true);
builder.Services.AddCodeFirstGrpcReflection();

var fileNames = Directory.EnumerateFiles("proto").Where(x => x.EndsWith(".proto")).ToList();

var set = new FileDescriptorSet();
set.Add("my.proto", true);
set.Process();

var bar = fileNames.Select(File.ReadAllBytes)
    .Select(Encoding.UTF8.GetString)
    .Select(ByteString.CopyFromUtf8)
    .Take(2)
    .ToList();

var foo = FileDescriptor.BuildFromByteStrings(bar, []);
var registry = TypeRegistry.FromFiles(foo);
grpcBuilder.AddJsonTranscoding(x =>
{
    x.TypeRegistry = registry;
});

// builder.Services.AddGrpc(x => x.EnableDetailedErrors = true).AddJsonTranscoding();
// builder.Services.AddCodeFirstGrpc();
// builder.Services.CustomJsonTranscoding<LocationService>();

builder.Services.AddGrpcSwagger();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = Assembly.GetEntryAssembly()?.GetName().Name,
    });
});

var app = builder.Build();

app.MapGrpcService<ILocationService>().WithMetadata(typeof(LocationService));
app.MapCodeFirstGrpcReflectionService();

// app.MapSwagger();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", Assembly.GetEntryAssembly()?.GetName().Name);
});

// app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");


app.Run();
