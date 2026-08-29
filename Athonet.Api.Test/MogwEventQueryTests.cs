using Athonet.Api.Interfaces;
using Refit;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Text.Json.Serialization;

namespace Athonet.Api.Test;

/// <summary>
/// Verifies how <see cref="MogwEventQuery"/> is bound to the query string. These tests use a
/// stub handler rather than a live Athonet appliance, so they run without credentials.
/// </summary>
public class MogwEventQueryTests
{
	private sealed class CapturingHandler : HttpMessageHandler
	{
		public Uri? CapturedUri { get; private set; }

		protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			// A handler is required to observe cancellation; doing so here also keeps the
			// stub faithful to the contract the real pipeline relies on.
			cancellationToken.ThrowIfCancellationRequested();

			CapturedUri = request.RequestUri;
			return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
			{
				Content = new StringContent("""{"events":[],"total":0}""", System.Text.Encoding.UTF8, "application/json")
			});
		}
	}

	private static async Task<string> GetQueryStringAsync(MogwEventQuery query)
	{
		var handler = new CapturingHandler();
		using var httpClient = new HttpClient(handler) { BaseAddress = new Uri("https://example.invalid") };

		var jsonSerializerOptions = new JsonSerializerOptions { Converters = { new JsonStringEnumConverter() } };
		var refitSettings = new RefitSettings
		{
			UrlParameterFormatter = new CustomUrlParameterFormatter(),
			ContentSerializer = new SystemTextJsonContentSerializer(jsonSerializerOptions)
		};

		var mogw = RestService.For<IMogw>(httpClient, refitSettings);
		_ = await mogw.GetEventsAsync(query, TestContext.Current.CancellationToken);

		return handler.CapturedUri!.Query;
	}

	[Fact]
	public async Task GetEventsAsync_AllPropertiesNull_EmitsNoQueryParameters()
	{
		var queryString = await GetQueryStringAsync(new MogwEventQuery());

		_ = queryString.Should().BeEmpty();
	}

	[Fact]
	public async Task GetEventsAsync_SomePropertiesSet_EmitsOnlyThoseParameters()
	{
		var queryString = await GetQueryStringAsync(new MogwEventQuery { OrderBy = "id", Limit = 10 });

		_ = queryString.Should().Contain("order_by=id");
		_ = queryString.Should().Contain("limit=10");
		_ = queryString.Should().NotContain("imsi");
		_ = queryString.Should().NotContain("imei");
		_ = queryString.Should().NotContain("id__gt");
	}

	[Fact]
	public async Task GetEventsAsync_UsesWireAliasesNotPropertyNames()
	{
		var queryString = await GetQueryStringAsync(new MogwEventQuery
		{
			Imsi = "123",
			FromTimestamp = 1000,
			ToTimestamp = 2000,
			IdGt = 5,
			IdGte = 6
		});

		_ = queryString.Should().Contain("imsi=123");
		_ = queryString.Should().Contain("from=1000");
		_ = queryString.Should().Contain("to=2000");
		_ = queryString.Should().Contain("id__gt=5");
		_ = queryString.Should().Contain("id__gte=6");
		_ = queryString.Should().NotContain("FromTimestamp");
		_ = queryString.Should().NotContain("ToTimestamp");
	}
}
