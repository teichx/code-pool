using ProtoBuf.Grpc.Configuration;
using ProtoBuf.Grpc.Reflection;

namespace CodePool.Sharp.Extension;

public static class GRPCExtension
{
    public static void GenerateProto()
    {
        File.WriteAllText("proto/.gitignore", "*.*");

        var generator = new SchemaGenerator();

        AssemblyWalker.InterfacesWithAttribute<ServiceAttribute>()
            .ToList()
            .ForEach(inheritanceType =>
            {
                var fileName = inheritanceType.FullName;
                var schema = generator.GetSchema(inheritanceType);

                File.WriteAllText($"proto/{fileName}.proto", schema);
            });
    }
}
