using System.Collections;

namespace StayConfirmed.Shared.Extensions;

public static class TypeExtensions
{
    public static bool IsArrayOrCollection(this Type type)
    {
        ArgumentNullException.ThrowIfNull(type);

        if (type.IsArray)
        {
            return true;
        }

        var interfaces = type.GetInterfaces();

        foreach (var @interface in interfaces)
        {
            bool checkIfGenericEnumerable = @interface.IsGenericType
                && (@interface.GetGenericTypeDefinition() == typeof(IEnumerable<>)
                    || @interface.GetGenericTypeDefinition() == typeof(ICollection<>));

            bool checkIfEnumerable = @interface.GetGenericTypeDefinition() == typeof(IEnumerable)
                || @interface.GetGenericTypeDefinition() == typeof(ICollection);

            if (checkIfGenericEnumerable || checkIfEnumerable)
            {
                return true;
            }
        }

        return false;
    }
}
