using System.Reflection;
using System.Text;
using LightResults.Extensions.OpenAI;
using Shouldly;
using Xunit;

namespace LightResults.Extensions.Tests.OpenAI;

public sealed class OpenAIExtensionCoverageTests
{
    [Fact]
    public void AllPublicOpenAIClientMethodsShouldHaveTryExtensions()
    {
        var openAIAssembly = typeof(global::OpenAI.OpenAIClient).Assembly;
        var extensionAssembly = typeof(OpenAIClientExtensions).Assembly;
        var extensionMethods = GetExtensionMethodsByClientType(extensionAssembly);
        var missing = new List<string>();

        foreach (var clientType in GetOpenAIClientTypes(openAIAssembly))
        {
            foreach (var method in clientType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
            {
                if (method.IsSpecialName)
                    continue;

                var expectedKey = CreateMethodKey("Try" + method.Name, method.GetParameters(), 0);

                if (!extensionMethods.TryGetValue(clientType, out var clientMethods) || !clientMethods.Contains(expectedKey))
                    missing.Add($"{clientType.FullName}.{method.Name} => {expectedKey}");
            }
        }

        missing.ShouldBeEmpty();
    }

    private static Dictionary<Type, HashSet<string>> GetExtensionMethodsByClientType(Assembly extensionAssembly)
    {
        var extensionMethods = new Dictionary<Type, HashSet<string>>();

        foreach (var type in extensionAssembly.GetTypes())
        {
            if (!type.IsAbstract || !type.IsSealed || !type.IsPublic || !type.Name.EndsWith("Extensions", StringComparison.Ordinal))
                continue;

            foreach (var method in type.GetMethods(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly))
            {
                if (method.IsSpecialName)
                    continue;

                var parameters = method.GetParameters();
                if (parameters.Length == 0)
                    continue;

                var clientType = parameters[0].ParameterType;
                if (!extensionMethods.TryGetValue(clientType, out var clientMethods))
                {
                    clientMethods = [];
                    extensionMethods.Add(clientType, clientMethods);
                }

                clientMethods.Add(CreateMethodKey(method.Name, parameters, 1));
            }
        }

        return extensionMethods;
    }

    private static IEnumerable<Type> GetOpenAIClientTypes(Assembly openAIAssembly)
    {
        foreach (var type in openAIAssembly.GetTypes())
        {
            if (!type.IsClass || !type.IsPublic || !type.Name.EndsWith("Client", StringComparison.Ordinal))
                continue;

            if (type.Namespace is null || !type.Namespace.StartsWith("OpenAI", StringComparison.Ordinal))
                continue;

            if (HasPublicInstanceMethods(type))
                yield return type;
        }
    }

    private static bool HasPublicInstanceMethods(Type type)
    {
        foreach (var method in type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
        {
            if (!method.IsSpecialName)
                return true;
        }

        return false;
    }

    private static string CreateMethodKey(string methodName, ParameterInfo[] parameters, int parameterStartIndex)
    {
        var builder = new StringBuilder(methodName);
        builder.Append('(');

        for (var i = parameterStartIndex; i < parameters.Length; i++)
        {
            if (i > parameterStartIndex)
                builder.Append('|');

            AppendTypeKey(builder, parameters[i].ParameterType);
        }

        builder.Append(')');
        return builder.ToString();
    }

    private static void AppendTypeKey(StringBuilder builder, Type type)
    {
        if (!type.IsGenericType)
        {
            builder.Append(type.FullName);
            return;
        }

        builder.Append(type.GetGenericTypeDefinition().FullName);
        builder.Append('[');

        var genericArguments = type.GetGenericArguments();
        for (var i = 0; i < genericArguments.Length; i++)
        {
            if (i > 0)
                builder.Append(',');

            AppendTypeKey(builder, genericArguments[i]);
        }

        builder.Append(']');
    }
}
