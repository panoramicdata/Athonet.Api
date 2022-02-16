// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

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
[assembly: SuppressMessage(
    "Performance",
    "CA1848:Use the LoggerMessage delegates",
    Justification = "Performance gains not worth the effort",
    Scope = "namespaceanddescendants",
    Target = "~N:Athonet.Api")
]
[assembly: SuppressMessage(
    "Naming",
    "CA1716:Identifiers should not match keywords",
    Justification = "No likelihood of confusion",
    Scope = "member",
    Target = "~M:Athonet.Api.Interfaces.IMogw.GetEventsAsync(System.String,System.String,System.Nullable{System.Int64},System.Nullable{System.Int64},System.Nullable{System.Int32},System.Nullable{Athonet.Api.Data.Mogw.EventType},System.Nullable{Athonet.Api.Data.Mogw.EventLayer},System.Nullable{System.Int64},System.Nullable{System.Int64},System.Nullable{System.Int64},System.String,System.Threading.CancellationToken)~System.Threading.Tasks.Task{Athonet.Api.Data.Mogw.MogwEventSet}")
]
[assembly: SuppressMessage(
    "Naming",
    "CA1716:Identifiers should not match keywords",
    Justification = "No likelihood of confusion",
    Scope = "type",
    Target = "~T:Athonet.Api.Data.Mogw.Event")
]
