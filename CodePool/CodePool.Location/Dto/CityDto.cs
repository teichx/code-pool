using ProtoBuf;

namespace CodePool.Location.Dto;

[ProtoContract]
public class CityDto
{
    [ProtoMember(1)]
    public required int Id { get; set; }

    [ProtoMember(2)]
    public required string Name { get; set; }
}
