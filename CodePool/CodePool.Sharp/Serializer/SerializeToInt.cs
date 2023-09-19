using System.Collections.Concurrent;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using CodePool.Sharp.Serializer.Interfaces;

namespace CodePool.Sharp.Serializer;

public sealed class SerializeToInt
{
    static readonly ConcurrentDictionary<string, ConstructorInfo> Constructors = new();

    static ConstructorInfo CreateConstructor(string key, Type objectType)
        => objectType.GetConstructor(
            bindingAttr: BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic,
            binder: null,
            callConvention: CallingConventions.Any,
            types: [typeof(int)],
            modifiers: null
        )!;

    static IConvertibleToInt? ConvertFromType(Type objectType, int value)
        => Constructors.GetOrAdd(objectType.FullName!, CreateConstructor, objectType)
            .Invoke([value])! as IConvertibleToInt;

    static bool CanConvertBase(Type currentType, Type converterType)
        => currentType
            .GetCustomAttributesData()
            .Any(x => x.ConstructorArguments
                .Any(y => converterType.Equals(y.Value)));

    public sealed class IntJsonConverter : JsonConverter<IConvertibleToInt>
    {
        static readonly Type CurrentTypeOf = typeof(IntJsonConverter);

        public override bool CanConvert(Type typeToConvert)
            => CanConvertBase(typeToConvert, CurrentTypeOf);

        public override IConvertibleToInt? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => ConvertFromType(typeToConvert, reader.GetInt32());

        public override void Write(Utf8JsonWriter writer, IConvertibleToInt? value, JsonSerializerOptions options)
            => writer.WriteNumberValue(value?.ToInt() ?? 0);
    }
}
