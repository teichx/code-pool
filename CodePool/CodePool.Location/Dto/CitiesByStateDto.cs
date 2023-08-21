using ProtoBuf;

namespace CodePool.Location.Dto;

[ProtoContract]
public class CitiesByStateDto
{
    [ProtoMember(1)]
    public required int StateId { get; set; }

    [ProtoMember(2)]
    public string? Name { get; set; }
}
