using CodePool.Sharp.EnvironmentData;
using CodePool.Sharp.FeatureManagement.FeatureFilters;
using CodePool.Sharp.FeatureManagement.Redis;
using Microsoft.FeatureManagement;
using ProtoBuf.Grpc.Server;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCodeFirstGrpc();
builder.Services.AddCodeFirstGrpcReflection();
builder.Services.ExtendEnvironment()
    .ExtendRedisFeatureManagement();

var app = builder.Build();

app.MapCodeFirstGrpcReflectionService();

var featureManager = app.Services.GetRequiredService<IFeatureManager>();
var customerIdContext = new CustomerIdContext
{
    CustomerId = 1
};
Console.WriteLine("Default " + await featureManager.IsEnabledAsync("Default"));
Console.WriteLine("CustomerIdTest " + await featureManager.IsEnabledAsync("CustomerIdTest", customerIdContext));
Console.WriteLine("PercentageTest " + await featureManager.IsEnabledAsync("PercentageTest"));
Console.WriteLine("TimeWindowMuitoLegal " + await featureManager.IsEnabledAsync("TimeWindowMuitoLegal"));


app.Run();
