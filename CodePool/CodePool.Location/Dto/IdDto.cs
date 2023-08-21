using System.Runtime.Serialization;
using ProtoBuf;

namespace CodePool.Location.Dto;

[ProtoContract]
[DataContract]
public class IdDto
{
    [ProtoMember(1)]
    [DataMember(Order = 1)]
    public required int Id { get; set; }
}
