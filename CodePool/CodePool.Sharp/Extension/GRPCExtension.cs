// using Microsoft.Extensions.DependencyInjection;
using Google.Protobuf.Reflection;
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

    // private static string ProjectName => Assembly.GetEntryAssembly()?.GetName().Name ?? string.Empty;

    /// <summary>
    /// Generates all .proto files in default folder.
    /// </summary>
    public static void GenerateProto()
    {
        EnsureCleanupDirectoryExists();

        File.WriteAllText(Path.Join(ProtoFolder, ".gitignore"), "*.*");
        var generator = new SchemaGenerator();

        // var protoNamespace = $"option csharp_namespace = \"{ProjectName}\";\n";

        AssemblyWalker.InterfacesWithAttribute<ServiceAttribute>()
            .ToList()
            .ForEach(inheritanceType =>
            {
                var fileName = inheritanceType.FullName;
                var schema = generator.GetSchema(inheritanceType);

                File.WriteAllText(Path.Join(ProtoFolder, $"{fileName}.proto"), schema);
            });
    }

    public static FileDescriptorSet GetFileDescriptorSet = () => new();

    // public static IServiceCollection CustomJsonTranscoding<TService>(this IServiceCollection services)
    // {
    //     var foo = BindMethodFinder.GetBindMethod(typeof(TService));
    //     Console.WriteLine(foo is null);
    //     // services.TryAddEnumerable(ServiceDescriptor.Singleton(
    //     //     typeof(IServiceMethodProvider<>),
    //     //     typeof(JsonTranscodingServiceMethodProvider<>)
    //     // ));

    //     // services.TryAddEnumerable(ServiceDescriptor
    //     //     .Singleton<IConfigureOptions<GrpcJsonTranscodingOptions>, GrpcJsonTranscodingOptionsSetup>());

    //     // services.TryAddSingleton<DescriptorRegistry>();

    //     return services;
    // }
}
