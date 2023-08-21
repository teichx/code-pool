using System.Runtime.Serialization;
using ProtoBuf;

namespace CodePool.Location.Dto;

[ProtoContract]
[DataContract]
public class StateDto
{
    [ProtoMember(1)]
    [DataMember(Order = 1)]
    public required int Id { get; set; }

    [ProtoMember(2)]
    [DataMember(Order = 2)]
    public required string Name { get; set; }

    [ProtoMember(3)]
    [DataMember(Order = 3)]
    public required string Acronym { get; set; }

    [ProtoMember(4)]
    [DataMember(Order = 4)]
    public required int CountryId { get; set; }
}
