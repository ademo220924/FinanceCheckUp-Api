namespace FinanceCheckUp.Application.Common.Constants;

public static class ValidationConsts
{
    public const string GuidRegex = @"^([0-9A-Fa-f]{8}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{12})$";
    public const string NullOrEmptyValidation = "'$fieldName$' alanı boş olamaz.";
    public const string GreaterThanValidation = "'$fieldName$' alanı $fieldValue$ değerinden büyük olmalıdır.";
    public const string LessThanValidation = "'$fieldName$' alanı $fieldValue$ değerinden küçük olmalıdır.";
    public const string IsInEnumValidation = "'$fieldName$' alanı '$fieldName$' tipinde olmalıdır.";
    public const string GuidRegexValidation = "'$fieldName$' alanı GUID tipinde olmalıdır.";
    public const string FieldName = "$fieldName$";
    public const string FieldValue = "$fieldValue$";
}