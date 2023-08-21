using ProtoBuf;

namespace CodePool.Location.Dto;

[ProtoContract]
public class FilterDto
{
    [ProtoMember(1)]
    public string? Name { get; set; }
}
