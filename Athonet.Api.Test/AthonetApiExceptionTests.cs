using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using Athonet.Api.Exceptions;

namespace Athonet.Api.Test;

public class AthonetApiExceptionTests
{
	private static AthonetApiException Create(HttpStatusCode statusCode, string responseBody)
	{
		var constructor = typeof(AthonetApiException).GetConstructor(
			BindingFlags.Instance | BindingFlags.NonPublic,
			binder: null,
			new[] { typeof(HttpStatusCode), typeof(string) },
			null);
		return (AthonetApiException)constructor!.Invoke(new object[] { statusCode, responseBody });
	}

	[Theory]
	[InlineData(HttpStatusCode.Unauthorized, "bad credentials")]
	[InlineData(HttpStatusCode.InternalServerError, "boom")]
	public void Constructor_PopulatesProperties(HttpStatusCode statusCode, string responseBody)
	{
		var exception = Create(statusCode, responseBody);

		_ = exception.HttpStatusCode.Should().Be(statusCode);
		_ = exception.ResponseBody.Should().Be(responseBody);
		_ = exception.Message.Should().Be(statusCode.ToString());
	}
}

public class AuthenticatedHttpHandlerTests
{
	private static AthonetClient BuildClient(AthonetClientOptions options)
	{
#pragma warning disable SYSLIB0026
		options.Certificate ??= new X509Certificate2();
#pragma warning restore SYSLIB0026
		options.Username ??= "user";
		options.Password ??= "pass";
		options.Hostname ??= "localhost";
		return new AthonetClient(options);
	}

	[Fact]
	public async Task SuccessfulResponse_ReturnsResponse_AndPopulatesLastResponse()
	{
		var handler = new StubHandler(HttpStatusCode.OK, "hello");
		using var client = BuildClient(new AthonetClientOptions { StoreLastRequestAndResponse = true });
		using var httpClient = new HttpClient(handler) { BaseAddress = new Uri("https://example.invalid") };

		_ = client.LastHttpRequest.Should().BeNull();
		_ = client.LastHttpResponse.Should().BeNull();

		var response = await httpClient.GetAsync("api", TestContext.Current.CancellationToken);

		_ = response.StatusCode.Should().Be(HttpStatusCode.OK);
		_ = handler.SentRequests.Should().HaveCount(1);
	}

	[Fact]
	public async Task FailureResponse_ReturnsNonSuccess_Status()
	{
		var handler = new StubHandler(HttpStatusCode.BadRequest, "the body");
		using var client = BuildClient(new AthonetClientOptions { StoreLastRequestAndResponse = true });
		using var httpClient = new HttpClient(handler) { BaseAddress = new Uri("https://example.invalid") };

		var response = await httpClient.GetAsync("api", TestContext.Current.CancellationToken);

		_ = response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
	}

	[Fact]
	public async Task TransportFailure_RethrowsOriginalException()
	{
		var handler = new ThrowingHandler(new HttpRequestException("dns"));
		using var client = BuildClient(new AthonetClientOptions { StoreLastRequestAndResponse = true });
		using var httpClient = new HttpClient(handler) { BaseAddress = new Uri("https://example.invalid") };

		var exception = await Record.ExceptionAsync(() => httpClient.GetAsync("api", TestContext.Current.CancellationToken));

		_ = exception.Should().BeOfType<HttpRequestException>();
		_ = exception!.Message.Should().Be("dns");
	}

	private sealed class StubHandler(HttpStatusCode status, string body) : HttpMessageHandler
	{
		public List<HttpRequestMessage> SentRequests { get; } = new();

		protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			SentRequests.Add(request);
			return Task.FromResult(new HttpResponseMessage(status) { Content = new StringContent(body, Encoding.UTF8, "application/json") });
		}
	}

	private sealed class ThrowingHandler(Exception error) : HttpMessageHandler
	{
		protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
			=> throw error;
	}
}
