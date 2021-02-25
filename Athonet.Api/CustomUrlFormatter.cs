using Refit;
using System;
using System.Collections.Concurrent;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace Athonet.Api
{
	public class CustomUrlParameterFormatter : IUrlParameterFormatter
	{
		public static readonly ConcurrentDictionary<Type, ConcurrentDictionary<string, EnumMemberAttribute>> EnumMemberCache
			= new();

		public virtual string? Format(object parameterValue, ICustomAttributeProvider attributeProvider, Type type)
		{
			// See if we have a format
			var formatString = attributeProvider.GetCustomAttributes(typeof(QueryAttribute), true)
				 .OfType<QueryAttribute>()
				 .FirstOrDefault()?.Format;

			EnumMemberAttribute? enummember = null;
			if (parameterValue != null)
			{
				var realType = Nullable.GetUnderlyingType(type) ?? type;

				if (realType.IsEnum)
				{
					var cached = EnumMemberCache.GetOrAdd(realType, _ => new ConcurrentDictionary<string, EnumMemberAttribute>());
					enummember = cached.GetOrAdd(
						parameterValue.ToString(),
						val => realType.GetMember(val)[0].GetCustomAttribute<EnumMemberAttribute>()
					);
				}
			}

			return parameterValue == null
				? null
				: string.Format(
					CultureInfo.InvariantCulture,
					string.IsNullOrWhiteSpace(formatString)
						? "{0}"
						: $"{{0:{formatString}}}",
					enummember?.Value ?? parameterValue
				);
		}
	}
}
