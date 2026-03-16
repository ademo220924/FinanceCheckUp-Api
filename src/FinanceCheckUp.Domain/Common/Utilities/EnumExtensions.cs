using System.ComponentModel;

namespace FinanceCheckUp.Domain.Common.Utilities;

public static class EnumExtensions
{
    public static string GetDescription(this Enum genericEnum)
    {
        var genericEnumType = genericEnum.GetType();
        var memberInfo = genericEnumType.GetMember(genericEnum.ToString());
        if (memberInfo is not { Length: > 0 })
            return genericEnum.ToString();
        var attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
        return attrs is { Length: > 0 }
            ? ((DescriptionAttribute)attrs.ElementAt(0)).Description
            : genericEnum.ToString();
    }

    public static int GetEnumValueFromDescription(string description, Type enumType)
    {
        foreach (var field in enumType.GetFields())
        {
            if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is not DescriptionAttribute attribute)
                continue;
            if (attribute.Description == description) return (int)field.GetValue(null);
        }

        return 0;
    }

    public static T GetValueFromDescription<T>(string description) where T : Enum
    {
        foreach (var field in typeof(T).GetFields())
            if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
            {
                if (attribute.Description == description)
                    return (T)field.GetValue(null);
            }
            else
            {
                if (field.Name == description)
                    return (T)field.GetValue(null);
            }

        return default;
    }

    public static object[] GetEnumProperties(this Enum genericEnum)
    {
        var genericEnumType = genericEnum.GetType();
        var memberInfo = genericEnumType.GetMember(genericEnum.ToString());
        if (memberInfo is not { Length: > 0 })
            return null;
        var attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
        return attrs is { Length: > 0 }
            ? attrs
            : null;
    }

    public static T[] GetEnumValues<T>() where T : struct
    {
        if (!typeof(T).IsEnum)
        {
            throw new ArgumentException("GetValues<T> can only be called for types derived from System.Enum", "T");
        }
        return (T[])Enum.GetValues(typeof(T));
    }


}