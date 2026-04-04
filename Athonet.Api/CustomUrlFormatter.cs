namespace Athonet.Api;

/// <summary>
/// Custom URL parameter formatter that handles enum members with custom values.
/// </summary>
public class CustomUrlParameterFormatter : IUrlParameterFormatter
{
	/// <summary>
	/// Cache for enum member attributes.
	/// </summary>
	public static readonly ConcurrentDictionary<Type, ConcurrentDictionary<string, EnumMemberAttribute>> EnumMemberCache
		= new();

	/// <summary>
	/// Formats a URL parameter value.
	/// </summary>
	/// <param name="value">The parameter value.</param>
	/// <param name="attributeProvider">The attribute provider for the parameter.</param>
	/// <param name="type">The parameter type.</param>
	/// <returns>The formatted string value.</returns>
	public virtual string? Format(object? value, ICustomAttributeProvider attributeProvider, Type type)
	{
		// See if we have a format
		var formatString = attributeProvider.GetCustomAttributes(typeof(QueryAttribute), true)
			 .OfType<QueryAttribute>()
			 .FirstOrDefault()?.Format;

		EnumMemberAttribute? enummember = null;
		if (value != null)
		{
			var realType = Nullable.GetUnderlyingType(type) ?? type;

			if (realType.IsEnum)
			{
				var cached = EnumMemberCache.GetOrAdd(realType, _ => new ConcurrentDictionary<string, EnumMemberAttribute>());
				enummember = cached.GetOrAdd(
					value.ToString()!,
					val => realType.GetMember(val)[0].GetCustomAttribute<EnumMemberAttribute>()!
				);
			}
		}

		return value == null
			? null
			: string.Format(
				CultureInfo.InvariantCulture,
				string.IsNullOrWhiteSpace(formatString)
					? "{0}"
					: $"{{0:{formatString}}}",
				enummember?.Value ?? value
			);
	}
}
