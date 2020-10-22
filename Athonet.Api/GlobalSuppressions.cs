// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage(
	"Design",
	"RCS1194:Implement exception constructors.",
	Justification = "Exception can only be raised this way.",
	Scope = "type",
	Target = "~T:Athonet.Api.Exceptions.AthonetApiException"
	)
]

[assembly: SuppressMessage(
	"IDisposableAnalyzers.Correctness",
	"IDISP014:Use a single instance of HttpClient.",
	Justification = "Analyzer is incorrect - this is a constructor",
	Scope = "member",
	Target = "~M:Athonet.Api.AthonetClient.#ctor(Athonet.Api.AthonetClientOptions,Microsoft.Extensions.Logging.ILogger)"
	)
]
