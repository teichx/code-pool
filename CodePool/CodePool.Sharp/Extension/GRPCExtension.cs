using ProtoBuf.Grpc.Configuration;
using ProtoBuf.Grpc.Reflection;

namespace CodePool.Sharp.Extension;

/// <summary>
/// The class <c>GRPCExtension</c> provides the abstractions related to grpc
/// </summary>
public static class GRPCExtension
{
    public const string ProtoFolder = "proto";

    private static void EnsureCleanupDirectoryExists()
    {
        var directory = Directory.CreateDirectory(ProtoFolder);
        directory.Delete(recursive: true);
        directory.Create();
    }

    /// <summary>
    /// Generates all .proto files in default folder.
    /// </summary>
    public static void GenerateProto()
    {
        EnsureCleanupDirectoryExists();

        File.WriteAllText(Path.Join(ProtoFolder, ".gitignore"), "*.*");
        var generator = new SchemaGenerator();

        AssemblyWalker.InterfacesWithAttribute<ServiceAttribute>()
            .ToList()
            .ForEach(inheritanceType =>
            {
                var fileName = inheritanceType.FullName;
                var schema = generator.GetSchema(inheritanceType);

                File.WriteAllText(Path.Join(ProtoFolder, $"{fileName}.proto"), schema);
            });
    }
}
