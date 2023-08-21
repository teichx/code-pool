using CodePool.Location.Dto;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Configuration;
// using System.ServiceModel;

namespace CodePool.Location.Services.Interfaces;

[Service]
// [ServiceContract]
public interface ILocationService
{
    // Task<ListStatesDto> ListStatesAsync(FilterDto request, CallContext context = default);
    // [Operation]
    Task<StateDto> GetStateByIdAsync(IdDto request, CallContext context = default);


    // Task<ListStatesDto> ListCitiesAsync(FilterDto request, CallContext context = default);
    // Task<ListStatesDto> ListCitiesByStateAsync(CitiesByStateDto request, CallContext context = default);
    // Task<CityDto> GetCityByIdAsync(IdDto request, CallContext context = default);
}
