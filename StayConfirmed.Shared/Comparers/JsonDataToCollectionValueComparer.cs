using Microsoft.EntityFrameworkCore.ChangeTracking;
using StayConfirmed.Shared.Extensions;
using System.Linq.Expressions;
using System.Text.Json;

namespace StayConfirmed.Shared.Comparers;

internal sealed class JsonDataToCollectionValueComparer<T>()
    : ValueComparer<T>(EqualsExpressionFunc, HashCodeExpressionFunc)
    where T : class
{
    private static Expression<Func<T, T, bool>> EqualsExpressionFunc => (t1, t2) => CompareValues(t1, t2);

    private static Expression<Func<T, int>> HashCodeExpressionFunc => (t) => GetHashCodeByElement(t);

    private static bool CompareValues(T x, T y) => JsonSerializer.Serialize(x) == JsonSerializer.Serialize(y);

    private static int GetHashCodeByElement(T obj)
    {
        if (obj.GetType().IsArrayOrCollection())
        {
            var list = obj as IEnumerable<T>;

            return list.Aggregate(0, (hashCode, element) => unchecked(hashCode * 1024 + element.GetHashCode()));
        }

        return unchecked(obj.GetHashCode() * 1024);
    }
}
