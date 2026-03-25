using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using Xunit.Microsoft.DependencyInjection;
using Xunit.Microsoft.DependencyInjection.Abstracts;

namespace Athonet.Api.Test;

public class Fixture : TestBedFixture
{
	protected override void AddServices(IServiceCollection services, IConfiguration? configuration)
		=> services.AddLogging();

	protected override ValueTask DisposeAsyncCore()
		=> default;

	protected override IEnumerable<TestAppSettings> GetTestAppSettings() => [
			new TestAppSettings
			{
				IsOptional = true,
				Filename = null,
			}
		];
}
