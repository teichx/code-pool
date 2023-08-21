// using System.Reflection;
using CodePool.Location.Dto;
using CodePool.Location.Services.Interfaces;
// using Grpc.Core;
// using Grpc.Core;
using ProtoBuf.Grpc;

namespace CodePool.Location.Services;

// [BindServiceMethod(typeof(ILocationService), nameof(Binder))]
public class LocationService : ILocationService
{
    public Task<StateDto> GetStateByIdAsync(IdDto request, CallContext context = default)
    {
        return Task.FromResult(new StateDto
        {
            Id = request.Id,
            Acronym = "MG",
            Name = "Minas Gerais",
            CountryId = 1,
        });
    }

    // public static void Binder(ServiceBinderBase binderBase, LocationService service)
    // {
    //     // binderBase.AddMethod(service);
    //     Console.WriteLine("here");
    //     Console.WriteLine(binderBase);
    //     Console.WriteLine(service);
    // }
    // protected virtual object[] GetMetadata(MethodInfo method) => method.GetCustomAttributes(inherit: true);
    // protected virtual object[] GetMetadata(Type type) => type.GetCustomAttributes(inherit: true);
}
